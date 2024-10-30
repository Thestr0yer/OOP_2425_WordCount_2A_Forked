using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_WordCount_2A
{
    internal class File_Thing
    {
        public string fileName = "";
        private List<string> content = new List<string>();
        private List<string> words = new List<string>();
        private List<WordNCount> wordNCounts = new List<WordNCount>();

        public void Read()
        {
            string message = "";
            FileManager.Read(fileName, out content, out message);
            Console.WriteLine(message);
        }

        public void CountWords()
        {
            string[] temp = new string[] { };

            foreach(string c in content)
            {
                temp = c.ToUpper().Split(' ');
                foreach(string t in temp)
                {
                    words.Add(t);
                }
            }
        }

        public void FindInstances()
        {
            WordNCount temp = new WordNCount();
            int index = -1;

            foreach(string word in words)
            {
                index = -1;
                if (Contains(word, out index))
                {
                    wordNCounts[index].count++;
                }
                else
                {
                    temp = new WordNCount();
                    temp.word = word;
                    temp.count = 1;
                    wordNCounts.Add(temp);
                }    
            }
        }

        private bool Contains(string word, out int index)
        {
            for(int a = 0; a < wordNCounts.Count; a++)
            {
                if(wordNCounts[a].word.Equals(word))
                {
                    index = a;
                    return true;
                }
            }
            index = -1;     
            return false;
        }

        public void DisplayAllInstances()
        {
            Console.WriteLine($"Under the file {fileName}...");
            foreach(WordNCount word in wordNCounts)
            {
                Console.WriteLine($"The word {word.word} appeard {word.count} times");
            }
        }

        public int getWordCount()
        {
            return words.Count;
        }

        // Sort the wordNCounts list descending order using its
        // count
    }
}
