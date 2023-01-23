namespace SplitAndMerge
{
    class IfElseOperationHandler
    {
        public void IfElseOperation(string str, VariablesHandler varsHandler, int stringIndex)
        {
            BooleanOperationHandler booleanHandler = new BooleanOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();
            TextParser textParser = new TextParser();

            try
            {
                string ifBoolValue = str.Substring(str.IndexOf("(") + 1, str.IndexOf(")") - str.IndexOf("(") - 1);
                string ifValue = str.Substring(str.IndexOf("{") + 1, str.IndexOf("}") - str.IndexOf("{") - 1);
                string elseString = str.Substring(str.IndexOf(OperationsConstants.ELSE) == -1 ? 0 : str.IndexOf("else"));
                string elseValue = elseString.Substring(elseString.IndexOf("{") + 1, elseString.IndexOf("}") - elseString.IndexOf("{") - 1);
                str = str.Replace(ifBoolValue, "");
                str = str.Replace(ifValue, "");
                str = str.Replace(elseValue, "");
                List<string> splitString = new List<string>(str.Split(' '));

                if (splitString[0] == OperationsConstants.IF &&
                    splitString[1].StartsWith("(") &&
                    splitString[1].EndsWith(")") &&
                    splitString[2].StartsWith("{") &&
                    splitString[2].EndsWith("}"))
                {
                    if (booleanHandler.CompareValues(ifBoolValue, varsHandler.Variables))
                    {
                        textParser.ParseString(ifValue, stringIndex, varsHandler);
                    }
                    else
                    {
                        textParser.ParseString(elseValue, stringIndex, varsHandler);
                    }
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
    }
}
