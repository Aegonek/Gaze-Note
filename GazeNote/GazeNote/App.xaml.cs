using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLStorage;
using System.Collections.ObjectModel;
using GazeNote.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GazeNote {
    public partial class App : Application {
        // You can experiment with Tasks here later
        private ObservableCollection<Note> noteList;
        private ObservableCollection<String> tagList = new ObservableCollection<String>();
        private readonly string dataFilePath = FileSystem.Current.LocalStorage.Path + "\\notes.dat";

        public ObservableCollection<Note> NoteList { get => noteList; set => noteList = value; }
        public ObservableCollection<String> TagList { get => tagList; set => tagList = value; }
        public string DataFilePath => dataFilePath;

        public App() {
            InitializeComponent();
            using (FileStream fs = new FileStream(DataFilePath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite)) {
                var bf = new BinaryFormatter();
                if (fs.Length > 3) {
                    NoteList = (ObservableCollection<Note>)bf.Deserialize(fs);
                }
                else {
                    NoteList = new ObservableCollection<Note>();
                }
            }
            UpdateTagList();
            MainPage = new NavigationPage(new MainMDPage());
        }
        public void UpdateTagList() {
            foreach (Note note in NoteList) {
                foreach (String tag in note.Tags) {
                    if (!TagList.Contains(tag)) {
                        TagList.Add(tag);
                    }
                }
            }
        }
        public void UpdateNoteFile() {
            using (var fs = new FileStream(DataFilePath, FileMode.OpenOrCreate, System.IO.FileAccess.Write)) {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fs, NoteList);
            };
        }
        
        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
