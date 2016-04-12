using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Music
{
    internal class PianoManager
    {
        private int nbBlanches = 36;

        public int NbBlanches
        {
            get
            {
                return nbBlanches;
            }

            set
            {
                nbBlanches = value;
            }
        }

        public int NbNoires
        {
            get { return (int)(NbBlanches * (25.0 / 36)); }
        }
        internal List<Note<notesBlanches>> getPianoBlanches()
        {
            List<Note<notesBlanches>> touches = new List<Note<notesBlanches>>();
            int i = 0;

            foreach (notesBlanches note in Enum.GetValues(typeof(notesBlanches)))
            {
                if (i >= nbBlanches) break;
                touches.Add(new Note<notesBlanches>(new Tango(), note));
                i++;



            }

            return touches;
        }

        internal List<Note<notesNoires>> getPianoNoires()
        {
            List<Note<notesNoires>> touches = new List<Note<notesNoires>>();
            int i = 0;

            foreach (notesNoires note in Enum.GetValues(typeof(notesNoires)))
            {
                if (i >= NbNoires) break;
                touches.Add(new Note<notesNoires>(new Tango(), notesNoires.SILENCE));
                if (i % 5 == 2 || i % 5 == 0) touches.Add(new Note<notesNoires>(new Tango(), notesNoires.SILENCE));

                touches.Add(new Note<notesNoires>(new Tango(), note));

                i++;

            }
            return touches;


        }
    }
}
