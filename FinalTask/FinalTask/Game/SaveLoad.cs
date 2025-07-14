using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Game
{
    public class FileSystemSaveLoadService : ISaveLoadService<Player>
    {
        private readonly string _path;

        public FileSystemSaveLoadService(string path)
        {
            _path = path;
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        public void SaveData(Player data, string identifier)
        {
            string filePath = Path.Combine(_path, $"{identifier}.txt");
            File.WriteAllText(filePath, $"{data.Name}|{data.Bank}");
        }

        public Player LoadData(string identifier)
        {
            string filePath = Path.Combine(_path, $"{identifier}.txt");
            if (!File.Exists(filePath))
                return null;

            string[] parts = File.ReadAllText(filePath).Split('|');
            return new Player(parts[0], int.Parse(parts[1]));
        }
    }

}
