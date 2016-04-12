using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// See datacontractserializer
/// </summary>
namespace Music
{
    [DataContract(Name = "Chanson", Namespace = "Musique")]
    [KnownType(typeof(Piste))]

    class Chanson : IChanson,IExtensibleDataObject
    {

        [DataMember()]
        private List<IPiste> pistes = new List<IPiste>();


        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionData_Value;
            }

            set
            {
                this.extensionData_Value = value;
            }
        }

        public void addPiste(IPiste piste)
        {
            pistes.Add(piste);
        }

        public void jouer()
        {
            //Pour une seule pise pour le moment
            Parallel.ForEach(pistes, (piste) =>
           {
               piste.jouer();

           });
        }

        public void save(string fileName)
        {
            SaverLoader<Chanson>.save(this, fileName);

        }

      

        public override string ToString()
        {
            return ""+pistes.Count();
        }
    }
}
