using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GazeNote.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditNotePage : ContentPage {
        public AddOrEditNotePage() {
            InitializeComponent();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            ShowTags();
        }
        // To improve
        private void ShowTags() {
            var note = BindingContext as Note;
            TagContainer.Children.Clear();
            foreach (String tag in note.Tags) {
                TagContainer.Children.Add(new Label {
                    HeightRequest = 24,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 12,
                    Margin = 8,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.FromHex("caadde"),
                    TextColor = Color.White,
                    Text = tag
                });
            }
            
        }

        private void DeleteButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).NoteList.Remove(this.BindingContext as Note);
            ((App)App.Current).UpdateNoteFile();
            ((App)App.Current).UpdateTagList();
            Navigation.PopAsync();
        }

        private void SaveButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).UpdateNoteFile();
            ((App)App.Current).UpdateTagList();
        }

        private void BackButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).UpdateNoteFile();
            ((App)App.Current).UpdateTagList();
            Navigation.PopAsync();
        }

        private void TagEntry_Completed(object sender, EventArgs e) {
            var note = BindingContext as Note;
            note.Tags.Add(TagEntry.Text);
            TagEntry.Text = "";
            ((App)App.Current).UpdateTagList();
            ShowTags();
        }
    }
}