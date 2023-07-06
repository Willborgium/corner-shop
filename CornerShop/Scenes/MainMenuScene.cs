using CornerShop.Text.Data;
using CornerShop.Text.UI;

namespace CornerShop.Text.Scenes
{
    public class MainMenuScene : MenuScene
    {

        public MainMenuScene(
            ISceneManager sceneManager,
            IResourceManager resourceManager,
            Factory<GameHomeMenuScene> gameHomeMenuSceneFactory,
            Factory<LoadGameMenuScene> loadGameMenuSceneFactory,
            Factory<DeleteGameMenuScene> deleteGameMenuSceneFactory,
            Factory<MainMenuOptionsScene> mainMenuOptionsSceneFactory)
            : base("Main Menu", sceneManager)
        {
            BackLabel = "Quit";
            _resourceManager = resourceManager;
            _gameHomeMenuSceneFactory = gameHomeMenuSceneFactory;
            _loadGameMenuSceneFactory = loadGameMenuSceneFactory;
            _deleteGameMenuSceneFactory = deleteGameMenuSceneFactory;
            _mainMenuOptionsSceneFactory = mainMenuOptionsSceneFactory;
        }

        public override void Initialize()
        {
            AddOption("New Game", OnNewGame);
            AddOption("Load Game", OnLoadGame);
            AddOption("Delete Game", OnDeleteGame);
            AddOption("Options", OnOptions);

            base.Initialize();
        }

        private void OnNewGame()
        {
            var game = new GameData
            {
                Id = Guid.NewGuid(),
            };

            _resourceManager.Set("game-data", game);

            _sceneManager.PushScene(_gameHomeMenuSceneFactory());
        }

        private void OnLoadGame() => _sceneManager.PushScene(_loadGameMenuSceneFactory());

        private void OnDeleteGame() => _sceneManager.PushScene(_deleteGameMenuSceneFactory());

        private void OnOptions() => _sceneManager.PushScene(_mainMenuOptionsSceneFactory());

        private readonly IResourceManager _resourceManager;
        private readonly Factory<GameHomeMenuScene> _gameHomeMenuSceneFactory;
        private readonly Factory<LoadGameMenuScene> _loadGameMenuSceneFactory;
        private readonly Factory<DeleteGameMenuScene> _deleteGameMenuSceneFactory;
        private readonly Factory<MainMenuOptionsScene> _mainMenuOptionsSceneFactory;
    }
}