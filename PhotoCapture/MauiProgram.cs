using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PhotoCapture;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        var baseURL = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5074/" : "https://localhost:7284/";
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri($"{baseURL}") });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<FileStorageService>();
        builder.Services.AddSingleton<ConnectivityService>();

        return builder.Build();
    }
}
