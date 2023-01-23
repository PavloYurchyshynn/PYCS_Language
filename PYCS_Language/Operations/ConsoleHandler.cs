namespace SplitAndMerge
{
    class ConsoleHandler
    {
        public void PrintError(int index)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error in line {index}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintToConsole(string str, Dictionary<string, double> vars, int stringIndex)
        {
            try
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
                    PrintError(stringIndex);
                }
            }
            catch (Exception ex)
            {
                PrintError(stringIndex);
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
