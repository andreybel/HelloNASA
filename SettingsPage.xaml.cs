
using HelloMauiApp.ViewModels;

namespace HelloMauiApp;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        this.BindingContext = new SettingsPageViewModel(Navigation);
    }
}