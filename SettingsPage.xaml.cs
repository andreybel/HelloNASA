
using HelloMauiApp.ViewModels;

namespace HelloMauiApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(object parameter = null)
    {
        InitializeComponent();

        this.BindingContext = new SettingsPageViewModel(Navigation);

        var viewModel = BindingContext as SettingsPageViewModel;

        if (!string.IsNullOrEmpty(parameter.ToString()))
        {
            viewModel.Parameter = parameter.ToString();
            Task.Run(async () => await viewModel.Initialize(parameter));
        }
    }
}