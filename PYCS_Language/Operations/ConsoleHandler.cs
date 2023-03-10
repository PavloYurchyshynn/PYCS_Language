namespace SplitAndMerge
{
    public class ConsoleHandler
    {
        readonly BasicOperationsHandler basicHandler = new BasicOperationsHandler();
        public void PrintError(int index, string message = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error in line {index} {message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void PrintToConsole(string str, Dictionary<string, double> vars, int stringIndex)
        {
            try
            {
                if (str.Contains("print(") && str.IndexOf(")") == str.Length - 1)
                {
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
                PrintError(stringIndex, ex.Message);
            }
            
        }
    }
}
