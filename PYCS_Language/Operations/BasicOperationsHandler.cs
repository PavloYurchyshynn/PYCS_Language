using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class BasicOperationsHandler
    {
        public string AddOperation(int a, int b)
        {
            return $"{a + b}";
        }
        public string MinusOperation(int a, int b)
        {
            return $"{a - b}";
        }
        public string MultiplyOperation(int a, int b)
        {
            return $"{a * b}";
        }
        public string DivideOperation(int a, int b)
        {
            return $"{a / b}";
        }
    }
}
