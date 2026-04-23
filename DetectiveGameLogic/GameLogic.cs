using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Timers;


namespace TextBasedDetectQuest
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationAction> Actions { get; set; }
        public bool IsFinal { get; set; }
        public string ImageName { get; set; }
    }

    public class LocationAction
    {
        public string Text { get; set; }
        public Action Action { get; set; }
        public string RequiredStat { get; set; }
        public int RequiredValue { get; set; }
        public bool IsHidden { get; set; }
        public bool GivesClue { get; set; }
        public string ClueName { get; set; }
        public string Description { get; set; }
    }
    public class GameLogic
    {
        public event Action<string> OnLogAdded; //добавление текста в текстовое поле
        public event Action<int> OnTimeChanged; //изменение времени
        public event Action<int> OnCluesChanged; //изменение количества улик
        public event Action<string, int> OnStatChanged;//изменение характеристики
        public event Action<string> OnLocationLoaded; //загрузка локации
        public event Action<List<LocationAction>> OnActionsUpdated; //обновление кнопок
        public event Action<string, string> OnImageChanged; //смена картинки
        public event Action<string> OnLocationListUpdated; //обновление списка локаций
        public event Action OnGameOver; //конец игры
        public event Action OnVictory; //победа

        private HashSet<int> completedActions = new HashSet<int>();
        private List<Location> locations = new List<Location>();
        private int currentLocationIndex = 0;
        private int timeValue = 100;
        private int cluesValue = 0;

        //характеристики
        private int resolveValue = 0;
        private int attentionValue = 0;
        private int logicValue = 0;
        private int charismaValue = 0;

        private bool isLocationCompleted = false;
        private bool contactUsed =false;
        private bool resolveGained = false;
        private bool logicGained = false;
        private System.Timers.Timer locationTimer;

        //списки улик
        private List<string> foundClues = new List<string>();
        private List<string> realClues = new List<string>
        {
            "Следы косметики", "Показания Коли", "Показания Зинаиды", "Орудие убийства", "Слухи о Лике", "Подсказка Коли", "Документы Пожарского", "Показания бармена", "Переписка Верховского с угрозами","Заявление в полицию", "Отпечатки Лики на зеркале"
        };
        private List<string> fakeClues = new List<string>
        {
            "Любовное письмо", "Признание Евы", "Билет Пожарского", "Пятно крови", "Пузырёк от лекарств", "Чек из буфета"
        };

        public void Initialize()
        {
            InitializeLocations();
            InitializeStats();
            StartTimer();
            LoadLocation(0);
        }
        private void InitializeStats()
        {
            var player = GameData.CurrentPlayer;
            if (player == null) return;

            switch (player.CharacterTrait)
            {
                case "Харизматичный": charismaValue += 3; break;
                case "Циничный": logicValue += 1; break;
                case "Наблюдательный": attentionValue += 2; break;
                case "Эмпатичный": charismaValue += 1; break;
                case "Бесстрашный": resolveValue += 3; break;
                case "Педантичный": logicValue += 2; break;
            }

            if (player.Role == "Частный детектив") logicValue += 1;
            if (player.Role == "Журналист") charismaValue += 1;

            switch (player.InventorySlot)
            {
                case "Диктофон": logicValue += 1; break;
                case "Старое удостоверение": charismaValue += 1; break;
                case "Наручные часы": logicValue += 1; break;
                case "Лупа": attentionValue += 1; break;
                case "Отмычки": logicValue += 1; break;
                case "Фото близкого человека": resolveValue += 1; break;
            }

            switch (player.Contact)
            {
                case "Бывший напарник":
                    OnLogAdded?.Invoke("Бывший напарник: «Лика недавно жаловалась на домогательства Верховского.»");
                    AddClue("Заявление в полицию");
                    AddStat("logic", ref logicValue, 1);  // +1 к логике
                    break;
                case "Хакер":
                    OnLogAdded?.Invoke("Хакер: «В телефоне Верховского угрозы в адрес Лики.»");
                    AddClue("Переписка Верховского с угрозами");
                    AddStat("attention", ref attentionValue, 1);  // +1 к внимательности
                    break;
                case "Бармен":
                    OnLogAdded?.Invoke("Бармен: «Лика была в тот вечер там.»");
                    AddClue("Показания бармена");
                    AddStat("charisma", ref charismaValue, 1);  // +1 к харизме
                    break;
                case "Адвокат":
                    OnLogAdded?.Invoke("Адвокат: «Проверьте склад, там Лика что-то прятала.»");
                    AddClue("Орудие убийства");
                    AddStat("resolve", ref resolveValue, 1);  // +1 к решимости
                    break;
            }

            resolveValue = Math.Min(resolveValue, 5);
            attentionValue = Math.Min(attentionValue, 5);
            logicValue = Math.Min(logicValue, 5);
            charismaValue = Math.Min(charismaValue, 5);

            OnStatChanged?.Invoke("resolve", resolveValue);
            OnStatChanged?.Invoke("attention", attentionValue);
            OnStatChanged?.Invoke("logic", logicValue);
            OnStatChanged?.Invoke("charisma", charismaValue);

        }

        private void StartTimer()
        {
            timeValue = 100;
            OnTimeChanged?.Invoke(timeValue);

            locationTimer = new System.Timers.Timer();
            locationTimer.Interval = 1800;
            locationTimer.Elapsed += OnTimerTick;
            locationTimer.AutoReset = true;
            locationTimer.Start();
        }

        private void OnTimerTick(object sender, ElapsedEventArgs e)
        {
            timeValue -= 1;
            OnTimeChanged?.Invoke(timeValue);

            if (timeValue <= 0)
            {
                locationTimer.Stop();
                OnLogAdded?.Invoke("⏰ Время вышло! Игра окончена.");
                OnGameOver?.Invoke();
            }
        }

        private void CheckIfLocationCompleted()
        {
            //локация завершена, если выполнено хоть одно действие
            var currentActions = locations[currentLocationIndex].Actions;
            int completedCount = 0;


            if (completedCount > 0 && !locations[currentLocationIndex].IsFinal)
            {
                OnLogAdded?.Invoke("Вы сделали всё в этой локации. Нажмите «Далее» для продолжения.");
            }
        }

        private void InitializeLocations()
        {
            locations = new List<Location>();

            //первая локация закулисье
            locations.Add(new Location
            {
                Name = "Закулисье",
                Description = "ВЫ В ЛОКАЦИИ: ЗАКУЛИСЬЕ\n\n" +
                "Вы находитесь за кулисами театра. Здесь произошло убийство.\n" +
                "Тело уже увезли, но следы крови ещё видны.\n\n" +
                "Что делаете?",
                Actions = new List<LocationAction>()
                {
                    new LocationAction
                    {
                        Text = "Осмотреть место у тела (Внимательность 2+)",
                        Action = ExamineCrimeScene,
                        RequiredStat = "attention",
                        RequiredValue = 2,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Следы Лики",
                        Description = "Вы находите следы профессиональной косметики, которой пользуется только гримёр. Но странно — ею пользуется и помощница режиссёра Лика."
                    },
                    new LocationAction {
                        Text = "Осмотреть гримёрные столы",
                        Action = SearchMakeupTables,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы осматриваете столы, но находите только старые журналы. Ничего полезного."
                    },
                    new LocationAction
                    {
                        Text = "Поговорить с Колей (осветитель)",
                        Action = TalkToKolya,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Разбитое зеркало",
                        Description = "Коля (осветитель): «Я видел, как из ложи выбежала Лика! Она была бледная и вся дрожала. А зеркало уже было разбито, когда она выходила — осколки внутри."
                    },
                    new LocationAction
                    {
                        Text = "Проявить смекалку",
                        Action = GainResolve,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы нестандартно мыслите и приходите к важному логическому выводу о Лике!"
                    }
                },
                IsFinal = false,
                ImageName = "Zakulisie"
            });

            //гримёрка Евы
            locations.Add(new Location
            {
                Name = "Гримёрка Евы",
                Description = "ВЫ В ЛОКАЦИИ: ГРИМЁРКА ЕВЫ\n\n" +
                    "Вы в гримёрке Евы. Пахнет духами и пылью.\n" +
                    "На стуле висит чёрное платье, на столике — парики и грим.\n\n" +
                    "Что делаете?",
                Actions = new List<LocationAction>
                {
                    new LocationAction
                    {
                        Text = "Посмотреть в шкаф с костюмами",
                        Action = LookInCloset,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы открываете шкаф, но там только платья и туфли Евы. Ничего подозрительного."
                    },
                    new LocationAction
                    {
                        Text = "Обыскать гримёрку (Решимость 1+)",
                        Action = SearchDressingRoom,
                        RequiredStat = "resolve",
                        RequiredValue = 1,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Любовное письмо",
                        Description = "Вы набираетесь решимости и тщательно обыскиваете каждый уголок гримёрки. Под грудой париков вы находите письмо от Михаила Стеклова! «Любимая, я избавлюсь от него. Он не заслуживает тебя. Скоро мы будем вместе.»"
                    },
                    new LocationAction {
                        Text = "Допросить Еву (Харизма 2+)",
                        Action = InterrogateEva,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Каблук Евы",
                        Description = "Ева: «Михаил говорил, что убьёт его! Но он трус. Он только болтал. А я... я просто хотела, чтобы он ушёл из театра."
                    }
                },
                IsFinal = false,
                ImageName = "Grimerka"
            });

            //кабинет Верховского
            locations.Add(new Location
            {
                Name = "Кабинет Верховского",
                Description = "ВЫ В ЛОКАЦИИ: КАБИНЕТ ВЕРХОВСКОГО\n\n" +
                    "Вы в кабинете режиссёра. Солидная обстановка,\n" +
                    "книги, сценарии. В углу стоит сейф.\n\n" +
                    "Что делаете?",
                Actions = new List<LocationAction>
                {
                    new LocationAction {
                        Text = "Обыскать письменный стол",
                        Action = SearchDesk,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Билет Пожарского",
                        Description = "В столе вы находите билет на имя Пожарского. Он был в театре в день убийства."
                    },
                    new LocationAction {
                        Text = "Осмотреть картины на стенах",
                        Action = ExaminePaintings,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы осматриваете картины, но за ними только стена. Ничего интересного."
                    },
                    new LocationAction {
                        Text = "Открыть сейф (Логика 3+)",
                        Action = OpenSafe,
                        RequiredStat = "logic",
                        RequiredValue = 3,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Документы Пожарского и личный дневник Верховского",
                        Description = "Вы открываете сейф! Внутри — документы о коррупции чиновника Пожарского. Верховский собирался его шантажировать. Также вы находите личный дневник, где Верховский записал: «Лика слишком много знает. Надо от неё избавиться. Но сначала пусть работает». Похоже, он планировал уволить Лику, и она об этом узнала."
                    }
                },
                IsFinal = false,
                ImageName = "Kabinet"
            });

            //костюмерная
            locations.Add(new Location
            {
                Name = "Костюмерная",
                Description = "ВЫ В ЛОКАЦИИ: КОСТЮМЕРНАЯ\n\n" +
                    "Вы в костюмерной. Вокруг висят костюмы разных эпох.\n" +
                    "Зинаида, пожилая костюмерша, перебирает вещи.\n\n" +
                    "Что делаете?",
                Actions = new List<LocationAction>
                {
                    new LocationAction {
                        Text = "Померить старый костюм",
                        Action = TryCostume,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы примеряете старинный камзол, но это просто трата времени. Зинаида смотрит на вас с недоумением."
                    },
                    new LocationAction {
                        Text = "Обыскать костюмерную (Внимательность 2+)",
                        Action = SearchCostumeRoom,
                        RequiredStat = "attention",
                        RequiredValue = 2,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Пятно крови",
                        Description = "Вы находите плащ Веры с пятнами крови! Но Зинаида говорит, что это старая краска для спектакля. Вера не убивала."
                    },
                    new LocationAction {
                        Text = "Поговорить с Зинаидой",
                        Action = TalkToZinaida,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Показания Зинаиды",
                        Description = "Зинаида: «Я видела, как Лика вытирала руки о тряпку в день убийства. А потом она спрятала что-то в подсобке на складе. Странная она в последнее время..."
                    }
                },
                IsFinal = false,
                ImageName = "Kostumerskaya"
            });

            //буфет
            locations.Add(new Location
            {
                Name = "Буфет",
                Description = "ВЫ В ЛОКАЦИИ: БУФЕТ\n\n" +
                    "Вы заходите в театральный буфет. Здесь пусто,\n" +
                    "только старушка-буфетчица протирает стойку.\n" +
                    "В углу стоит столик, за которым обычно сидел Михаил.\n\n" +
                    "Что делаете?",
                Actions = new List<LocationAction>
                {
                    new LocationAction {
                        Text = "Осмотреть столик Михаила (Внимательность 1+)",
                        Action = ExamineMikhailTable,
                        RequiredStat = "attention",
                        RequiredValue = 1,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Пузырёк от лекарств",
                        Description = "Под столиком вы находите пустой пузырёк из-под лекарств. Михаил принимал успокоительное. Он был на грани, но это не делает его убийцей."
                    },
                    new LocationAction {
                        Text = "Поговорить с буфетчицей",
                        Action = TalkToBarmaid,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Чек из буфета",
                        Description = "Буфетчица: «Михаил должен был Верховскому крупную сумму. Он повторял: \"Я его ненавижу, но я не убийца\". Похоже, он просто болтал от отчаяния."
                    },
                    new LocationAction {
                        Text = "Расспросить буфетчицу о Лике (Харизма 1+)",
                        Action = AskAboutLika,
                        RequiredStat = "charisma",
                        RequiredValue = 1,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Слухи о Лике",
                        Description = "Вы проявляете харизму, и буфетчица доверительно сообщает: «Лика в последнее время была сама не своя. Вечно нервная, на всех срывалась. А в день убийства я видела, как она вытирала руки о тряпку. Очень подозрительно...»"
                    }
                },
                IsFinal = false,
                ImageName = "Bufet"
            });

            //склад реквизита
            locations.Add(new Location
            {
                Name = "Склад реквизита",
                Description = "ВЫ В ЛОКАЦИИ: СКЛАД РЕКВИЗИТА\n\n" +
                    "Тёмное пыльное помещение, заставленное старыми декорациями.\n" +
                    "Здесь хранятся вещи со старых спектаклей.\n" +
                    "Вряд ли тут можно что-то найти...\n\n" +
                    "Что делаете?",
                Actions = new List<LocationAction>
                {
                    new LocationAction
                    {
                        Text = "Выйти и поискать дальше",
                        Action = WasteTime,
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = "Вы решаете не тратить время на склад и выходите. Ничего не найдено."
                    },
                    new LocationAction
                    {
                        Text = "Позвать кого-нибудь (Харизма 1+)",
                        Action = CallSomeone,
                        RequiredStat = "charisma",
                        RequiredValue = 1,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Подсказка Коли",
                        Description = "Благодаря вашей харизме, Коля охотнее рассказывает: «Я не хотел говорить, но видел, как Лика прятала что-то в старом сундуке. Загляните туда!»"
                    },
                    new LocationAction {
                        Text = "Осмотреть склад (Внимательность 3+)",
                        Action = SearchStorage,
                        RequiredStat = "attention",
                        RequiredValue = 3,
                        IsHidden = false,
                        GivesClue = true,
                        ClueName = "Орудие убийства",
                        Description = "Вы открываете старый сундук и находите окровавленный театральный кинжал! На рукоятке вырезано имя «Лика». Это её личный реквизит. Она не просто прятала его — она убила."
                    }
                },
                IsFinal = false,
                ImageName = "Sklad"
            });

            //финал
            locations.Add(new Location
            {
                Name = "ФИНАЛ",
                Description = "ВЫ В ФИНАЛЬНОЙ ЛОКАЦИИ\n\n" +
                    "Вы собрали улики и готовы назвать убийцу.\n" +
                    "Кто же настоящий преступник?\n\n" +
                    "Выберите подозреваемого:",
                Actions = new List<LocationAction>
                {
                    new LocationAction
                    {
                        Text = "Ева Литинская (актриса)",
                        Action = () => Accuse("Ева Литинская"),
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = null
                    },
                    new LocationAction {
                        Text = "Михаил Стеклов (драматург)",
                        Action = () => Accuse("Михаил Стеклов"),
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = null
                    },
                    new LocationAction {
                        Text = "Вера Полозова (завлит)",
                        Action = () => Accuse("Вера Полозова"),
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = null
                    },
                    new LocationAction {
                        Text = "Лика (помощница режиссёра)",
                        Action = () => Accuse("Лика"),
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = null
                    },
                    new LocationAction {
                        Text = "Виктор Пожарский (чиновник)",
                        Action = () => Accuse("Виктор Пожарский"),
                        RequiredStat = null,
                        RequiredValue = 0,
                        IsHidden = false,
                        GivesClue = false,
                        ClueName = null,
                        Description = null
                    }
                },

                IsFinal = true,
                ImageName = "Final"
            });


        }

        private void LoadLocation(int index)
        {
            if (index >= locations.Count) return;
            currentLocationIndex = index;
            isLocationCompleted = false;

            var location = locations[index];

            OnLocationLoaded?.Invoke(location.Description);
            OnActionsUpdated?.Invoke(location.Actions);
            OnLocationListUpdated?.Invoke(location.Name);

            OnImageChanged?.Invoke(location.ImageName ?? location.Name, location.Name);
        }

        private void AddClue(string clue)
        {
            if (!foundClues.Contains(clue))
            {
                foundClues.Add(clue);

                if (realClues.Contains(clue))
                {
                    cluesValue = Math.Min(6, cluesValue + 1);
                    OnCluesChanged?.Invoke(cluesValue);
                }
                OnLogAdded?.Invoke($"УЛИКА НАЙДЕНА: {clue}");
            }
        }

        private void AddTime(int delta)
        {
            timeValue = Math.Max(0, Math.Min(100, timeValue + delta));
            OnTimeChanged?.Invoke(timeValue);
        }

        private void AddStat(string statName, ref int statValue, int delta)
        {
            statValue = Math.Min(5, statValue + delta);
            OnStatChanged?.Invoke(statName, statValue);
        }

        //действия
        private void ExamineCrimeScene()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы внимательно осматриваете место у тела...");
            OnLogAdded?.Invoke("На полу возле стола вы замечаете мелкие блестящие частицы. При ближайшем рассмотрении это профессиональная театральная косметика — тональный крем и блестки для грима.");
            OnLogAdded?.Invoke("Такой косметикой пользуется только гримёр театра, но, по словам Коли, её часто брала и Лика — помощница режиссёра.");
            AddClue("Следы косметики");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void SearchMakeupTables()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы осматриваете гримёрные столы...");
            OnLogAdded?.Invoke("На столах разбросаны кисти, баночки с тоналкой, палитры теней. Всё в полном беспорядке, но ничего необычного вы не находите.");
            OnLogAdded?.Invoke("Похоже, здесь нет ничего полезного для расследования.");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void TalkToKolya()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы подходите к Коле, молодому осветителю. Он нервничает и постоянно оглядывается.");
            OnLogAdded?.Invoke("— Вера Полозова была странная в тот вечер. Она точила кинжал для спектакля, но зачем-то принесла его в ложу.");
            OnLogAdded?.Invoke("Коля явно напуган и не хочет больше ничего рассказывать.");
            AddClue("Показания Коли");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void GainResolve()
        {
            if (resolveGained) return;
            AddTime(-10);
            resolveGained = true;
            AddStat("resolve", ref resolveValue, 1);

            OnLogAdded?.Invoke("Вы догадались: Лика разбила зеркало, когда выбегала из ложи!");
            AddClue("Отпечатки Лики на зеркале");

            isLocationCompleted = true;
            OnLogAdded?.Invoke("Можно переходить дальше!");
        }

        private void LookInCloset()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы открываете шкаф с костюмами...");
            OnLogAdded?.Invoke("Внутри висят платья разных эпох, туфли и шляпы. Всё аккуратно развешано, ничего подозрительного.");
            OnLogAdded?.Invoke("Похоже, здесь нет никаких улик.");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void SearchDressingRoom()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы набираетесь решимости и тщательно обыскиваете каждый уголок гримёрки...");
            OnLogAdded?.Invoke("Под грудой старых париков вы находите свёрнутый лист бумаги. Развернув его, вы читаете:");
            OnLogAdded?.Invoke("«Любимая, я избавлюсь от него. Он не заслуживает тебя. Скоро мы будем вместе. Твой Михаил».");
            OnLogAdded?.Invoke("Это любовное письмо от Михаила Стеклова! Похоже, у них с Евой был роман, и Михаил обещал ей избавиться от Верховского.");
            AddClue("Любовное письмо");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void InterrogateEva()
        {
            if (isLocationCompleted) return;
            AddTime(-10);

            if (charismaValue >= 2)
            {
                OnLogAdded?.Invoke("Вы уверенно задаёте вопросы Еве, используя свою харизму. Она нервничает, теребит край платья.");
                OnLogAdded?.Invoke("— Михаил говорил, что убьёт его! — выпаливает она. — Но он трус. Он только болтал.");
                OnLogAdded?.Invoke("Ева оговаривает Михаила из ревности. Он действительно ненавидел Верховского, но не убивал."); ;
                AddClue("Признание Евы");
            }
            else
            {
                OnLogAdded?.Invoke("Вы пытаетесь допросить Еву, но она отвечает уклончиво:");
                OnLogAdded?.Invoke("— Я ничего не знаю. Оставьте меня в покое. У меня спектакль.");
                OnLogAdded?.Invoke("Вам не хватает харизмы, чтобы разговорить её.");
            }

            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void SearchDesk()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы обыскиваете письменный стол Верховского...");
            OnLogAdded?.Invoke("В верхнем ящике вы находите билет на имя Виктора Пожарского — чиновника из департамента культуры.");
            OnLogAdded?.Invoke("Пожарский был в театре в день убийства.");
            AddClue("Билет Пожарского");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void ExaminePaintings()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы осматриваете картины на стенах...");
            OnLogAdded?.Invoke("Это портреты известных актёров прошлого. За картинами — только голые стены.");
            OnLogAdded?.Invoke("Ничего интересного для расследования.");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void OpenSafe()
        {
            if (isLocationCompleted) return;
            AddTime(-10);

            if (logicValue >= 3)
            {
                OnLogAdded?.Invoke("Вы внимательно изучаете замок и вспоминаете стандартные коды. После нескольких попыток сейф поддаётся!");
                OnLogAdded?.Invoke("Внутри вы находите папку с документами:");
                OnLogAdded?.Invoke("— Документы о коррупции чиновника Пожарского — взятки, фиктивные контракты.");
                OnLogAdded?.Invoke("— Личный дневник Верховского с записью: «Лика стала опасна. Уволить её после премьеры».");
                OnLogAdded?.Invoke("Получается, у Лики был веский мотив — она знала, что её уволят!");
                AddClue("Документы Пожарского");
            }
            else
            {
                OnLogAdded?.Invoke("Не хватает логики или отмычек!");
            }
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void TryCostume()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы решаете примерить старинный камзол...");
            OnLogAdded?.Invoke("Зинаида смотрит на вас с недоумением. Камзол вам велик, да и пользы от этого никакой.");
            OnLogAdded?.Invoke("Вы только теряете время.");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void SearchCostumeRoom()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы обыскиваете костюмерную...");
            OnLogAdded?.Invoke("За вешалками с платьями вы находите плащ Веры. На нём тёмные пятна, похожие на кровь.");
            OnLogAdded?.Invoke("Вы показываете находку Зинаиде. Она качает головой:");
            OnLogAdded?.Invoke("— Это старая краска для спектакля «Макбет».");
            AddClue("Пятно крови");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void TalkToZinaida()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы подходите к Зинаиде, пожилой костюмерше. Она шепчет, оглядываясь по сторонам:");
            OnLogAdded?.Invoke("— Я видела, как Лика спрятала что-то в подсобке на складе.");
            AddClue("Показания Зинаиды");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void ExamineMikhailTable()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы осматриваете столик, за которым обычно сидел Михаил...");
            OnLogAdded?.Invoke("Под столиком вы находите пустой пузырёк из-под успокоительного.");
            OnLogAdded?.Invoke("Похоже, Михаил принимал лекарства от нервов. Он был на грани, но это не делает его убийцей.");
            AddClue("Пузырёк от лекарств");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void TalkToBarmaid()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы разговариваете с буфетчицей. Она охотно делится сплетнями:");
            OnLogAdded?.Invoke("— Михаил должен был Верховскому крупную сумму. Он повторял: «Я его ненавижу, но я не убийца».");
            AddClue("Чек из буфета");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void AskAboutLika()
        {
            if (isLocationCompleted) return;
            AddTime(-10);

            OnLogAdded?.Invoke("Вы проявляете харизму и расспрашиваете буфетчицу о Лике.");
            OnLogAdded?.Invoke("Буфетчица: «Лика в последнее время была сама не своя. Вечно нервная, на всех срывалась.");
            AddClue("Слухи о Лике");

            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void WasteTime()
        {
            if (isLocationCompleted) return;
            AddTime(-10);
            OnLogAdded?.Invoke("Вы решаете не тратить время на склад и выходите...");
            OnLogAdded?.Invoke("Но потом понимаете, что могли упустить важную улику. Слишком поздно.");
            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void CallSomeone()
        {
            if (isLocationCompleted) return;
            AddTime(-10);

            if (charismaValue >= 1)
            {
                OnLogAdded?.Invoke("Вы зовёте Колю и проявляете харизму, чтобы разговорить его.");
                OnLogAdded?.Invoke("— Ладно, скажу... — шепчет он. — Я видел, как Лика прятала что-то в старом сундуке. Загляните туда!");
                AddClue("Подсказка Коли");
            }
            else
            {
                OnLogAdded?.Invoke("Вы зовёте Колю, но он лишь отмахивается:");
                OnLogAdded?.Invoke("— На складе ничего нет, я уже всё проверил.");
                OnLogAdded?.Invoke("Вам не хватает харизмы, чтобы разговорить его.");
            }

            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        private void SearchStorage()
        {
            if (isLocationCompleted) return;
            AddTime(-10);

            if (attentionValue >= 3)
            {
                OnLogAdded?.Invoke("Вы внимательно осматриваете каждый уголок склада...");
                OnLogAdded?.Invoke("В старом пыльном сундуке, заваленном тряпьём, вы находите окровавленный театральный кинжал!");
                OnLogAdded?.Invoke("На рукоятке вырезано имя «Лика». Это её личный реквизит.");
                OnLogAdded?.Invoke("Сомнений нет — Лика убила Верховского и спрятала орудие здесь.");
                AddClue("Орудие убийства");
            }
            else
            {
                OnLogAdded?.Invoke("Вы осматриваете склад, но ничего не находите.");
                OnLogAdded?.Invoke($"Нужна внимательность 3+ (у вас {attentionValue}), чтобы заметить детали.");
            }

            isLocationCompleted = true;
            OnLogAdded?.Invoke("Теперь можно переходить в следующую локацию!");
        }

        //обвинения
        private void Accuse(string suspect)
        {
            AddTime(-10);
            int realCluesFound = 0;
            foreach (string clue in realClues)
                if (foundClues.Contains(clue)) realCluesFound++;

            if (suspect == "Лика")
            {
                if (realCluesFound >= 3)
                {
                    OnLogAdded?.Invoke("Лика признаётся! ПОБЕДА!");
                    OnVictory?.Invoke();
                }
                else
                {
                    OnLogAdded?.Invoke("Недостаточно улик. Лика отрицает.");
                    OnGameOver?.Invoke();
                }
            }
            else
            {
                OnLogAdded?.Invoke($"Вы обвинили {suspect}. Это ошибка!");
                OnGameOver?.Invoke();
            }
        }

        //следующая локация
        public void GoToNextLocation()
        {
            if (!isLocationCompleted)
            {
                OnLogAdded?.Invoke("Сначала выполните хотя бы одно действие в этой локации!");
                return;
            }

            if (currentLocationIndex + 1 < locations.Count)
            {
                currentLocationIndex++;

                timeValue = 100;
                OnTimeChanged?.Invoke(timeValue);

                LoadLocation(currentLocationIndex);
                OnLogAdded?.Invoke($"\nПереход в локацию: {locations[currentLocationIndex].Name}\n");
            }
            else
            {
                OnLogAdded?.Invoke("Это была последняя локация.");
            }
        }

        public void UseContact(string contact)
        {
            if (contactUsed)
            {
                OnLogAdded?.Invoke("Вы уже использовали свой контакт.");
                return;
            }

            contactUsed = true;
            AddTime(-5);
        }

        public string GetInventoryDisplay(string item)
        {
            switch (item)
            {
                case "Диктофон": return "ДИКТОФОН\nЗапись разговоров\nБонус: +1 к Логике";
                case "Старое удостоверение": return "СТАРОЕ УДОСТОВЕРЕНИЕ\nДоступ в закрытые места\nБонус: +1 к Харизме";
                case "Наручные часы": return "НАРУЧНЫЕ ЧАСЫ\nПроверка алиби\nБонус: +1 к Логике";
                case "Лупа": return "ЛУПА\nПоиск улик\nБонус: +1 к Внимательности";
                case "Отмычки": return "ОТМЫЧКИ\nОткрытие замков\nБонус: +1 к Логике";
                case "Фото близкого человека": return "ФОТО БЛИЗКОГО ЧЕЛОВЕКА\n+1 к Решимости (1 раз)";
                default: return "Предмет не выбран";
            }
        }

        public List<string> GetClueStatus()
        {
            var result = new List<string>();
            foreach (string clue in foundClues)
            {
                result.Add($"• {clue}");
            }

            if (result.Count == 0)
            {
                result.Add("Пока нет найденных улик.");
            }
            return result;
        }

        public bool IsActionAvailable(LocationAction action)
        {
            if (string.IsNullOrEmpty(action.RequiredStat)) return true;

            int currentValue = 0;
            switch (action.RequiredStat)
            {
                case "attention": currentValue = attentionValue; break;
                case "logic": currentValue = logicValue; break;
                case "charisma": currentValue = charismaValue; break;
                case "resolve": currentValue = resolveValue; break;
            }

            return currentValue >= action.RequiredValue;
        }

        public void UseDictaphone()
        {
            AddTime(-5);
            OnLogAdded?.Invoke("Вы используете диктофон. Запись разговоров поможет вам позже переслушать показания.");
        }

    }
}
