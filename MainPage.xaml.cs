using HelloMauiApp.Helpers;
using HelloMauiApp.ViewModels;

namespace HelloMauiApp;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = ServiceHelper.GetService<MainPageViewModel>();
	}

}

