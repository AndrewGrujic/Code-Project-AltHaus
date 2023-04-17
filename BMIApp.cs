using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Code_Project_AltHaus
{
    internal class BMIApp
    {
        
        enum BMIClass
        {
            Underweight,
            Healthy,
            Overweight,
            Obese
        };

        public static void BMI()
        {
            Console.WriteLine("Welcome to the BMI Calculator.");
        BMIStart:
            Console.WriteLine("Please enter your weight in KG:");

        UserWeight:

            bool weightCheck;
            weightCheck = Double.TryParse(Console.ReadLine(), out double userWeight);
            if (userWeight <= 0 || !weightCheck)
            {
                Console.WriteLine("This is not a valid weight, please try again.");
                goto UserWeight;
            }

            Console.WriteLine("Please enter your height in meters:");

        UserHeight:
            bool heightCheck;
            heightCheck = Double.TryParse(Console.ReadLine(), out double userHeight);
            if (userHeight <= 0 || !heightCheck )
            {
                Console.WriteLine("This is not a valid height, please try again.");
                goto UserHeight;
            }

            double squaredHeight = userHeight * userHeight;
            double outBMI = Math.Round(userWeight / squaredHeight, 2);

            Console.Clear();


            switch (outBMI)
            {
                case double range when range < 18.5:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Underweight}.");
                    Console.WriteLine();
                    break;

                case double range when range >= 18.5 && range < 25:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Healthy}");
                    Console.WriteLine();
                    break;

                case double range when range >= 25 && range < 30:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Overweight}");
                    Console.WriteLine();
                    break;

                case double range when range > 30:
                    Console.WriteLine($"Your BMI is {outBMI} which means your class is {BMIClass.Obese}");
                    Console.WriteLine();
                    break;
            }

            SelectionRetry:
            Console.WriteLine("Would you like to quit BMI Calculator or retry?");
            Console.WriteLine("0: Quit BMI Calculator");
            Console.WriteLine("1: Retry BMI Calculation");

            Int32.TryParse(Console.ReadLine(), out int selection);

            switch (selection)
            {
                case 0:
                    Console.Clear();
                    return;
                case 1:
                    Console.Clear();
                    goto BMIStart;
                default:
                    Console.Clear();
                    Console.WriteLine("This is not a valid selection, please try again.");
                    goto SelectionRetry;
            }
        }
    }
}
