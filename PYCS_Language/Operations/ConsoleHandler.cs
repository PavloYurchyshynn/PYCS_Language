namespace SplitAndMerge
{
    class ConsoleHandler
    {
        public void PrintToConsole(string str, Dictionary<string, double> vars)
        {
            if (str.Contains("print(") && str.IndexOf(")") == str.Length - 1)
            {
                BasicOperationsHandler basicHandler = new BasicOperationsHandler();

                string consoleValue = str.Substring(str.IndexOf("(") + 1, str.IndexOf(")") - str.IndexOf("(") - 1);

                if (vars.ContainsKey(consoleValue))
                {
                    Console.WriteLine(vars[consoleValue]);
                } 
                else
                {
                    Console.WriteLine(basicHandler.Eval(consoleValue, vars));
                }
            } 
            else
            {
                Console.WriteLine("Incorrect syntax");
            }
        }
    }
}
