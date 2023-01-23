namespace SplitAndMerge
{
    public class Executor : IExecutor
    {
        public void Execute()
        {
            try
            {
                FileHandler file = new FileHandler();
                string[] text = file.ReadFile();
                TextParser parser = new TextParser();
                parser.ParseText(text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
