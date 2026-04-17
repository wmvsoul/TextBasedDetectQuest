using System;
using System.Collections.Generic;
using System.Text;
namespace DetectiveGameLogic
{
    public class SaveState
    {
        //вступление было ли оно показано
        public bool IntroShown { get; set; } = false;
        //создан персонаж, если false показывается форма создания персонажа
        public bool CharacterCreated { get; set; } = false;
        //имя персонажа
        public string PlayerName { get; set; }
        //роль персонажа
        public string PlayerRole { get; set; }
        //черта персонажа
        public string Trait {  get; set; }
        //инвентарь массив строк, заменяется на список объектов
        public string[] Inventory { get; set; } = new string[0];
        //сложность легко нормально сложно
        public string Difficulty { get; set; }
        //завершение игры (победа/поражение)
        public bool GameCompleted { get; set; } = false;
    }
}
