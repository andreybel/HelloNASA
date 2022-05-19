using HelloMauiApp.Helpers;
using HelloMauiApp.ViewModels;

namespace HelloMauiApp;

public partial class DetailPage : ContentPage
{
	public DetailPage(object parameter = null)
	{

        InitializeComponent();

        BindingContext = ServiceHelper.GetService<DetailPageViewModel>(); ;

        var viewModel = BindingContext as DetailPageViewModel;

        if (!string.IsNullOrEmpty(parameter.ToString()))
        {
            viewModel.Parameter = parameter.ToString();
            viewModel.Initialize(parameter);
        }
    }
}