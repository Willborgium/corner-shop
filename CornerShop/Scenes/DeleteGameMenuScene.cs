using CornerShop.Text.Data;
using CornerShop.Text.UI;

namespace CornerShop.Text.Scenes
{
    public class DeleteGameMenuScene : MenuScene
    {
        public DeleteGameMenuScene(
            ISceneManager sceneManager,
            IResourceManager resourceManager,
            IGameDataService gameDataService)
            : base("Delete Game", sceneManager)
        {
            _resourceManager = resourceManager;
            _gameDataService = gameDataService;
        }

        public override void Initialize()
        {
            var games = _gameDataService.LoadGames();

            foreach (var game in games)
            {
                AddOption($"{game.Id}", () => OnConfirmDeleteGame(game));
            }

            base.Initialize();
        }

        private void OnConfirmDeleteGame(GameData game)
        {
            var confirmation = Prompt($"Are your sure you'd like to delete game '{game.Id}'? (Y/n)", false, "Y", "n");

            if (confirmation == "Y")
            {
                _gameDataService.DeleteGame(game.Id);
            }

            _sceneManager.PopScene();
        }

        private readonly IResourceManager _resourceManager;
        private readonly IGameDataService _gameDataService;
    }
}