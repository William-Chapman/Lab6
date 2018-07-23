using System;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Dice Roller");
            Console.WriteLine("The format this program expects is (number of dice) d(number of sides on dice)");
            Console.WriteLine("eg. (2d20) will roll 2 die with 20 sides");
            do
            {
                Console.WriteLine("Please enter what you would like to roll.");
                string userInput = Console.ReadLine();
                if(ValidateDiceFormat(userInput))
                {
                    int sides = TakeSides(userInput);
                    int rolls = TakeRolls(userInput);
                    Console.WriteLine("Press Enter to roll the dice");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        int total = 0;
                        for (int i = 0; i < rolls; i++)
                        {
                            int result = RollDice(sides);
                            total = total + result;
                            Console.WriteLine($"Die {i + 1}: {result}");
                        }
                        Console.WriteLine($"Total: {total}");
                    }
                }
            }
            while (Continue() == 1);
        }

        static int TakeRolls(string userInput)
        {
            int rolls = int.Parse(userInput.Substring(0, userInput.IndexOf("d")));
            Console.WriteLine(rolls);
            return rolls;
        }

        static int TakeSides(string userInput)
        {
            int sides = int.Parse(userInput.Substring(userInput.IndexOf("d") + 1));
            Console.WriteLine(sides);
            return sides;
        }

        static int RollDice(int sides)
        {
            Random rng = new Random();
            int result = rng.Next(1, sides + 1);
            return result;
        }

        static bool ValidateDiceFormat (string userInput)
        {
            string pattern = @"^\d{1,}[d]{1}\d{1,}$";
            var match = Regex.Match(userInput, pattern, RegexOptions.IgnoreCase);
            if(match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int Continue()
        {
            string response;
            int situ = 3;
            while (situ == 3)
            {
                Console.WriteLine("Continue? (y/n): ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    //if yes, restart at main
                    situ = 1;
                }
                else if (response == "n" || response == "no")
                {
                    //if no, exit
                    situ = 0;
                }
                else if (response != "n" || response != "no" || response != "y" || response != "yes")
                {
                    situ = 3;
                }

                if (situ == 3)
                {
                    Console.WriteLine("Please enter valid response.");
                }
            }
            return situ;
        }
    }
}
