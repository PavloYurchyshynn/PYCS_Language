namespace SplitAndMerge
{
    public interface ITextParser
    {
        void ParseString(string text, int stringIndex, VariablesHandler varsHandler);
        void ParseText(string[] text);
    }
}
