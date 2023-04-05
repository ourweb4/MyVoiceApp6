// ***********************************************************************
// Assembly         : MyVoiceApp6
// Author           : Bill Banks
// Created          : 02-03-2023
//
// Last Modified By : Bill Banks
// Last Modified On : 04-02-2023
// ***********************************************************************
// <copyright file="TalkPage.xaml.cs" company="MyVoiceApp6">
//     Copyright (c) ourweb.net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using MyVoiceApp6.Models;
using MyVoiceApp6.Utitlys;
using System.Collections.ObjectModel;

namespace MyVoiceApp6.Pages;

/// <summary>
/// Class TalkPage.
/// Implements the <see cref="Microsoft.Maui.Controls.ContentPage" />
/// </summary>
/// <seealso cref="Microsoft.Maui.Controls.ContentPage" />
public partial class TalkPage : ContentPage
{
    /// <summary>
    /// The database
    /// </summary>
    private Database db = new Database();

    /// <summary>
    /// The configuration
    /// </summary>
    private Config config = new Config();

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
    /// The autotalk
    /// </summary>
    private bool autotalk;

    /// <summary>
    /// Initializes a new instance of the <see cref="TalkPage" /> class.
    /// </summary>
    public TalkPage()
    {
        InitializeComponent();
        autotalk = config.Autotalk; 
    }


    /// <summary>
    /// Handles the OnItemSelected event of the ListWords control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectedItemChangedEventArgs" /> instance containing the event data.</param>
    private void ListWords_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Word word = e.SelectedItem as Word;
        etext.Text += " " + word.Phrase;
        if (autotalk)
        {


            SpeakNow(word.Phrase);
            etext.Text = "";
        }
    }



    /// <summary>
    /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
    /// </summary>
    /// <remarks>To be added.</remarks>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ReadDB();
        Read_Groups();

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
    /// Handles the OnClicked event of the Buttalk control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void Buttalk_Clicked(object sender, EventArgs e)
    {
        string say = etext.Text;

        SpeakNow(say);
 
        //      etext.Text = "";

    }

    /// <summary>
    /// Handles the OnItemTapped event of the ListWords control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ItemTappedEventArgs" /> instance containing the event data.</param>
    private void ListWords_OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        Word word = e.Item as Word;
        etext.Text += " " + word.Phrase;
        if (autotalk)
        {


            SpeakNow(word.Phrase);
            etext.Text = "";
        }
    }

    /// <summary>
    /// Reads the database.
    /// </summary>
    private void ReadDB()
    {
  //      words = new List<Word>();

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

        var  none = new Group();
        none.Name = "None";
        none.Id = -1;

        groups.Add(none);

         var mgroups = db.ReadGroups();

        foreach ( var group in mgroups )
        {
            groups.Add(group);
        }


        picgroup.ItemsSource = groups;

    }

    /// <summary>
    /// Handles the OnClicked event of the ButAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void ButAdd_OnClicked(object sender, EventArgs e)
    {
        string text = etext.Text;
        if (text != "")
        {
            Word word = new Word();
            word.Id = 0;
            word.Phrase = text;
            word.Title = text;
            word.Group_Id = curr_grouo;
            db.WriteWord(word);
            etext.Text = "";
            ReadDB();
        }
    }

    /// <summary>
    /// Handles the ParentChanged event of the picgroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    private void picgroup_ParentChanged(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// Handles the Clicked event of the ButClear control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <font color="red">Badly formed XML comment.</font>

    private void ButClear_Clicked(object sender, EventArgs e)
    {
        etext.Text= string.Empty;
    }

    /// <summary>
    /// Handles the SelectedIndexChanged event of the picgroup control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
