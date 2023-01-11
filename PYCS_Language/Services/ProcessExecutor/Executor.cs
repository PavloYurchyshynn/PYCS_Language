namespace SplitAndMerge
{
    public class Executor : IExecutor
    {
        public void Execute()
        {
            FileHandler file = new FileHandler();
            string[] text = file.ReadFile();
            TextParser parser = new TextParser();
            parser.ParseText(text);
        }
    }
}
