using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_WordCount_2A
{
    static internal class FileManager
    {
        public static bool Read(string fileName, out List<string> content, out string message)
        {
            content = new List<string>();

            if (File.Exists(Directory.activeDir + fileName))
            {
                using (StreamReader sr = new StreamReader(Directory.activeDir + fileName))
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        content.Add(line);
                    }
                }
                message = $"{fileName} has been successfully read. It contains {content.Count} lines.";
                return true;
            }

            message = $"Failed to read {fileName}. Please check if it exists or is not open.";
            return false;
        }

        public static void Write(string fileName, List<string> content, bool append = false) 
        {
            using (StreamWriter sw = new StreamWriter(Directory.activeDir + fileName, append))
            {
                foreach (string c in content)
                {
                    sw.WriteLine(c);
                }
            }
        }
    }
}
