using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Personas.Services;
using Personas.ViewModels;
using Personas.Pages;

namespace Personas;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // ✅ REGISTRAR SERVICIOS Y VIEWMODELS
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<PeopleViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<PeoplePage>();

        return builder.Build();
    }
}
