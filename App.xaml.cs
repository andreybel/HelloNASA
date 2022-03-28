using HelloMauiApp.Interfaces;

namespace HelloMauiApp;

public partial class App : Application
{
    public static IServiceProvider serviceProvider { get; set; }
    public App(IServiceProvider sp)
	{
		InitializeComponent();

        serviceProvider = sp;
		MainPage = new NavigationPage(new MainPage());
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        // Workaround for: 'Either set MainPage or override CreateWindow.'??
        if (this.MainPage == null)
        {
            this.MainPage = new NavigationPage(new MainPage());
        }

        return base.CreateWindow(activationState);
    }

    protected override void OnStart()
    {
        var network = serviceProvider.GetService<INetworkService>();
        base.OnStart();
    }

}
