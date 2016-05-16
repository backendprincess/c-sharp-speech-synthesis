using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeachMe
{
    [Serializable]
    public class Word
    {
        public String content;
        public Word(string content)
        {
            this.content = content;
        }
        public Word() { }

        override public string ToString()
        {
            return content;
        }
    }
}
