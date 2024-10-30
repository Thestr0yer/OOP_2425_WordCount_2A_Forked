using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_WordCount_2A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string message = "";
            File_Thing[] files = new File_Thing[] { };

            FileManager.Read(Directory.mainList, out list, out message);
            Console.WriteLine($"List.txt contains {list.Count} files to be read...");

            files = new File_Thing[list.Count];

            for( int a = 0; a < list.Count; a++ )
            {
                files[a] = new File_Thing();
                files[a].fileName = list[a];
                files[a].Read();
                files[a].CountWords();
                files[a].FindInstances();
                files[a].DisplayAllInstances();
                Console.WriteLine($"{files[a].fileName} contains {files[a].getWordCount()} words.\n\n");
            }

            Console.ReadKey();
        }
    }
}
