using CornerShop.Text.Data;

namespace CornerShop.Text.Scenes
{
    public interface IGameDataService
    {
        IEnumerable<GameData> LoadGames();
        void SaveGame(GameData gameData);
        void DeleteGame(Guid id);
    }
}