using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class BasicOperationsHandler
    {
        public double Eval(string exp, Dictionary<string, double> vars)
        {
            int operatorIndex = -1;

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];
                if ((c == '+' || c == '-'))
                {
                    operatorIndex = i;
                    break;
                }
                else if ((c == '*' || c == '/') && operatorIndex < 0)
                {
                    operatorIndex = i;
                }
            }
            if (operatorIndex < 0)
            {
                exp = exp.Trim();
                if (vars.ContainsKey(exp))
                    return vars[exp];
                else
                    return double.Parse(exp);
            }
            else
            {
                switch (exp[operatorIndex])
                {
                    case '+':
                        return Eval(exp.Substring(0, operatorIndex), vars) + Eval(exp.Substring(operatorIndex + 1), vars);
                    case '-':
                        return Eval(exp.Substring(0, operatorIndex), vars) - Eval(exp.Substring(operatorIndex + 1), vars);
                    case '*':
                        return Eval(exp.Substring(0, operatorIndex), vars) * Eval(exp.Substring(operatorIndex + 1), vars);
                    case '/':
                        return Eval(exp.Substring(0, operatorIndex), vars) / Eval(exp.Substring(operatorIndex + 1), vars);
                }
            }
            return 0;
        }
    }
}
