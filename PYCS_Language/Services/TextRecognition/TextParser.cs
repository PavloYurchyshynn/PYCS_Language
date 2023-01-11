namespace SplitAndMerge
{
    public class TextParser : ITextParser
    {
        public void ParseText(string[] text)
        {
            BasicOperationsHandler basicHandler = new BasicOperationsHandler();
            VariablesHandler varsHandler = new VariablesHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();

            foreach (string s in text)
            {
                if (s.Contains(BasicOperationsConstants.LET))
                {
                    varsHandler.VaribleOperation(s);
                }
                else if (s.Contains(BasicOperationsConstants.CONSOLE))
                {
                    consoleHandler.PrintToConsole(s, varsHandler.Variables);
                }
            }
        }
    }
}
