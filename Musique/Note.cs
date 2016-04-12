using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    [DataContract(Name = "Note", Namespace = "Musique")]

    public class Note<T> : INote where T :struct,IConvertible
    {

        [DataMember()]
        private dureeNote duration;

        [DataMember()]
        private T frequency;

        private AStyle style;

        public dureeNote Duration
        {
            get
            {
                return duration;
            }
            private set
            {
                this.duration = value;
            }
        }

        public AStyle Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }

        public T Frequency
        {
            get
            {
                return frequency;
            }

            private set
            {
                frequency = value;
            }
        }

        public Note(AStyle style, T frequency, dureeNote duration = dureeNote.NOIRE)
        {
            this.duration = duration;
            this.Frequency = frequency;
            this.style = style;
        }

        public void jouer()
        {

           




            Console.WriteLine("On ne dirait pas mais ça beep à la fréquence de " + frequency+" c'est une " + duration + "de durée " + (int)duration + " secondes");
            //System.Threading.Thread.Sleep((int)(Duration * style.tempo()));

            Task.Factory.StartNew(()=>
            {
                Enum test = Enum.Parse(typeof(T), frequency.ToString()) as Enum;
                int realFrequency = Convert.ToInt32(test); // x is the integer value of enum


                Console.Beep(realFrequency+37, (int)((int)duration / 100.0 * (int)style.tempo())); }
            );
        }










    }
}
