using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GazeNote.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMDPageDetail : ContentPage {
        public MainMDPageDetail() {
            BindingContext = (App)App.Current;
            InitializeComponent();
        }
        public MainMDPageDetail(string item) {
            BindingContext = null;
            InitializeComponent();
            NoteListListView.Header = new Label() {
                Text = $"#{item}",
                FontSize = 24,
                HeightRequest = 60,
                BackgroundColor = Color.FromHex("eae9e9"),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var taggedItemsListSource = new ObservableCollection<Note>();
            foreach (var note in ((App)App.Current).NoteList) {
                if (note.Tags.Contains(item)) {
                    taggedItemsListSource.Add(note);
                }
            }
            NoteListListView.ItemsSource = taggedItemsListSource;
        }

        // Later I can implement serialization/deserialization on stream of multiple objects, rather than single collection,
        // so I don't have to serialize/deserialize whole collection at once
        private void NoteButton_Clicked(object sender, EventArgs e) {
            var newNote = new Note();
            ((App)App.Current).NoteList.Add(newNote);
            Navigation.PushAsync(new AddOrEditNotePage() {
                BindingContext = newNote
            });
        }
        private void NoteListListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var selectedNote = e.SelectedItem as Note;
            Navigation.PushAsync(new AddOrEditNotePage() {
                BindingContext = selectedNote
            });
        }
    }
}