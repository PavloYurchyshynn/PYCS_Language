using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class Parser : IParser
    {
        public void Parse()
        {
            FileHandler file = new FileHandler();
            string[] text = file.ReadFile();
            TextParser parser = new TextParser();
            parser.ParseText(text);
        }
    }
}
