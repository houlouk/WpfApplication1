using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public interface IPiste
    {
        AStyle Style { get; set; }
        void addNote(INote n);
        void jouer();
        void convertToWav();
    }
}
