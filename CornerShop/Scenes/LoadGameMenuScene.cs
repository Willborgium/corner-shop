using CornerShop.Text.Data;
using CornerShop.Text.UI;

namespace CornerShop.Text.Scenes
{
    public class LoadGameMenuScene : MenuScene
    {
        public LoadGameMenuScene(
            ISceneManager sceneManager,
            IResourceManager resourceManager,
            IGameDataService gameDataService,
            Factory<GameHomeMenuScene> homeMenuSceneFactory)
            : base("Load Game", sceneManager)
        {
            _resourceManager = resourceManager;
            _gameDataService = gameDataService;
            _homeMenuSceneFactory = homeMenuSceneFactory;
        }

        public override void Initialize()
        {
            var games = _gameDataService.LoadGames();

            foreach (var game in games)
            {
                AddOption($"{game.Id}", () => OnLoadGame(game));
            }

            base.Initialize();
        }

        private void OnLoadGame(GameData game)
        {
            _resourceManager.Set(KnownResources.CurrentGameData, game);

            _sceneManager.SetScene(_homeMenuSceneFactory(), false);
        }

        private readonly IResourceManager _resourceManager;
        private readonly IGameDataService _gameDataService;
        private readonly Factory<GameHomeMenuScene> _homeMenuSceneFactory;
    }
}