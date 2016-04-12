using MicroMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music
{
    public class NoteViewModel<T>:ObservableObject where T :struct,IConvertible
    {
        public Note<T> Note { get;  set; }

        public string FrequenceNote
        {
            get { return Note.Frequency.ToString(); }
        
        }
        private bool doesntExist=false;
        public bool DoesntExist { get { return doesntExist; }  set { doesntExist = value; RaisePropertyChanged("DontExist"); } }



        public void jouer()
        {
            Note.jouer();
            ActualNote.getInstance().Note = FrequenceNote;
        }

        public ICommand JouerCmd { get { return new RelayCommand(jouer, canJouer); } }

        bool canJouer()
        {
            return true;
        }


    }
}
