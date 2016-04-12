using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Music
{

    [DataContract(Name = "Silence", Namespace = "Musique")]

    class Silence : INote
    {
        public void jouer()
        {
            System.Threading.Thread.Sleep((int)Style.tempo());
        }

        public Silence(AStyle style, dureeNote duration = dureeNote.NOIRE)
        {
            this.Duration = duration;

            this.Style = style;
        }

        [DataMember()]
        public dureeNote Duration
        {
            get;
            private set;

        }

        public AStyle Style
        {
            get; set;
        }
    }
}