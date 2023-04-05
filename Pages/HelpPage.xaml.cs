namespace MyVoiceApp6.Pages;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
		InitializeComponent();
	}

    protected override  void OnAppearing()
    {
        base.OnAppearing();

      
        lblver.Text = "Ver. "+ VersionTracking.CurrentVersion + " (" + VersionTracking.CurrentBuild + ")";
            
    }

}