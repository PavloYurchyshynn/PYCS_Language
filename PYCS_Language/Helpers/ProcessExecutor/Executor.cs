namespace SplitAndMerge
{
    public class Executor : IExecutor
    {
        readonly IFileHandler file = new FileHandler();
        readonly ITextParser parser = new TextParser();

        public void Execute()
        {
            try
            {
                string[] text = file.ReadFile();
                parser.ParseText(text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
