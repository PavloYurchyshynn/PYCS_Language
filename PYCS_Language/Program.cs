
namespace SplitAndMerge
{
    public class Program
    {
        static void Main(string[] args) {
            FileHandler file = new FileHandler();
            string[] text = file.ReadFile();
            TextParser parser = new TextParser();
            parser.ParseText(text);
        }
    }
}
