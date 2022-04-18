using HelloMauiApp.ViewModels;

namespace HelloMauiApp;

public partial class DetailPage : ContentPage
{
	public DetailPage(object parameter = null)
	{

        InitializeComponent();

        this.BindingContext = new DetailPageViewModel(Navigation);

        var viewModel = BindingContext as DetailPageViewModel;

        if (!string.IsNullOrEmpty(parameter.ToString()))
        {
            viewModel.Parameter = parameter.ToString();
            Task.Run(async () => await viewModel.Initialize(parameter));
        }
    }
}