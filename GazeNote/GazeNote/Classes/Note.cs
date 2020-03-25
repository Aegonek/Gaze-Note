using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GazeNote {
    [Serializable()]
    public class Note : INotifyPropertyChanged {
        private List<String> tags;
        private string name;
        private string content;
        private readonly Guid id;
        private readonly DateTime dateOfCreation;
        private DateTime dateOfLastUpdate;
        public string Name {
            get {
                return name;
            }
            set {
                if (value != name) {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Content {
            get {
                return content;
            }
            set {
                if (value != content) {
                    content = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Guid Id {
            get {
                return id;
            }
        }
        public DateTime DateOfCreation {
            get {
                return dateOfCreation;
            }
        }
        public DateTime DateOfLastUpdate {
            get {
                return dateOfLastUpdate;
            }
            set {
                if (value != dateOfLastUpdate) {
                    dateOfLastUpdate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<String> Tags {
            get {
                return tags;
            }
            set {
                if (value != tags) {
                    tags = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [field:NonSerialized()]
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Note() {
            id = Guid.NewGuid();
            Name = "To jest nazwa notatki";
            Content = "To jest tekst notatki";
            Tags = new List<String>();
            dateOfCreation = DateTime.Now;
            DateOfLastUpdate = DateTime.Now;
        }
    }
}
