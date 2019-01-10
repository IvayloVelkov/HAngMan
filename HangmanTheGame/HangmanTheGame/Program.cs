using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanTheGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int level = 0;
            string character = "";
            bool confirmed = false;
            bool isLevel = false;

            Hangman startGame = new Hangman();

            Console.WriteLine("Hello! Lets start Hangman game");
            do 
            {

               

                while (!isLevel)
                {
                    Console.Write("Select Level 1-3: ");
                    string x = Console.ReadLine();
                    int value;

                    if (int.TryParse(x, out value))
                    {
                        level = value;
                        character = startGame.GetWord(level).ToUpper();
                        isLevel = true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, then input is not a level. Choose again.");
                        isLevel = false;
                    }
                }
             

                if (PlayGame(character))
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You lost! It was '{0}'", character);
 
                    ConsoleKey response;
                    do
                    {
                        Console.Write("Do you want to play again? [y/n] ");
                        response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                        if (response != ConsoleKey.Enter)
                            Console.WriteLine();

                    } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                    confirmed = response == ConsoleKey.Y;
                    isLevel = false;
            } while (confirmed);


            Console.WriteLine("Bye Bye!");
            return;

        }

        private static bool PlayGame(string word)
        {
            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 5;
            bool won = false;
            int lettersRevealed = 1;

            string input = "";
            char guess;
            
            string FirstWord;
            string HangWord;


            char c = word[0];
            FirstWord = c.ToString();
            HangWord = word.Substring(1);

            StringBuilder displayToPlayer = new StringBuilder();
            displayToPlayer.Append(FirstWord);
            for (int i = 1; i < HangWord.Length + 1; i++)
                displayToPlayer.Append('_');

            Console.WriteLine(displayToPlayer);

            while (!won && lives > 0)
            {
                Console.WriteLine("Guess a Letter: ");
                input = Console.ReadLine().ToUpper();

                if (input != "")
                {
                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                        continue;
                    }

                    if (word.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < word.Length; i++)
                        {
                            if (word[i] == guess)
                            {
                                if (displayToPlayer[i] == '_')
                                {
                                    displayToPlayer[i] = word[i];
                                    lettersRevealed++;
                                }

                            }
                        }

                        if (lettersRevealed == word.Length)
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);
                        Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                        lives--;
                    }

                    Console.WriteLine(displayToPlayer.ToString());
                }
            }
            return won;
        }
    }
}

