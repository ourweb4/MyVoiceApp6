namespace MyVoiceApp6;

public partial class App : Application
{
    public const string website = "https://ourvoiceapp.com";

    public App()
	{
		InitializeComponent();
		VersionTracking.Track();

		MainPage = new AppShell();
	}
}
