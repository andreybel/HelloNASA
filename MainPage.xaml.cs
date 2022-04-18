using HelloMauiApp.ViewModels;

namespace HelloMauiApp;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		this.BindingContext = new MainPageViewModel(Navigation);
	}

}

