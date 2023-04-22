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
        enum GuessState
        {
            Higher,
            Lower,
            Correct
        }
        public static void HighLow()
        {

            Console.WriteLine("Welcome to Higher or Lower");
            Console.WriteLine();

            int userHints = SetHints();
            int number = NumberSet();

            Console.Clear();
            Console.WriteLine("I am thinking of a number between 1 and 20. I will tell you if it is higher or lower.");
            Console.WriteLine($"You have {userHints} hints and then you must guess the number.");

            int guess = SetGuess();

            while (userHints > 0 || guess == number) {
                switch (NumberGuess(guess,number))
                {
                    case GuessState.Higher:
                        Console.WriteLine("The number is higher than your guess.");
                        userHints--;
                        SetGuess();
                        break;

                    case GuessState.Lower:
                        Console.WriteLine("The number is lower than your guess.");
                        userHints--;
                        SetGuess();
                        break;

                    case GuessState.Correct:
                        Console.WriteLine($"Correct! The number is {number}!");
                        break;
                }
            }

            if (userHints == 0)
            {
                Console.WriteLine("Please you have run out of hints, please guess what the number is:");
                guess = SetGuess();

                if (guess == number)
                {
                    Console.WriteLine($"Correct! The number is {number}!");
                }
                else
                {
                    Console.WriteLine($"Sorry, the correct number was {number}");
                }
            }

        }

        private static int NumberSet()
        {
            int setNum = new Random().Next(1,20);
            return setNum;
        }

        private static GuessState NumberGuess(int guess, int number)
        {
            if (guess > number) { return GuessState.Higher; }
            else if (guess < number) { return GuessState.Lower; }
            else{return GuessState.Correct;}
        }

        private static int SetGuess()
        {
            Console.WriteLine("Please make a guess:");

            bool guessCheck = Int32.TryParse(Console.ReadLine(), out int userGuess);
            while (!guessCheck && userGuess > 0)
            {
                Console.WriteLine("This is not a valid guess to enter, please try again.");
                guessCheck = Int32.TryParse(Console.ReadLine(), out userGuess);
            }
            return userGuess;
        }

        private static int SetHints()
        {
            Console.WriteLine("Please put how many hint you want before you guess:");


            bool hintCheck = Int32.TryParse(Console.ReadLine(), out int userHints);
            while (!hintCheck && userHints < 0)
            {
                Console.WriteLine("This is not a valid number of hints to set. Please try again.");
                hintCheck = int.TryParse(Console.ReadLine(), out userHints);
            }
            return userHints;
        }
    }
}
