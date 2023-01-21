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
                if (s.Contains(OperationsConstants.LET) && s.IndexOf(OperationsConstants.LET) == 0)
                {
                    varsHandler.VaribleOperation(s);
                }
                else if (s.Contains(OperationsConstants.IF) && s.IndexOf(OperationsConstants.IF) == 0)
                {
                    ifElseHandler.IfElseOperation(s, varsHandler);
                }
                else if (s.Contains(OperationsConstants.CONSOLE) && s.IndexOf(OperationsConstants.CONSOLE) == 0)
                {
                    consoleHandler.PrintToConsole(s, varsHandler.Variables);
                }
            }
        }
    }
}
