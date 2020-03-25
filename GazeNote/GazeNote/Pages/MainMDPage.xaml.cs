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
    public partial class MainMDPage : MasterDetailPage
    {
        public MainMDPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MasterPage.AllNotesLabel.Clicked += AllNotesLabel_Clicked;
        }

        private void AllNotesLabel_Clicked(object sender, EventArgs e) {
            Detail = new NavigationPage((Page)new MainMDPageDetail());
            MasterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }

        //private void AllNotesLabel_Clicked(object sender, FocusEventArgs e) {
        //    Detail = new NavigationPage((Page)new MainMDPageDetail());
        //    MasterPage.ListView.SelectedItem = null;
        //    IsPresented = false;
        //}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var item = e.SelectedItem as String;
            if (item != null) {
                Detail = new NavigationPage((Page)new MainMDPageDetail(item));
                MasterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MainMDPageMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}