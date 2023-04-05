// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-02-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 03-07-2023
// ***********************************************************************
// <copyright file="AppShell.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Pages;

namespace MyVoiceApp6;

/// <summary>
/// Class AppShell.
/// Implements the <see cref="Microsoft.Maui.Controls.Shell" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.Shell" />
public partial class AppShell : Shell
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppShell"/> class.
    /// </summary>
    /// <remarks>To be added.</remarks>
    public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
        Routing.RegisterRoute("UserPage", typeof(UserPage));

        Routing.RegisterRoute("HelpPage", typeof(HelpPage));
        Routing.RegisterRoute("ToolsPage", typeof(ToolsPage));
        Routing.RegisterRoute("TalkPage", typeof(TalkPage));
        Routing.RegisterRoute("EditPage", typeof(EditPage));
        Routing.RegisterRoute("SettingsPage", typeof(SettingsPage));
        Routing.RegisterRoute("EditWordsPage", typeof(EditWordsPage));
        Routing.RegisterRoute("EditGroupsPage", typeof(EditGroupsPage));

    }
}
