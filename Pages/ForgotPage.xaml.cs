// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 04-09-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 04-09-2023
// ***********************************************************************
// <copyright file="ForgotPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Utitlys;
using MyVoiceApp6.ViewModels;

namespace MyVoiceApp6.Pages;

/// <summary>
/// Class ForgotPage.
/// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
public partial class ForgotPage : ContentPage
{
    /// <summary>
    /// The API
    /// </summary>
    private Api api = new Api();

    /// <summary>
    /// The forgot
    /// </summary>
    private ForgotVM forgot = new ForgotVM();

    /// <summary>
    /// Initializes a new instance of the <see cref="ForgotPage"/> class.
    /// </summary>
    public ForgotPage()
    {
        InitializeComponent();
        BindingContext = forgot;
        activity.IsVisible = false;
    }

    /// <summary>
    /// Handles the Clicked event of the btnforgot control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void btnforgot_Clicked(object sender, EventArgs e)
    {
        forgot.email = txtemail.Text;
        if (forgot.email == null)
        {
            ErrPopup popup = new ErrPopup(Message_Box.Blankfield);
            await DisplayAlert("Error", popup.message, "Ok");
        }
        else
        {
            CheckEmeil checker = new CheckEmeil();
            if (checker.IsValidEmail(forgot.email) == false)
            {
                ErrPopup popup = new ErrPopup(Message_Box.Notemail);
                await DisplayAlert("Error", popup.message, "Ok");

            }
            else
            {
                activity.IsVisible = true;
                activity.IsRunning = true;
                await api.Forgot(forgot);
                await Shell.Current.GoToAsync($"..");

            }



        }

    }
}