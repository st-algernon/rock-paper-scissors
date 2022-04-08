using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Rules
    {
        public static void GenerateTable(string[] args)
        {
            for (int i = 0; i < args.Length + 1; i++)
            {
                for (int j = 0; j < args.Length + 1; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0)
                            Console.Write("{0, 10}", string.Empty);
                        else
                            Console.Write("{0, 10}", args[i - 1]);
                    }
                    else if (i == 0)
                        Console.Write("{0, 10}", args[j - 1]);
                    else
                        Console.Write("{0, 10}", Result.ConvertToString(Result.Calculate(i, j, args.Length)));
                }

                Console.WriteLine();
            }
        }
    }
}
