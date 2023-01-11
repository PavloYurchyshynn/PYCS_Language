namespace SplitAndMerge
{
    public class BasicOperationsHandler
    {
        public double Factorial(double n)
        {
            if (n == 1) return n;

            return n * Factorial(n - 1);
        }
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
                else if ((c == '*' || c == '/' || c == '!') && operatorIndex < 0)
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
                    case '!':
                        return Factorial(Eval(exp.Substring(0, operatorIndex), vars));
                }
            }
            return 0;
        }
    }
}
