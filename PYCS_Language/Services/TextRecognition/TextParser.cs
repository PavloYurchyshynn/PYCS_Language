namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        public void ParseText(string[] text)
        {
            VariablesHandler varsHandler = new VariablesHandler();
            IfElseOperationHandler ifElseHandler = new IfElseOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();
            int stringIndex = 0;

            try
            {
                foreach (string s in text)
                {
                    stringIndex++;
                    if (s.Contains(OperationsConstants.LET) && s.IndexOf(OperationsConstants.LET) == 0)
                    {
                        varsHandler.VaribleOperation(s, stringIndex);
                    }
                    else if (s.Contains(OperationsConstants.IF) && s.IndexOf(OperationsConstants.IF) == 0)
                    {
                        ifElseHandler.IfElseOperation(s, varsHandler, stringIndex);
                    }
                    else if (s.Contains(OperationsConstants.CONSOLE) && s.IndexOf(OperationsConstants.CONSOLE) == 0)
                    {
                        consoleHandler.PrintToConsole(s, varsHandler.Variables, stringIndex);
                    }
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
