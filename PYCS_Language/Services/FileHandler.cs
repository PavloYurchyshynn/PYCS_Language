using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplitAndMerge
{
    public class FileHandler : IFileHandler
    {
        public string path = @"C:\Users\pasha\dotnet\PYCS_Language\PYCS_Language\TextFile.txt";
        public string[] ReadFile()
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
