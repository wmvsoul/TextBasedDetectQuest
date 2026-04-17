using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace DetectiveGameLogic
{
    internal class StateManager
    {
        //папка в AppData для хранения файлов игры
        private static string Folder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DetectiveTextGame");
        //путь к файлу состояния
        private static string FilePath => Path.Combine(Folder, "state.json");
        //загрузка состояния файла. файл отсутствует или поврежден - возврат нового объекта по умолчанию
        public static SaveState Load()
        {
            try
            {
                if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
                if (!File.Exists(FilePath)) return new SaveState();
                var json = File.ReadAllText(FilePath);
                //вернёт null, обработает это
                //если слева значение null, то берем справа
                return JsonSerializer.Deserialize<SaveState>(json) ?? new SaveState();
            }
            catch
            {
                //ошибка - возврат дефолт
                return new SaveState();
            }
        }
        //сохранение текущего состояние в файл
        public static void Save(SaveState state)
        {
            try
            {
                if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
                var json = JsonSerializer.Serialize(state, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch
            {
                //чтобы не падала программа, без ошибки
            }
        }
    }
}
