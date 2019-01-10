using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanTheGame
{
    class Hangman
    {
        private int word;

        private string hang;

        private List<string> words = new List<string>();

        static Random rnd = new Random();

        private string[] allWords;
     
        public Hangman()
        {
            
        }


        public string GetWord(int level)
        {
          
            this.allWords = File.ReadAllLines(@"C:\Users\ivaylo.velkov\Desktop\Projects\Hangman.txt");

            foreach (string s in this.allWords)
            {
                switch (level)
                {
                    case 1:
                        if (s.Length <= 5)
                        {
                            words.Add(s);
                        }
                        break;
                    case 2:
                        if (s.Length <= 10 & s.Length > 5)
                        {
                            words.Add(s);
                        }

                        break;
                    case 3:
                        if (s.Length > 10)
                        {
                            words.Add(s);
                        }
                        break;
                }
            }

            this.word = rnd.Next(words.Count);



            hang = (string)words[this.word];
            words.Clear();

            return hang;
        }
    }
}
