using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_TinyDB.Functions
{
    public class InputValidationHelper
    {
        /// <summary>
        /// This filter limits input to two letters: eiter 'y', or 'n'
        /// Also filters out capitalisation
        /// </summary>
        /// <returns></returns>
        public static string CharInputValidation()
        {
            string input = Console.ReadLine();
            bool success = input.ToLower() == "y" || "n" == input.ToLower();
            while (!success)
            {
                Console.WriteLine("(!) Netinkama įvestis");
                Console.Write(" -> Y/N:");
                input = Console.ReadLine();
                success = input.ToLower() == "y" || "n" == input.ToLower();
            }
            Console.Clear();
            return input;
        }

        /// <summary>
        /// This filter is limited by user (hardcoded)
        /// </summary>
        /// <param name="validatorSize"></param>
        /// <returns></returns>
        public static int IntInputValidation(int validatorSize)
        {
            string input = Console.ReadLine();
            int inputValue;
            bool success = int.TryParse(input, out inputValue) && inputValue >= 0 && inputValue <= validatorSize;
            while (!success)
            {
                Console.WriteLine("(!) Netinkama įvestis");
                Console.Write(" -> Bandykite dar kartą:");
                input = Console.ReadLine();
                success = int.TryParse(input, out inputValue) && inputValue >= 0 && inputValue <= validatorSize;
            }
            Console.Clear();
            return inputValue-1;
        }
    }
}
