using HelloMauiApp.Helpers;
using HelloMauiApp.Interfaces;

namespace HelloMauiApp;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

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
        ServiceHelper.GetService<INetworkService>();
        base.OnStart();
    }

    protected override void OnResume()
    {
        ServiceHelper.GetService<INetworkService>();
        base.OnResume();
    }
}
