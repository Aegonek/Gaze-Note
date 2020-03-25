using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GazeNote.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMDPageMaster : ContentPage
    {
        public ListView ListView;
        public Button AllNotesLabel;

        public MainMDPageMaster()
        {
            InitializeComponent();
            BindingContext = ((App)App.Current);
            ListView = TagListListView;
            AllNotesLabel = allNotesLabel;
        }
    }
}