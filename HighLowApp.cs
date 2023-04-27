using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Code_Project_AltHaus
{
    internal class HighLowApp
    {
        private enum GuessState
        {
            Higher,
            Lower,
            Correct
        }
        public static void HighLow()
        {
            Console.WriteLine("Welcome to Higher or Lower");
            Console.WriteLine();
        HighLowStart:
            int userHints = SetHints();
            int number = SetNumbers();

            Console.Clear();
            Console.WriteLine("I am thinking of a number between 1 and 20. I will tell you if it is higher or lower.");
            Console.WriteLine($"You have {userHints} hints and then you must guess the number.");

            int guess = 0;

            while (userHints != 0 && guess != number)
            {
                guess = SetGuess();

                switch (NumberGuess(guess,number))
                {
                    case GuessState.Higher:
                        Console.Clear();
                        Console.WriteLine("The number is higher than your guess.");
                        userHints--;
                        break;

                    case GuessState.Lower:
                        Console.Clear();
                        Console.WriteLine("The number is lower than your guess.");
                        userHints--;
                        break;

                    case GuessState.Correct:
                        Console.Clear();
                        Console.WriteLine($"Correct! The number is {number}!");
                        Console.WriteLine();
                        break;
                }
            }

            if (userHints == 0)
            {
                Console.WriteLine("Please you have run out of hints, please guess what the number is:");
                guess = SetGuess();

                if (guess == number)
                {
                    Console.Clear();
                    Console.WriteLine($"Correct! The number is {number}!");
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Sorry, the correct number was {number}");
                    Console.WriteLine();
                }
            }

        SelectionRetry:
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("0: Quit Higher or Lower");
            Console.WriteLine("1: Play another game of Higher or Lower");

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
                    goto HighLowStart;
                default:
                    Console.Clear();
                    Console.WriteLine("This is not a valid selection, please try again.");
                    goto SelectionRetry;
            }

        }

        private static int SetNumbers()
        {
            int setNum = new Random().Next(1,20);
            return setNum;
        }

        private static GuessState NumberGuess(int guess, int number)
        {
            if (guess < number) { return GuessState.Higher; }
            else if (guess > number) { return GuessState.Lower; }
            else{return GuessState.Correct;}
        }

        private static int SetGuess()
        {
            Console.WriteLine("Please make a guess:");

            bool guessCheck = Int32.TryParse(Console.ReadLine(), out int userGuess);
            while (!guessCheck || userGuess < 1)
            {
                Console.WriteLine("This is not a valid guess to enter, please try again.");
                guessCheck = Int32.TryParse(Console.ReadLine(), out userGuess);
            }
            return userGuess;
        }

        private static int SetHints()
        {
            Console.WriteLine("Please put how many hints you want before you guess:");

            bool hintCheck = Int32.TryParse(Console.ReadLine(), out int userHints);
            while (!hintCheck || userHints < 0)
            {
                Console.WriteLine("This is not a valid number of hints to set. Please try again.");
                hintCheck = int.TryParse(Console.ReadLine(), out userHints);
            }
            return userHints;
        }
    }
}
