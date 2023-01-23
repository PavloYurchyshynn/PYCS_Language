namespace SplitAndMerge
{
    public class VariablesHandler
    {
        public Dictionary<string, double> Variables = new Dictionary<string, double>();
        public void VaribleOperation(string str, int stringIndex)
        {
            ConsoleHandler consoleHandler = new ConsoleHandler();
            BasicOperationsHandler basicHandler = new BasicOperationsHandler();

            try
            {
                List<string> splitString = new List<string>(str.Split(' '));

                if (splitString[0] == OperationsConstants.LET && splitString[2] == "=")
                {
                    Variables.Add(splitString[1], basicHandler.Eval(str.Substring(str.IndexOf("=") + 1), Variables));
                }
                else
                {
                    consoleHandler.PrintError(stringIndex);
                }
            }
            catch(Exception ex)
            {
                consoleHandler.PrintError(stringIndex);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
