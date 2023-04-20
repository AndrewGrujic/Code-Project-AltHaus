using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using Code_Project_AltHaus;

namespace Code_Project_AltHaus
{
    internal class Program
    {
        public static void Main()
        {
            //Simple string array to add new possible programs easily.
            string[] apps = {"Quit","Pension", "BMI Calculator", "Hangman"};

        
            Console.WriteLine("Hello there, Please select an app.");
            Console.WriteLine();
        RetrySelect:
            Console.WriteLine($"Please select between 1 and {apps.Length - 1}.");
            Console.WriteLine("Alternatively, enter 0 to exit.");
            Console.WriteLine();


            //Forms the app array into a list of options that the user can see and select.
            int i = 0;
            foreach (var appString in apps)
            {
                Console.WriteLine($"{i++}: {appString}");
            }

            //Parses an input and selects the appropriate app to open.
            bool isValid = Int32.TryParse(Console.ReadLine(), out int appNum);
            if ( appNum == 0 && isValid ) {Console.WriteLine("Quitting..."); return;}

            switch (appNum)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine("Quitting...");
                    Environment.Exit(0);
                    return;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Opening Pension Calculator.");
                    Console.WriteLine();
                    PensionApp.Pension();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Opening BMI Calculator.");
                    Console.WriteLine() ;
                    BMIApp.BMI();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Opening Hangman.");
                    Console.WriteLine();
                    HangmanApp.Hangman();
                    break;

                default:
                    Console.Clear();

                    Console.WriteLine("This is not a valid selection. Please Try again.");
                    Console.WriteLine();
                    break;
            }

            goto RetrySelect;
        }
    }
}