// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-06-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 03-22-2023
// ***********************************************************************
// <copyright file="EditWordsPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Models;
using MyVoiceApp6.Utitlys;
using System.Collections.ObjectModel;

namespace MyVoiceApp6.Pages;

/// <summary>
/// Class EditWordsPage.
/// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
public partial class EditWordsPage : ContentPage
{
    /// <summary>
    /// The database
    /// </summary>
    private Database db = new Database();

    /// <summary>
    /// The words
    /// </summary>
    private ObservableCollection<Word> words;


    /// <summary>
    /// The groups
    /// </summary>
    private List<Group> groups;

    /// <summary>
    /// The curr grouo
    /// </summary>
    private int curr_grouo = -1;

    /// <summary>
    /// The curr word
    /// </summary>
    private Word  curr_word = new Word();


    /// <summary>
    /// Initializes a new instance of the <see cref="EditWordsPage" /> class.
    /// </summary>
    public EditWordsPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Called when [appearing].
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ReadDB();
        Read_Groups();
        //        var app = Application.Current as App;
        //        autotalk = app.autoflag;
    }

    /// <summary>
    /// Speaks the now.
    /// </summary>
    /// <param name="words">The words.</param>
    public void SpeakNow(string words)
    {
        TextToSpeech.SpeakAsync(words).ContinueWith((t) =>
        {
            // Logic that will run after utterance finishes.

        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    /// <summary>
    /// Reads the database.
    /// </summary>
    private void ReadDB()
    {
//        words = new List<Word>();

        words = (ObservableCollection<Word>)db.ReadWords(curr_grouo);




        ListWords.ItemsSource = words;

        
       //       NewWord();
    }


    /// <summary>
    /// Reads the groups.
    /// </summary>
    private void Read_Groups()
    {

        groups = new List<Group>();

        var none = new Group();
        none.Name = "None";
        none.Id = -1;

        groups.Add(none);

        var mgroups = db.ReadGroups();

        foreach (var group in mgroups)
        {
            groups.Add(group);
        }


        picgroup.ItemsSource = groups;

    }

    /// <summary>
    /// Handles the Clicked event of the btnnew control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnnew_Clicked(object sender, EventArgs e)
    {
        curr_word = new Word();
        curr_word.Group_Id = -1;
        etext.Text = "";
        curr_word.Id = 0;
    }

    /// <summary>
    /// Handles the Clicked event of the btnsave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btnsave_Clicked(object sender, EventArgs e)
    {
        curr_word.Title = etext.Text;
        var v = eorder.Text;
        curr_word.Order = v;
        curr_word.Group_Id = curr_grouo;

        db.WriteWord(curr_word);           
        ReadDB();


    }

    /// <summary>
    /// Handles the Clicked event of the btndelete control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btndelete_Clicked(object sender, EventArgs e)
    {
        db.DeleteWord(curr_word); 
    }

    /// <summary>
    /// Handles the Clicked event of the btntalk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void btntalk_Clicked(object sender, EventArgs e)
    {

        SpeakNow(etext.Text) ;
    }

    /// <summary>
    /// Handles the PropertyChanging event of the picgroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="PropertyChangingEventArgs" /> instance containing the event data.</param>
    private void picgroup_PropertyChanging(object sender, PropertyChangingEventArgs e)
    {

    }

    /// <summary>
    /// Handles the ItemTapped event of the ListWords control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ItemTappedEventArgs" /> instance containing the event data.</param>
    private void ListWords_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null)

        {
            Word word = e.Item as Word;
            etext.Text = word.Title;
            eorder.Text= word.Order;
          
                curr_word= word;
            curr_grouo = word.Group_Id;
        }

    }

    /// <summary>
    /// Handles the ItemSelected event of the ListWords control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectedItemChangedEventArgs" /> instance containing the event data.</param>
    private void ListWords_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        curr_word = e.SelectedItem as Word;
        etext.Text= curr_word.Phrase;
        curr_grouo= curr_word.Group_Id;

    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the picgroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void picgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            var grp = groups[selectedIndex];
            curr_grouo = grp.Id;
        }

    }
}