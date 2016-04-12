using MicroMvvm;
using System;

namespace Music
{
    public class ActualNote:ObservableObject
    {
        private static ActualNote instance;
        static readonly object instanceLock = new object();
        private string note;

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
                RaisePropertyChanged("Note");
            }
        }

        public static ActualNote getInstance()

        {

            if (instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
            {
                lock (instanceLock)
                {
                    if (instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                        instance = new ActualNote();
                }
            }

            return instance;
        }

     

        private ActualNote()
        {

        }
    }
}