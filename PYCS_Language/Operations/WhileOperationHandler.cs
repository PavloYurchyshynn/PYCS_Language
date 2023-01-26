namespace SplitAndMerge
{
    public class WhileOperationHandler
    {
        readonly BooleanOperationHandler booleanHandler = new BooleanOperationHandler();
        readonly ConsoleHandler consoleHandler = new ConsoleHandler();
        public void WhileOperation(string str, VariablesHandler varsHandler, int stringIndex)
        {
            TextParser textParser = new TextParser();

            try
            {
                string boolValue = str.Substring(str.IndexOf("(") + 1, str.IndexOf(")") - str.IndexOf("(") - 1);
                string whileValue = str.Substring(str.IndexOf("{") + 1, str.IndexOf("}") - str.IndexOf("{") - 1);
                str = str.Replace(boolValue, "");
                str = str.Replace(whileValue, "");
                List<string> splitString = new List<string>(str.Split(' '));

                if (splitString[0] == OperationsConstants.WHILE &&
                    splitString[1].StartsWith("(") &&
                    splitString[1].EndsWith(")") &&
                    splitString[2].StartsWith("{") &&
                    splitString[2].EndsWith("}"))
                {
                    while (booleanHandler.CompareValues(boolValue, varsHandler.Variables))
                    {
                        textParser.ParseString(whileValue, stringIndex, varsHandler);
                    }
                }
                else
                {
                    consoleHandler.PrintError(stringIndex);
                }
            }
            catch (Exception ex)
            {
                consoleHandler.PrintError(stringIndex, ex.Message);
            }
        }
    }
}
