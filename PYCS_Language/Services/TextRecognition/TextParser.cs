namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        public void ParseText(string[] text)
        {
            VariablesHandler varsHandler = new VariablesHandler();
            IfElseOperationHandler ifElseHandler = new IfElseOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();

            foreach (string s in text)
            {
                if (s.Contains(BasicOperationsConstants.LET) && s.IndexOf(BasicOperationsConstants.LET) == 0)
                {
                    varsHandler.VaribleOperation(s);
                }
                else if (s.Contains(BasicOperationsConstants.IF) && s.IndexOf(BasicOperationsConstants.IF) == 0)
                {
                    ifElseHandler.IfElseOperation(s, varsHandler);
                }
                else if (s.Contains(BasicOperationsConstants.CONSOLE) && s.IndexOf(BasicOperationsConstants.CONSOLE) == 0)
                {
                    consoleHandler.PrintToConsole(s, varsHandler.Variables);
                }
            }
        }
    }
}
