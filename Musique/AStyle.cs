using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    [DataContract(Name = "AStyle", Namespace = "Musique")]

    public abstract class AStyle
    {

        [DataMember()]
        public int bpmMax
        {
            get;

            set;
        }

        [DataMember()]
        public int bpmMin
        {
            get;

            set;

        }
        public  float tempo()
        {
            return (60.0f / calcBpm()) * 1000;
        }

        public int calcBpm()
        {
            return (bpmMin + bpmMax) / 2;
        }

    }

}
