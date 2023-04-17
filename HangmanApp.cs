using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Code_Project_AltHaus;

namespace Code_Project_AltHaus
{
    internal class HangmanApp
    {
        public static void Hangman()
        {
            Console.WriteLine("Welcome to Hangman");

            HangmanStart:

            int userAttempts = AttemptCount();
            string thisWord = WordGetter();
            string obscuredWord = ObscureBuilder(thisWord);

            Console.Clear();

            while (userAttempts > 0 && obscuredWord != thisWord && userAttempts != 0)
            {

            Console.WriteLine($"This word has {thisWord.Length} letters in it.");
            Console.WriteLine(obscuredWord);
            Console.WriteLine("Please input a character to guess:");
            Console.WriteLine($"You have {userAttempts} lives left");
            Console.WriteLine();

            bool isValid = Char.TryParse(Console.ReadLine(), out char charInput);

                while (!isValid || !char.IsLetter(charInput))
                {
                    Console.Clear();
                    Console.WriteLine("This is not a valid letter, please try again.");
                    isValid = Char.TryParse(Console.ReadLine(), out charInput);
                }

                Console.WriteLine(thisWord);

                if (thisWord.Contains(charInput)) {
                    obscuredWord = CharAttempt(charInput, thisWord, obscuredWord);
                    Console.Clear();
                }
                else
                {
                    userAttempts--;
                    Console.Clear();
                    Console.WriteLine($"{charInput.ToString().ToUpper()} is not a character in the word, please try again.");
                }
            }

            if (userAttempts == 0)
            {
                Console.Clear();
                Console.WriteLine($"Sorry, you have lost. The word was: {thisWord.ToUpper()}.");
                Console.WriteLine();
            }
            else if (obscuredWord == thisWord)
            {
                Console.Clear();
                Console.WriteLine($"You won! The full word was: {thisWord.ToUpper()}");
                Console.WriteLine();
            }

            SelectionRetry:
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("0: Quit Hangman");
            Console.WriteLine("1: Play another game of Hangman");

            Int32.TryParse(Console.ReadLine(), out int selection);

            switch (selection)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    Console.Clear();
                    goto HangmanStart;
                default:
                    Console.Clear();
                    Console.WriteLine("This is not a valid selection, please try again.");
                    goto SelectionRetry;
            }
        }

        private static int AttemptCount()
        {

            Console.WriteLine("How many lives would you like to have on this attempt?");

            bool check = Int32.TryParse(Console.ReadLine(), out int count);

            while (check == false || count < 1)
            {
                Console.WriteLine("This is not a valid number of attempts, please try again");
                check = Int32.TryParse(Console.ReadLine(), out count);
            }

            return count;

            
        }

        private static string WordGetter()
        {
            string[] lines = HangmanWords.HangmanWordList();

            Random random = new();
            int randomLine = random.Next(0, lines.Length - 1);

            string selectedWord = lines[randomLine];
            
            return selectedWord;
        }

        private static string ObscureBuilder(string origin)
        {
            StringBuilder outString = new();

            foreach (char letter in origin)
            {
                outString.Append('_');
            }

            return outString.ToString();
        }

        private static string CharAttempt(char c, string origin, string current)
        {
            int i = 0;
            StringBuilder newSB = new();
            foreach (char letter in origin)
            {

                if (letter == c || current[i] == origin[i])
                {
                    newSB.Append(letter);
                }
                else
                {
                    newSB.Append('_');
                }
                i++;
            }

            string newCurrent = newSB.ToString();

            return newCurrent;
        }
    }
}
