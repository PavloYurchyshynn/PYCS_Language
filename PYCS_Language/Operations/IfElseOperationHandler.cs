namespace SplitAndMerge
{
    class IfElseOperationHandler
    {
        public void IfElseExecutor(string value, VariablesHandler varsHandler)
        {
            ConsoleHandler consoleHandler = new ConsoleHandler();
            value = value.Trim();

            if (value.Contains(OperationsConstants.LET))
            {
                varsHandler.VaribleOperation(value);
            }
            else if (value.Contains(OperationsConstants.CONSOLE))
            {
                consoleHandler.PrintToConsole(value, varsHandler.Variables);
            }
            else
            {
                Console.WriteLine("Incorrect sintax");
            }
        }
        public void IfElseOperation(string str, VariablesHandler varsHandler)
        {
            BooleanOperationHandler booleanHandler = new BooleanOperationHandler();

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
                    IfElseExecutor(ifValue, varsHandler);
                } 
                else
                {
                    IfElseExecutor(elseValue, varsHandler);
                }
            }
            else
            {
                Console.WriteLine("Incorrect sintax");
            }
        }
    }
}
