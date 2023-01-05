using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        public void ParseText(string[] text)
        {
            BasicOperationsHandler handler = new BasicOperationsHandler();
            List<string> result = new List<string>();
            Dictionary<string, double> vars = new Dictionary<string, double>();
            vars.Add("x", 2.50); // this variable is hardcoded now

            foreach (string s in text)
            {
                string stringResult = Convert.ToString(handler.Eval(s, vars));
                result.Add(stringResult);
            }
            foreach (string el in result)
                Console.WriteLine(el);
        }
    }
}
