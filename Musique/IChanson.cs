using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    interface IChanson
    {
        void jouer();
        void addPiste(IPiste piste);
        void save(string file);


    }

}
