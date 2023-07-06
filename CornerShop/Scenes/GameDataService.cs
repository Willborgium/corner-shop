using CornerShop.Text.Data;
using Newtonsoft.Json;

namespace CornerShop.Text.Scenes
{
    public class GameDataService : IGameDataService
    {
        public IEnumerable<GameData> LoadGames()
        {
            if (!Path.Exists(_gameDataPath))
            {
                using (var writer = new StreamWriter(_gameDataPath))
                {
                    writer.WriteLine("[]");
                }

                return Enumerable.Empty<GameData>();
            }

            string serializedGames;

            using (var reader = new StreamReader(_gameDataPath))
            {
                serializedGames = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<GameData>>(serializedGames) ?? Enumerable.Empty<GameData>();
        }

        public void SaveGame(GameData gameData)
        {
            var games = LoadGames().ToList();

            var matched = games.FirstOrDefault(g => g.Id == gameData.Id);

            if (matched != null)
            {
                games.Remove(matched);
            }

            games.Add(gameData);

            SaveGames(games);
        }

        public void DeleteGame(Guid id)
        {
            var games = LoadGames().ToList();

            var matched = games.FirstOrDefault(g => g.Id == id);

            if (matched != null)
            {
                games.Remove(matched);
            }

            SaveGames(games);
        }

        private void SaveGames(IEnumerable<GameData> games)
        {
            var serializedGames = JsonConvert.SerializeObject(games);

            using (var writer = new StreamWriter(_gameDataPath))
            {
                writer.Write(serializedGames);
            }
        }

        private const string _gameDataPath = "game-data";
    }
}