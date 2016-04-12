using MicroMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class PianoViewModel:ObservableObject
    {
        private ObservableCollection<NoteViewModel<notesBlanches>> notesBlanches;
        private ObservableCollection<NoteViewModel<notesNoires>> notesNoires;


        public PianoViewModel()
        {
            NotesBlanches = new ObservableCollection<NoteViewModel<notesBlanches>>();
            PianoManager pianoManager = new PianoManager();
         
            List < Note<notesBlanches> > touchesBlanches = pianoManager.getPianoBlanches();
            foreach (Note<notesBlanches> touche in touchesBlanches)
            {
                NotesBlanches.Add(new NoteViewModel<notesBlanches>() { Note = touche });
            }

            NotesNoires = new ObservableCollection<NoteViewModel<notesNoires>>();

            List<Note<notesNoires>> touchesNoires = pianoManager.getPianoNoires();
            for (int i=0;i<touchesNoires.Count;i++) 
            {
                NoteViewModel<notesNoires> note = new NoteViewModel<notesNoires>() { Note = touchesNoires.ElementAt(i) };
          
                NotesNoires.Add(note);
            }
        }

    
  
        public ObservableCollection<NoteViewModel<notesBlanches>> NotesBlanches
        {
            get
            {
                return notesBlanches;
            }

            set
            {
                notesBlanches = value;
            }
        }

        public ObservableCollection<NoteViewModel<notesNoires>> NotesNoires
        {
            get
            {
                return notesNoires;
            }

            set
            {
                notesNoires = value;
            }
        }
    }
}
