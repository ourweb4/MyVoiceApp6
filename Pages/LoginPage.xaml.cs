// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 01-10-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 01-10-2023
// ***********************************************************************
// <copyright file="LoginPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Models;
using MyVoiceApp6.Utitlys;
using MyVoiceApp6.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//

namespace MyVoiceApp6.Pages
{
    /// <summary>
    /// Class LoginPage.
    /// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
    /// </summary>
    /// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// The logindata
        /// </summary>
        private LoginVM logindata = new LoginVM();
        /// <summary>
        /// The API
        /// </summary>
        private Api api = new Api();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
      //      CheckLogon();
            InitializeComponent();

            BindingContext = logindata;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
  //          CheckLogon();
        }
            /// <summary>
            /// Checks the logon.
            /// </summary>
            private void CheckLogon()
        {
            var tokon = Preferences.Get("token", null);
            if  (tokon != null )
              Shell.Current.GoToAsync($"//{nameof(TalkPage)}");


        }

        /// <summary>
        /// Handles the Clicked event of the btnlogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            logindata.email = txtemail.Text;
            logindata.password = txtpassword.Text;

            if (logindata.email == null
               || logindata.password == null)
            {
                ErrPopup popup = new ErrPopup(Message_Box.Blankfield);
                await DisplayAlert("Error", popup.message,"Ok");
            } else
            {
               CheckEmeil checker = new CheckEmeil();
                if (checker.IsValidEmail(logindata.email) == false)
                {
                    ErrPopup popup = new ErrPopup(Message_Box.Notemail);
                    await DisplayAlert("Error", popup.message, "Ok");

                }
                else
                {
                    Api api = new Api();
                    await api.Login(logindata);
                    if (api.IsOk())
                    {
                         await Shell.Current.GoToAsync($"//{nameof(TalkPage)}");
                    }
                    else {
                        ErrPopup popup = new ErrPopup(Message_Box.Badlogin);
                        await DisplayAlert("Error", popup.message, "Ok");

                    }
                }
                }
                //
                //
            }

        /// <summary>
        /// Handles the Clicked event of the btnregister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnregister_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");

        }

        /// <summary>
        /// Handles the Clicked event of the btnnologin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnnologin_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("token", null);

            await Shell.Current.GoToAsync($"//{nameof(TalkPage)}");
        }

        private async void btnforgot_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(ForgotPage)}");


        }
    }
}