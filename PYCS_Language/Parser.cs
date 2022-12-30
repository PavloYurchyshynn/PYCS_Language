using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class Parser
    {

        // private static bool CanMergeCells(Variable leftCell, Variable rightCell)
        // {
        //     return GetPriority(leftCell.Action) >= GetPriority(rightCell.Action);
        // }
        private static int GetPriority(string action)
        {
            switch (action)
            {
                case "++":
                case "--": return 10;
                case "^": return 9;
                case "%":
                case "*":
                case "/": return 8;
                case "+":
                case "-": return 7;
                case "<":
                case ">":
                case ">=":
                case "<=": return 6;
                case "==":
                case "!=": return 5;
                case "&&": return 4;
                case "||": return 3;
                case "+=":
                case "=": return 2;
            }
            return 0;
        }
    }
}
