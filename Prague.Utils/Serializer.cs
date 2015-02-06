using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prague.Utils
{
    public static class Serializer
    {
        public static void Serialize<T> (T toSerialize, string filename) 
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, toSerialize);
            writer.Close();
        }

        public static T Deserialize<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            TextReader reader = new StreamReader(fileName);            
            var result = (T)serializer.Deserialize(reader);
            reader.Close();
            return result;

        }
    }
}
