using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public interface INote
    {
        void jouer();

        dureeNote Duration { get; }
        AStyle Style { get; set; }
      

    }

}