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
            BasicOperationsHandler basicHandler = new BasicOperationsHandler();
            VariablesHandler varsHandler = new VariablesHandler();
            List<string> result = new List<string>();

            foreach (string s in text)
            {
                if (s.Contains(Constants.LET))
                {
                    varsHandler.VaribleOperation(s);
                } 
                else
                {
                    result.Add(Convert.ToString(basicHandler.Eval(s, varsHandler.Variables)));
                }
            }
            foreach (string el in result)
                Console.WriteLine(el);
        }
    }
}
