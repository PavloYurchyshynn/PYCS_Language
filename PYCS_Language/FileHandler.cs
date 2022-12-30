using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitAndMerge
{
    public class FileHandler : IFileHandler
    {
        public static void ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\pasha\dotnet\PYCS_Language\PYCS_Language\TextFile.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
