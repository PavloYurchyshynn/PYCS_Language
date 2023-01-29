namespace SplitAndMerge
{
    public class FileHandler : IFileHandler
    {
        public string path = @"C:\Users\pasha\dotnet\PYCS_Language\PYCS_Language\TextFile.txt";
        public string[] ReadFile()
        {
            return File.ReadAllLines(path);
        }
    }
}
