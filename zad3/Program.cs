using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (IsArgsCorrect(args) == false)
                return;

            bool gameLoop = true;

            while (gameLoop)
            {
                string key = Safety.GetRandomKey();

                int computerChoice = GetComputerChoice(args);

                string hmac = Safety.GetHMAC(key, args[computerChoice - 1]);
                Console.WriteLine("HMAC: " + hmac);

                Console.WriteLine("Available moves:");
                for (int i = 0; i < args.Length; i++)
                    Console.WriteLine($"{i + 1} - {args[i]}");
                Console.WriteLine("0 - exit");
                Console.WriteLine("? - help");

                Console.Write("Enter your move: ");
                string selectedMenuItem = Console.ReadLine();

                if (int.TryParse(selectedMenuItem, out int userChoice))
                {
                    if (userChoice == 0)
                        gameLoop = false;
                    else if (userChoice >= 1 && userChoice <= args.Length)
                    {
                        Console.WriteLine("Your move: " + args[userChoice - 1]);
                        Console.WriteLine("Computer move: " + args[computerChoice - 1]);

                        int gameResult = Result.Calculate(userChoice, computerChoice, args.Length);

                        if (gameResult == 0)
                            Console.WriteLine($"{Result.ConvertToString(gameResult)}!");
                        else
                            Console.WriteLine($"You {Result.ConvertToString(gameResult)}!");

                        Console.WriteLine("HMAC key: " + key);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, please try again!\n");
                        continue;
                    }
                }
                else if (selectedMenuItem == "?")
                {
                    Rules.GenerateTable(args);
                }
                else
                {
                    Console.WriteLine("Incorrect input, please try again!\n");
                    continue;
                }

                Console.WriteLine();
            }
        }

        static int GetComputerChoice (string[] args)
        {
            Random randomChoice = new Random();
            return randomChoice.Next(1, args.Length + 1);
        }

        static bool IsArgsCorrect(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("The number of moves must be odd and more than 3. Please, try again");
                return false;
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("The names of the moves should not be repeated. Please, try again");
                return false;
            }

            return true;
        }
    }
}
