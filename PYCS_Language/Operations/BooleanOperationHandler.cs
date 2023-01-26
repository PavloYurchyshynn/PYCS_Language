namespace SplitAndMerge
{
    public class BooleanOperationHandler
    {
        public bool CompareValues(string str, Dictionary<string, double> vars)
        {
            str = str.Trim();
            List<string> splitString = new List<string>(str.Split(' '));

            double firstValue;
            double secondValue;

            if (vars.ContainsKey(splitString[0]) && !vars.ContainsKey(splitString[2]))
            {
                firstValue = vars[splitString[0]];
                secondValue = double.Parse(splitString[2]);
            }
            else if (vars.ContainsKey(splitString[2]) && !vars.ContainsKey(splitString[0]))
            {
                firstValue = double.Parse(splitString[0]);
                secondValue = vars[splitString[2]];
            }
            else if (vars.ContainsKey(splitString[0]) && vars.ContainsKey(splitString[2]))
            {
                firstValue = vars[splitString[0]];
                secondValue = vars[splitString[2]];
            }
            else
            {
                firstValue = double.Parse(splitString[0]);
                secondValue = double.Parse(splitString[2]);
            }
            return CompateValuesSwitch(splitString, firstValue, secondValue);
        }
        private bool CompateValuesSwitch(List<string> splitString, double firstValue, double secondValue)
        {
            switch (splitString[1])
            {
                case ">":
                    return firstValue > secondValue;
                case "<":
                    return firstValue < secondValue;
                case ">=":
                    return firstValue >= secondValue;
                case "<=":
                    return firstValue <= secondValue;
                default:
                    return false;
            }
        }
    }
}
