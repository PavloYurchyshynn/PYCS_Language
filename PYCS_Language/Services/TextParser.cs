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

            foreach (string s in text)
            {
                List<string> words = new List<string>(s.Split(new char[] { ' ' }));

                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i] == Constants.PLUS)
                    {
                        result.Add(handler.AddOperation(Convert.ToInt32(words[i - 1]), Convert.ToInt32(words[i + 1])));
                    }
                    if (words[i] == Constants.MINUS)
                    {
                        result.Add(handler.MinusOperation(Convert.ToInt32(words[i - 1]), Convert.ToInt32(words[i + 1])));
                    }
                    if (words[i] == Constants.MULTIPLY)
                    {
                        result.Add(handler.MultiplyOperation(Convert.ToInt32(words[i - 1]), Convert.ToInt32(words[i + 1])));
                    }
                    if (words[i] == Constants.DIVIDE)
                    {
                        result.Add(handler.DivideOperation(Convert.ToInt32(words[i - 1]), Convert.ToInt32(words[i + 1])));
                    }
                }
            }
            foreach (string el in result)
                Console.WriteLine(el);
        }
    }
}
