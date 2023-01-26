namespace SplitAndMerge
{
    public class Program
    {
        static void Main() {
            IExecutor parser = new Executor();
            parser.Execute();
        }
    }
}
