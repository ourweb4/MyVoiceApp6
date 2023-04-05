// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-06-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 02-15-2023
// ***********************************************************************
// <copyright file="EditGroupsPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Models;
using MyVoiceApp6.Utitlys;
using System.Collections.ObjectModel;

namespace MyVoiceApp6.Pages;

/// <summary>
/// Class EditGroupsPage.
/// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
public partial class EditGroupsPage : ContentPage
{

    /// <summary>
    /// The database
    /// </summary>
    private Database db = new Database();

    /// <summary>
    /// The groups
    /// </summary>
    private ObservableCollection<Group> groups;

    /// <summary>
    /// The curr grouo
    /// </summary>
    private int curr_grouo = -1;


    /// <summary>
    /// The curr group
    /// </summary>
    private Group curr_group = new Group();

    /// <summary>
    /// Initializes a new instance of the <see cref="EditGroupsPage"/> class.
    /// </summary>
    public EditGroupsPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Called when [appearing].
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ReadDB(GetGroups());
        //        var app = Application.Current as App;
        //        autotalk = app.autoflag;
    }

    private ObservableCollection<Group> GetGroups()
    {
        return groups;
    }

    /// <summary>
    /// Reads the database.
    /// </summary>
    private void ReadDB(ObservableCollection<Group> groups)
    {
        groups =  (ObservableCollection<Group>) db.ReadGroups();



   
        Listgroups.ItemsSource = groups;

        //       NewWord();
    }

    /// <summary>
    /// Handles the Clicked event of the btndelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void btndelete_Clicked(object sender, EventArgs e)
    {
        db.DeleteGroup(curr_group);
        ReadDB(GetGroups());
    }

    /// <summary>
    /// Handles the Clicked event of the btnsave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnsave_Clicked(object sender, EventArgs e)
    {
        curr_group.Name = ename.Text;
        db.WriteGroup(curr_group);
        ename.Text = "";
        ReadDB(GetGroups());
    }

    /// <summary>
    /// Handles the Clicked event of the btnnew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void btnnew_Clicked(object sender, EventArgs e)
    {
        curr_group = new Group();
        ename.Text= curr_group.Name;
        curr_group.Id = 0;

    }

    /// <summary>
    /// Handles the ItemSelected event of the Listgroups control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
    private void Listgroups_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        curr_group=e.SelectedItem as Group;
        ename.Text= curr_group.Name;
    }

    /// <summary>
    /// Handles the ItemTapped event of the Listgroups control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
    private void Listgroups_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item !=null)
        {
            curr_group= (Group)e.Item;          
            ename.Text= curr_group.Name;

        }
    }
}