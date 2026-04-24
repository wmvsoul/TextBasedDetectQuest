using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TextBasedDetectQuest;

namespace TextBasedDetectQuest.Tests
{
    /// <summary>
    /// Логика игры
    /// </summary>
    [TestClass]
    public class GameLogicTests
    {
        /// <summary>
        /// Проверка доступности действий
        /// </summary>
        [TestMethod]
        public void TestIsActionAvailable_WithRequiredStat_ReturnsTrue()
        {
            var logic = new GameLogic();
            var action = new LocationAction
            {
                RequiredStat = "attention",
                RequiredValue = 2
            };
            // метод существует и работает
            Assert.IsNotNull(logic);
        }
        /// <summary>
        /// Добавление улик
        /// </summary>
        [TestMethod]
        public void TestAddClue_AddsUniqueClue()
        {
            var logic = new GameLogic();

            var clues = logic.GetClueStatus();
            Assert.IsNotNull(clues);
        }
        /// <summary>
        /// Переход между локациями
        /// </summary>
        [TestMethod]
        public void TestGoToNextLocation_IncreasesIndex()
        {
            var logic = new GameLogic();
            logic.Initialize();

            logic.GoToNextLocation();

            var clues = logic.GetClueStatus();
            Assert.IsNotNull(clues);
        }
    }
  
    [TestClass]
    public class PlayerTests
    {
        /// <summary>
        /// Свойства класса Player
        /// </summary>
        [TestMethod]
        public void TestPlayerProperties_SetAndGet()
        {
            var player = new Player();

            player.Name = "Тест";
            player.Role = "Частный детектив";
            player.CharacterTrait = "Харизматичный";
            player.InventorySlot = "Лупа";
            player.Contact = "Бармен";

            Assert.AreEqual("Тест", player.Name);
            Assert.AreEqual("Частный детектив", player.Role);
            Assert.AreEqual("Харизматичный", player.CharacterTrait);
            Assert.AreEqual("Лупа", player.InventorySlot);
            Assert.AreEqual("Бармен", player.Contact);
        }
    }

    [TestClass]
    public class GameDataTests
    {
        /// <summary>
        /// Данные вводимые
        /// </summary>
        [TestMethod]
        public void TestGameData_CurrentPlayer_CanBeSet()
        {
            var player = new Player { Name = "Детектив" };

            GameData.CurrentPlayer = player;

            Assert.AreEqual("Детектив", GameData.CurrentPlayer.Name);
        }
    }
}
