// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill
// Created          : 08-09-2023
//
// Last Modified By : Bill
// Last Modified On : 08-09-2023
// ***********************************************************************
// <copyright file="App.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace MyVoiceApp6;

/// <summary>
/// Class App.
/// Implements the <see cref="Microsoft.Maui.Controls.Application" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.Application" />
public partial class App : Application
{
    /// <summary>
    /// The website
    /// </summary>
    public const string website = "https://ourvoiceapp.com";

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    /// <remarks>To be added.</remarks>
    public App()
	{
		InitializeComponent();
		VersionTracking.Track();

		MainPage = new AppShell();
	}
}
