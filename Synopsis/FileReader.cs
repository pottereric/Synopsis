using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Synopsis
{
    public class FileReader
    {
        public static string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
