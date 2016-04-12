using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Music
{
    class SaverLoader<T>
    {
        public static Object read(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            Object o=(T)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
            return (T)o;
            
        }

        public static void save(Object o, string fileName)
        {
            FileStream writer = new FileStream(fileName, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, o);
            writer.Close();
        }
    }
}
