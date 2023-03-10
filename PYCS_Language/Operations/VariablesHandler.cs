namespace SplitAndMerge
{
    public class VariablesHandler
    {
        readonly ConsoleHandler consoleHandler = new ConsoleHandler();
        readonly BasicOperationsHandler basicHandler = new BasicOperationsHandler();

        public Dictionary<string, double> Variables = new Dictionary<string, double>();
        public void EditVariable(string str, VariablesHandler varsHandler, int stringIndex)
        {
            try
            {
                List<string> splitString = new List<string>(str.Split(' '));

                if (varsHandler.Variables.ContainsKey(splitString[0]) && splitString[1] == "=")
                {
                    varsHandler.Variables[splitString[0]] = basicHandler.Eval(str.Substring(str.IndexOf("=") + 1), varsHandler.Variables);
                } 
                else
                {
                    consoleHandler.PrintError(stringIndex);
                }
            }
            catch(Exception ex)
            {
                consoleHandler.PrintError(stringIndex, ex.Message);
            }
        }
        public void CreateVarible(string str, int stringIndex)
        {
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
                consoleHandler.PrintError(stringIndex, ex.Message);
            }
        }
    }
}
