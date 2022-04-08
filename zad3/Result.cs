using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Result
    {
        public static int Calculate(int userChoice, int computerChoice, int numOfOptions)
        {
            int numberOfWinningElems = (numOfOptions - 1) / 2;
            bool isOverflowing = userChoice + numberOfWinningElems > numOfOptions;

            if (computerChoice == userChoice)
            {
                return 0;
            }
            else if (isOverflowing == true)
            {
                if (computerChoice > userChoice || computerChoice <= (userChoice + numberOfWinningElems) % numOfOptions)
                    return 1;
            }
            else if (isOverflowing == false)
            {
                if (computerChoice > userChoice && computerChoice <= userChoice + numberOfWinningElems)
                    return 1;
            }
            return -1;
        }

        public static string ConvertToString(int result)
        {
            if (result == 0)
                return "Draw";
            else if (result == 1)
                return "Win";
            else
                return "Lose";
        }
    }
}
