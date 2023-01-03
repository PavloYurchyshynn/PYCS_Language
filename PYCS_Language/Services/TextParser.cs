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
                        int leftValue = Convert.ToInt32(words[i - 1]);
                        int rightValue = Convert.ToInt32(words[i + 1]);
                        var operationResult = handler.AddOperation(leftValue, rightValue);
                        result.Add(operationResult);
                    } else if (words[i] == Constants.MINUS)
                    {
                        int leftValue = Convert.ToInt32(words[i - 1]);
                        int rightValue = Convert.ToInt32(words[i + 1]);
                        var operationResult = handler.MinusOperation(leftValue, rightValue);
                        result.Add(operationResult);
                    } else if (words[i] == Constants.MULTIPLY)
                    {
                        int leftValue = Convert.ToInt32(words[i - 1]);
                        int rightValue = Convert.ToInt32(words[i + 1]);
                        var operationResult = handler.MultiplyOperation(leftValue, rightValue);
                        result.Add(operationResult);
                    } else if (words[i] == Constants.DIVIDE)
                    {
                        int leftValue = Convert.ToInt32(words[i - 1]);
                        int rightValue = Convert.ToInt32(words[i + 1]);
                        var operationResult = handler.DivideOperation(leftValue, rightValue);
                        result.Add(operationResult);
                    }
                }
            }
            foreach (string el in result)
                Console.WriteLine(el);
        }
    }
}
