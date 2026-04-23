using System;
using System.Drawing;
using System.Windows.Forms;

namespace TextBasedDetectQuest
{
    public partial class FormGame : Form
    {
        private GameLogic logic;

        public FormGame()
        {
            InitializeComponent();

            this.FormClosing += FormGame_FormClosing;


            var player = GameData.CurrentPlayer;
            if (player != null)
            {
                lblPlayerName.Text = $"Имя игрока: {player.Name}";
                lblRole.Text = $"Роль игрока: {player.Role}";
                lblCharacterTrait.Text = $"Черта игрока: {player.CharacterTrait}";
            }

            logic = new GameLogic();
            SubscribeToEvents();
            logic.Initialize();
        }

        private bool photoUsed = false;

        private void SubscribeToEvents()
        {
            logic.OnLogAdded += (text) =>
            {
                rtbDescription.AppendText("\n\n" + text + "\n\n");
            };

            logic.OnTimeChanged += (value) =>
                pbTime.Value = value;

            logic.OnCluesChanged += (value) =>
            {
                pbClues.Value = value;
                lblCluesValue.Text = $"{value}/11";
            };

            logic.OnStatChanged += (stat, value) =>
            {
                if (stat == "resolve")
                {
                    pbResolve.Value = value;
                    lblResolveValue.Text = $"{value}/5";
                }
                if (stat == "attention")
                {
                    pbAttention.Value = value;
                    lblAttentionValue.Text = $"{value}/5";
                }
                if (stat == "logic")
                {
                    pbLogic.Value = value;
                    lblLogicValue.Text = $"{value}/5";
                }
                if (stat == "charisma")
                {
                    pbCharisma.Value = value;
                    lblCharismaValue.Text = $"{value}/5";
                }

                logic.OnImageChanged += (imageName, locationName) =>
                {
                    SetLocationImage(imageName);
                };
            };

            logic.OnLocationLoaded += (description) =>
                rtbDescription.Text = description;

            logic.OnLocationListUpdated += (locationName) =>
            {
                UpdateLocationList(locationName);
            };

            logic.OnActionsUpdated += (actions) =>
            {
                flpChoises.Controls.Clear();
                foreach (var action in actions)
                {
                    Button btn = new Button();
                    btn.Text = action.Text;
                    btn.Size = new Size(680, 45);
                    btn.BackColor = Color.FromArgb(180, 140, 80);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Georgia", 10);
                    btn.ForeColor = Color.FromArgb(30, 25, 20);
                    btn.Cursor = Cursors.Hand;

                    //проверка доступности
                    if (!logic.IsActionAvailable(action))
                    {
                        btn.Enabled = false;
                        btn.BackColor = Color.FromArgb(100, 80, 50);
                    }

                    btn.Click += (s, e) => action.Action();
                    flpChoises.Controls.Add(btn);
                }

            };

            logic.OnGameOver += () =>
            {
                MessageBox.Show("Игра окончена.");
                this.Close();
            };

            logic.OnVictory += () =>
            {
                MessageBox.Show("ПОБЕДА!");
                this.Close();
            };
        }

        private void BtnNextLocation_Click(object sender, EventArgs e)
        {
            logic.GoToNextLocation();
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            string item = GameData.CurrentPlayer?.InventorySlot ?? "Нет предмета";
            string display = logic.GetInventoryDisplay(item);
            MessageBox.Show(display, "Инвентарь", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnContact_Click(object sender, EventArgs e)
        {
            string contact = GameData.CurrentPlayer?.Contact ?? "Нет контакта";
            logic.UseContact(contact);
        }

        private void BtnJournal_Click(object sender, EventArgs e)
        {
            var clues = logic.GetClueStatus();
            string message = "ЖУРНАЛ УЛИК\n\n";
            foreach (string clue in clues)
            {
                message += clue + "\n";
            }
            MessageBox.Show(message, "Улики", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUseItem_Click(object sender, EventArgs e)
        {
            string item = GameData.CurrentPlayer?.InventorySlot ?? "Нет предмета";

            if (item == "Фото близкого человека")
            {
                MessageBox.Show("Вы использовали фото близкого человека!\nРешимость +1",
                    "Предмет использован", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Ваш предмет: {item}\nОн даёт пассивный бонус к характеристикам.",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //предупреждение о закрытии игры
        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите выйти?\n\nПрогресс будет потерян.",
                "Выход из игры",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;  // Отменяем закрытие
            }
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            var clues = logic.GetClueStatus();
            string message = "ЖУРНАЛ УЛИК\n\n";
            foreach (string clue in clues)
            {
                message += clue + "\n";
            }
            MessageBox.Show(message, "Улики", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            string item = GameData.CurrentPlayer?.InventorySlot ?? "Нет предмета";
            string contact = GameData.CurrentPlayer?.Contact ?? "Нет контакта";

            string message = "ВАШ ИНВЕНТАРЬ:\n";
            message += $"• {item}\n\n";
            message += "ВАШ КОНТАКТ:\n";
            message += $"• {contact}";

            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnContact_Click_1(object sender, EventArgs e)
        {
            string contact = GameData.CurrentPlayer?.Contact ?? "Нет контакта";
            logic.UseContact(contact);
        }

        private void UpdateLocationList(string currentLocationName)
        {
            listLocation.Items.Clear();

            string[] allLocations = { "Закулисье", "Гримёрка Евы", "Кабинет Верховского",
                               "Костюмерная", "Буфет", "Склад реквизита", "ФИНАЛ" };

            foreach (var loc in allLocations)
            {
                if (loc == currentLocationName)
                    listLocation.Items.Add($"▶ {loc}");
                else
                    listLocation.Items.Add(loc);
            }
        }

        private void btnNextLocation_Click_1(object sender, EventArgs e)
        {
            logic.GoToNextLocation();
        }
        //вставка картинок
        private void SetLocationImage(string imageName)
        {
            try
            {
                //путь к папке
                string imagePath = Path.Combine(Application.StartupPath, "Images", $"{imageName}.png");

                if (File.Exists(imagePath))
                {
                    pbLocation.Image = Image.FromFile(imagePath);
                    pbLocation.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //если картинки нет
                    pbLocation.Image = null;
                    pbLocation.BackColor = Color.FromArgb(40, 40, 50);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки картинки: {ex.Message}");
                pbLocation.Image = null;
            }
        }
    }
}