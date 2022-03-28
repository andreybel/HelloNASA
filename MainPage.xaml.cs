using HelloMauiApp.ViewModels;

namespace HelloMauiApp;
public partial class MainPage : ContentPage
{
	int count = 0;


	public MainPage()
	{
		InitializeComponent();

		this.BindingContext = new MainPageViewModel(Navigation);
	}

}

