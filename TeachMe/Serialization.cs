using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeachMe
{
    class Serialization
    {
        public static void SerializeXML(List<Word> words, string dest)
        {
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Word>));
                TextWriter WriteFileStream = new StreamWriter(dest);
                xmls.Serialize(WriteFileStream, words);
                WriteFileStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<Word> DeserializeXML(string src)
        {
            List<Word> res = new List<Word>();
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<Word>));
                TextReader tr = new StreamReader(src);
                res = (List<Word>)xmls.Deserialize(tr);
                tr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            return res;
        }
    }
}
