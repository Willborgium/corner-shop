using CornerShop.Text.Data;
using CornerShop.Text.UI;

namespace CornerShop.Text.Scenes
{
    public class GameHomeMenuScene : MenuScene
    {
        public GameHomeMenuScene(
            ISceneManager SceneManager,
            IResourceManager resourceManager,
            IGameDataService gameDataService)
            : base("Home", SceneManager)
        {
            _resourceManager = resourceManager;
            _gameDataService = gameDataService;
        }

        public override void Initialize()
        {
            AddOption("Save", OnSave);

            _gameData = _resourceManager.Get<GameData>(KnownResources.CurrentGameData);

            AddLabel($"Game {_gameData.Id}");

            base.Initialize();
        }

        private void OnSave()
        {
            _gameDataService.SaveGame(_gameData);
        }

        private readonly IResourceManager _resourceManager;
        private readonly IGameDataService _gameDataService;
        private GameData? _gameData;
    }
}