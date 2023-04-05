using MyVoiceApp6.Utitlys;

namespace MyVoiceApp6.Pages;

public partial class SettingsPage : ContentPage
{

	private Config config = new Config();

	public SettingsPage()
	{
		InitializeComponent();

		swathotalk.IsToggled = config.Autotalk;
	}

    private async void btnsave_Clicked(object sender, EventArgs e)
    {
		config.Autotalk = swathotalk.IsToggled;

		await DisplayAlert("Saved", "Settings Saved", "Ok");
    }
}