using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GazeNote.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddOrEditNotificationPage : ContentPage
	{
		public AddOrEditNotificationPage ()
		{
			InitializeComponent ();
		}

        private void DeleteButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).NoteList.Remove(this.BindingContext as Note);
            ((App)App.Current).UpdateNoteFile();
            Navigation.PopAsync();
        }

        private void SaveButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).UpdateNoteFile();
        }

        private void BackButton_Clicked(object sender, EventArgs e) {
            ((App)App.Current).UpdateNoteFile();
            Navigation.PopAsync();
        }
    }
}