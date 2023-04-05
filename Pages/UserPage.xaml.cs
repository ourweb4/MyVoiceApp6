// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-03-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 02-03-2023
// ***********************************************************************
// <copyright file="UserPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MyVoiceApp6.Models;
using MyVoiceApp6.Utitlys;

namespace MyVoiceApp6.Pages
{
    /// <summary>
    /// Class UserPage.
    /// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
    /// </summary>
    /// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        /// <summary>
        /// The API
        /// </summary>
        private Api api = new Api();
        /// <summary>
        /// The user
        /// </summary>
        private AppUser user = new AppUser();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPage"/> class.
        /// </summary>
        public UserPage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            activity.IsVisible = true;
            activity.IsRunning = true;
            user = await api.GetUser();
             BindingContext = user;
            activity.IsRunning = false;
            activity.IsVisible = false;
        }

        /// <summary> 
        /// Applications the information.
        /// </summary>
        [Obsolete]
        private void App_Info()
        {
            // First time ever launched application
            var firstLaunch = VersionTracking.IsFirstLaunchEver;

            // First time launching current version
            var firstLaunchCurrent = VersionTracking.IsFirstLaunchForCurrentVersion;

            // First time launching current build
            var firstLaunchBuild = VersionTracking.IsFirstLaunchForCurrentBuild;

            // Current app version (2.0.0)
            var currentVersion = VersionTracking.CurrentVersion;

            // Current build (2)
            var currentBuild = VersionTracking.CurrentBuild;

            user.Version = currentVersion + " (" + currentBuild + ")";
            user.Os = Device.RuntimePlatform;

            // Previous app version (1.0.0)
            var previousVersion = VersionTracking.PreviousVersion;

            // Previous app build (1)
            var previousBuild = VersionTracking.PreviousBuild;

            // First version of app installed (1.0.0)
            var firstVersion = VersionTracking.FirstInstalledVersion;

            // First build of app installed (1)
            var firstBuild = VersionTracking.FirstInstalledBuild;

            // List of versions installed (1.0.0, 2.0.0)
            var versionHistory = VersionTracking.VersionHistory;

            // List of builds installed (1, 2)
            var buildHistory = VersionTracking.BuildHistory;
        }

        /// <summary>
        /// Handles the Clicked event of the btnsave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnsave_Clicked(object sender, EventArgs e)
        {
            activity.IsVisible = true;
            activity.IsRunning = true;

            App_Info();
            await api.SaveUser(user);
            activity.IsRunning = false;
            activity.IsVisible = false;

            await Shell.Current.GoToAsync($"//{nameof(TalkPage)}");

        }
    }
}