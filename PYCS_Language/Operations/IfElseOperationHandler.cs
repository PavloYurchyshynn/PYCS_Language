namespace SplitAndMerge
{
    class IfElseOperationHandler
    {
        public void IfElseExecutor(string value, VariablesHandler varsHandler, int stringIndex)
        {
            ConsoleHandler consoleHandler = new ConsoleHandler();
            value = value.Trim();

            if (value.Contains(OperationsConstants.LET))
            {
                varsHandler.VaribleOperation(value, stringIndex);
            }
            else if (value.Contains(OperationsConstants.CONSOLE))
            {
                consoleHandler.PrintToConsole(value, varsHandler.Variables, stringIndex);
            }
            else
            {
                consoleHandler.PrintError(stringIndex);
            }
        }
        public void IfElseOperation(string str, VariablesHandler varsHandler, int stringIndex)
        {
            BooleanOperationHandler booleanHandler = new BooleanOperationHandler();
            ConsoleHandler consoleHandler = new ConsoleHandler();

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
                    IfElseExecutor(ifValue, varsHandler, stringIndex);
                } 
                else
                {
                    IfElseExecutor(elseValue, varsHandler, stringIndex);
                }
            }
            else
            {
                consoleHandler.PrintError(stringIndex);
            }
        }
    }
}
