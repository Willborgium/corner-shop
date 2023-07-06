using CornerShop.Text.Data;
using CornerShop.Text.Scenes;
using CornerShop.Text.UI;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CornerShop.Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();

                services
                    .AddSingleton<IResourceManager, ResourceManager>()
                    .AddSingleton<SceneManager>()
                    .AddSingleton<ISceneManager>(s => s.GetRequiredService<SceneManager>())
                    .AddSingleton<IGame>(s => s.GetRequiredService<SceneManager>())
                    .AddScoped<IGameDataService, GameDataService>()
                    .AddScene<MainMenuScene>()
                    .AddScene<LoadGameMenuScene>()
                    .AddScene<DeleteGameMenuScene>()
                    .AddScene<MainMenuOptionsScene>()
                    .AddScene<GameHomeMenuScene>();

                using (var provider = services.BuildServiceProvider())
                {
                    var sceneManager = provider.GetRequiredService<ISceneManager>();

                    sceneManager.PushScene(provider.GetRequiredService<MainMenuScene>());

                    var game = provider.GetRequiredService<IGame>();

                    do
                    {
                        game.Update();

                        game.Render();
                    }
                    while (game.IsRunning);
                }
            }
            catch (Exception err)
            {
                var serializedErr = JsonConvert.SerializeObject(err);

                Directory.CreateDirectory("error-logs");

                using (var writer = new StreamWriter($"error-logs/{DateTime.Now.ToFileTime()}.txt"))
                {
                    writer.Write(serializedErr);
                }

                Console.WriteLine("A fatal error has occurred and been logged.");
            }

            Console.WriteLine(">>> Game complete <<<");
        }
    }
}