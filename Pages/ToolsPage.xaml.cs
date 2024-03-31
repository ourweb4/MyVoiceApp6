// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-16-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 03-14-2023
// ***********************************************************************
// <copyright file="ToolsPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Utitlys;

namespace MyVoiceApp6.Pages;

/// <summary>
/// Class ToolsPage.
/// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
public partial class ToolsPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolsPage" /> class.
    /// </summary>
    public ToolsPage()
    {
        InitializeComponent();




    }

    /// <summary>
    /// Called when [appearing].
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var tokon = Preferences.Get("token", null);
        if (tokon != null)
        {
            btnlogout.IsEnabled = true;
            btnuser.IsEnabled = true;
            lblmessage.Text = "";
            btndistory.IsEnabled = true;

        }
        else
        {
            btnlogout.IsEnabled = false;
            btnuser.IsEnabled = false;
            btndistory.IsEnabled = false;
            lblmessage.Text = "You are not login";
        }

    }

    /// <summary>
    /// Handles the Clicked event of the btnuser control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private async void btnuser_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("UserPage");

    }

    /// <summary>
    /// Handles the Clicked event of the btnsettings control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void btnsettings_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    /// <summary>
    /// Handles the Clicked event of the btnlogout control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void btnlogout_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("token", null);

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void btndistory_Clicked(object sender, EventArgs e)
    {
        // write a yes no dialog asking if they want to delete all data

        var answer = DisplayAlert("Delete All Data", "Are you sure you want to delete all data", "Yes", "No");

        // if yes then delete all data
        if (answer != null)
        {
            if (answer.Result)
            {
                Api api = new Api();
                var mes = await api.Distory();
                Preferences.Set("token", null);


            }

        }
    }
}