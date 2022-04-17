

//namespace HelloMauiApp
//{
//    public class SpinnerScreen : ContentView
//    {
//        public AbsoluteLayout MainLayout = new AbsoluteLayout();

//        ActivityIndicator Spinner = new ActivityIndicator();
//        Frame SpinnerBackground = new Frame();

//        public SpinnerScreen()
//        {
//            SpinnerBackground.BackgroundColor = Color.FromArgb("#000000");
//            SpinnerBackground.WidthRequest = 150;
//            SpinnerBackground.HeightRequest = 150;
//            SpinnerBackground.CornerRadius = 20;
//            Spinner.WidthRequest = 50;
//            Spinner.HeightRequest = 50;

//            Spinner.Color = Color.FromArgb("#FFFFFF");
//            Spinner.IsRunning = true;

//            MainLayout.Children.Add(Spinner, new Rectangle((Application.Current.MainPage.Width - 50) / 2, (Application.Current.MainPage.Height - 50) / 2, 50, 50));
//            //MainLayout.Children.Add(SpinnerBackground, new Rectangle((Application.Current.MediaManagerPage.Width - 150) / 2, (Application.Current.MediaManagerPage.Height - 150) / 2, 150, 150));

//            MainLayout.WidthRequest = Application.Current.MainPage.Width;
//            MainLayout.HeightRequest = Application.Current.MainPage.Height;
//            MainLayout.BackgroundColor = Color.FromRgba(0, 0, 0, 0.5);

//            Content = MainLayout;
//        }
//    }
//}
