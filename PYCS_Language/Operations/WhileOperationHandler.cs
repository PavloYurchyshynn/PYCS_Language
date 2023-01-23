namespace SplitAndMerge
{
    class WhileOperationHandler
    {
        public void WhileOperation(string str, VariablesHandler varsHandler, int stringIndex)
        {
            BooleanOperationHandler booleanHandler = new BooleanOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();
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
                Console.WriteLine(ex.Message);
                consoleHandler.PrintError(stringIndex);
            }
        }
    }
}
