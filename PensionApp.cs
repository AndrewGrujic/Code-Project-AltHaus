using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Code_Project_AltHaus
{
    internal class PensionApp
    {
        public static void Pension()
        {
            Console.WriteLine("Welcome to the Pension Calculator");

        PensionStart:
            Console.WriteLine("Please enter how many years you have worked for:");

        YearsWorked:
        //Passes through the amount of years worked for and validates it.
            bool isValidYears = Int32.TryParse(Console.ReadLine(), out int workedYears);
            if (workedYears <= 0 || !isValidYears)
            {
                Console.WriteLine("This is not a valid amount of years, please try again.");
                goto YearsWorked;
            }

        AverageSalary:
        //Passes through the final average salary and validates it.
            Console.WriteLine("Please enter your final average salary per year:");
            bool isValidSalary = Double.TryParse(Console.ReadLine(), out double averageSalary);
            if (averageSalary <= 0 || !isValidSalary)
            {
                Console.WriteLine("This is not a valid final salary, please try again.");
                goto AverageSalary;
            }

            //Main calculation and output for the pension salary to be output.
            double pensionSalary = workedYears * 0.02 * averageSalary;

            Console.Clear();
            Console.WriteLine($"By working {workedYears} for an average salary of £{averageSalary} per year, at an average of a 2% multiplier, your final salary is £{pensionSalary} per year after retiring.");
            Console.WriteLine();

        SelectionRetry:
            Console.WriteLine("Would you like to quit Pension Calculator or retry?");
            Console.WriteLine("0: Quit Pension Calculator");
            Console.WriteLine("1: Retry Pension Calculation");

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
                    goto PensionStart;
                default:
                    Console.Clear();
                    Console.WriteLine("This is not a valid selection, please try again.");
                    goto SelectionRetry;
            }
        }

    }
}
