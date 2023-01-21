namespace SplitAndMerge
{
    public class VariablesHandler
    {
        public Dictionary<string, double> Variables = new Dictionary<string, double>();
        public void VaribleOperation(string str)
        {
            BasicOperationsHandler basicHandler = new BasicOperationsHandler();
            List<string> splitString = new List<string>(str.Split(' '));

            if (splitString[0] == OperationsConstants.LET && splitString[2] == "=")
            {
                Variables.Add(splitString[1], basicHandler.Eval(str.Substring(str.IndexOf("=") + 1), Variables));
            }
        }
    }
}
