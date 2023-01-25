namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        public void ParseString(string str, int stringIndex, VariablesHandler varsHandler)
        {
            IfElseOperationHandler ifElseHandler = new IfElseOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();
            WhileOperationHandler whileHandler = new WhileOperationHandler();
            str = str.Trim();

            try
            {
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
                else
                {
                    consoleHandler.PrintError(stringIndex);
                }
            }
            catch (Exception ex)
            {
                consoleHandler.PrintError(stringIndex);
                Console.WriteLine(ex.Message);
            }
        }
        public void ParseText(string[] text)
        {
            VariablesHandler varsHandler = new VariablesHandler();
            int stringIndex = 0;

            foreach (string s in text)
            {
                stringIndex++;
                ParseString(s, stringIndex, varsHandler);
            }
        }
    }
}
