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
            //Goes to various methods creates to set the intial variables.
            int userAttempts = AttemptCount();
            string thisWord = WordGetter();
            string obscuredWord = ObscureBuilder(thisWord);

            Console.Clear();

            //Running loop to make sure the game keeps running till the word is complete or the user has run out of attempts.
            while (userAttempts != 0 && obscuredWord != thisWord)
            {

            Console.WriteLine($"This word has {thisWord.Length} letters in it.");
            Console.WriteLine(obscuredWord);
            Console.WriteLine();
            Console.WriteLine("Please input a character to guess:");
            Console.WriteLine($"You have {userAttempts} lives left");
            Console.WriteLine();

            //Parse and check to get the user input for a char.
            bool isValidChar = Char.TryParse(Console.ReadLine(), out char charInput);

                while (!isValidChar || !char.IsLetter(charInput))
                {
                    Console.Clear();
                    Console.WriteLine("This is not a valid letter, please try again.");
                    isValidChar = Char.TryParse(Console.ReadLine(), out charInput);
                }

                //A check once a valid char is input, it is checked to see whether it is in the word or not.
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

            //if statement to check if the user has either won or lost.
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

            //Parses and validates the selection on if the user wants to quit out or retry.
            bool isValid = Int32.TryParse(Console.ReadLine(), out int selection);
            if (selection < 0 || !isValid)
            {
                Console.WriteLine("This is not a valid selection, please try again.");
                goto SelectionRetry;
            }

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

        //Method to set the amount of lives the user wants to have in order to attempt the word.
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

        /*This method is sort of hacky, the list is hardcoded into another class as a string array and is fetched from that class.
        From there it selects at random a value from that array and returns it to the main method.
        It's not the best way as it loads in an entire array taking up an unnecessary amount of memory, but it's quickly cleared after and is easier to implement.
        */
        private static string WordGetter()
        {
            string[] lines = HangmanWords.HangmanWordList();

            Random random = new();
            int randomLine = random.Next(0, lines.Length - 1);

            string selectedWord = lines[randomLine];
            
            return selectedWord;
        }

        //This takes the selected word and creates a new string the same length which is completely obscured.
        private static string ObscureBuilder(string origin)
        {
            StringBuilder outString = new();

            //This says it is an unnecessary of a value to letter but there isn't a cleaner way I could think to do it.
            foreach (char letter in origin)
            {
                outString.Append('_');
            }

            return outString.ToString();
        }

        //This checks for if the user input for a char fits somewhere within the word, to note is if the char is already there, it doesn't take away an attempt.
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
