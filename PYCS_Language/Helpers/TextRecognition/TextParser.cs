namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        readonly VariablesHandler varsHandler = new VariablesHandler();
        readonly IfElseOperationHandler ifElseHandler = new IfElseOperationHandler();
        readonly ConsoleHandler consoleHandler = new ConsoleHandler();
        readonly WhileOperationHandler whileHandler = new WhileOperationHandler();

        public void ParseString(string str, int stringIndex, VariablesHandler varsHandler)
        {
            try
            {
                str = str.Trim();

                List<string> splitString = new List<string>(str.Split(' '));

                if (str.Contains(OperationsConstants.LET) && str.IndexOf(OperationsConstants.LET) == 0)
                {
                    varsHandler.CreateVarible(str, stringIndex);
                }
                else if (varsHandler.Variables.ContainsKey(splitString[0]))
                {
                    varsHandler.EditVariable(str, varsHandler, stringIndex);
                }
                else if (str.Contains(OperationsConstants.IF) && str.IndexOf(OperationsConstants.IF) == 0)
                {
                    ifElseHandler.IfElseOperation(str, varsHandler, stringIndex);
                }
                else if (str.Contains(OperationsConstants.CONSOLE) && str.IndexOf(OperationsConstants.CONSOLE) == 0)
                {
                    consoleHandler.PrintToConsole(str, varsHandler.Variables, stringIndex);
                }
                else if (str.Contains(OperationsConstants.WHILE) && str.IndexOf(OperationsConstants.WHILE) == 0)
                {
                    whileHandler.WhileOperation(str, varsHandler, stringIndex);
                }
            }
            catch (Exception ex)
            {
                consoleHandler.PrintError(stringIndex, ex.Message);
            }
        }
        public void ParseText(string[] text)
        {
            int stringIndex = 0;

            foreach (string s in text)
            {
                stringIndex++;
                ParseString(s, stringIndex, varsHandler);
            }
        }
    }
}
