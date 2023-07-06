using CornerShop.Text.UI;
using Microsoft.Extensions.DependencyInjection;

namespace CornerShop.Text
{
    public delegate TScene Factory<TScene>();

    public static class DependencyInjectionUtilities
    {
        public static IServiceCollection AddFactory<TService>(this IServiceCollection services)
            where TService : class
        {
            return services.AddSingleton<Factory<TService>>(s => () => s.GetRequiredService<TService>());
        }

        public static IServiceCollection AddScene<TImplementation>(this IServiceCollection services)
            where TImplementation : class, IScene
        {
            return services
                .AddTransient<TImplementation>()
                .AddFactory<TImplementation>();
        }
    }
}
