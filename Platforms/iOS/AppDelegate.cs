using AppTrackingTransparency;
using Foundation;
using UIKit;

namespace MyVoiceApp6;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override void OnActivated(UIApplication application)
    {
        base.OnActivated(application);
        ATTrackingManager.RequestTrackingAuthorization(async (status) =>
        {
            string message = "";
            // Handle the user's authorization status here
            switch (status)
            {
                case ATTrackingManagerAuthorizationStatus.Authorized:
                    message = "Authorized";
                    break;

                case ATTrackingManagerAuthorizationStatus.Denied:
                    message = "Denied";
                    break;

                case ATTrackingManagerAuthorizationStatus.Restricted:
                    message = "Restricted";
                    break;

                case ATTrackingManagerAuthorizationStatus.NotDetermined:
                    message = "NotDetermined";
                    break;
            }
        });
    }

}





