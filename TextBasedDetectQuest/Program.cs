using System;
using System.Windows.Forms;


namespace TextBasedDetectQuest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //визуальные стили, чтобы кнопки не были плоскими
            Application.EnableVisualStyles();
            //режим рендеринга текста
            Application.SetCompatibleTextRenderingDefault(false);

            //объект формы вступления
            using (var intro = new FormIntro())
            {
                intro.ShowDialog(); //закрыть окно чтобы продолжить, код ниже не выполняется, пока окно не закроют и все окна блокируются
            } //.Dispose() срабатывает автоматически (удаление из памяти после закрытия)

            using (var creation = new FormCharacterCreation()) //объект создания персонажа
            {
                creation.ShowDialog();
            }

            //игра, запуск только если персонаж создан
            if (GameData.CurrentPlayer != null)
            {
                Application.Run(new FormGame());
            }
        }
    }
}