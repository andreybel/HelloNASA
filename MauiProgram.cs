using HelloMauiApp.Interfaces;
using HelloMauiApp.Services;
using HelloMauiApp.ViewModels;

namespace HelloMauiApp;

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

		builder.Services.AddSingleton<INetworkService,NetworkService>();
		builder.Services.AddTransient<IDataService,DataService>();

		return builder.Build();
	}
}
