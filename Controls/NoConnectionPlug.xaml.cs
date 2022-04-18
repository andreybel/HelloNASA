namespace HelloMauiApp;

public partial class NoConnectionPlug : Grid
{
	public NoConnectionPlug()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ImageSourceProperty =
          BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(NoConnectionPlug));


    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
}