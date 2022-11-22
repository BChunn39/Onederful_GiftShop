namespace Onederus_giftshop
{
    public static class InputValidation
    {
        public static long IsLong() // for CC, CCnum too long for int
        {
            bool isLong = false;
            long longUserInput = 0;

            while (isLong == false)
            {
                isLong = long.TryParse(Console.ReadLine(), out longUserInput);
                if (isLong == false)
                {
                    Console.Write("Invalid entry. Please reenter.\n");
                }
                else isLong = true;
            }
            return longUserInput;
        }

        public static int IsInt()
        {
            bool isInt = false;
            int intUserInput = 0;

            while (isInt == false)
            {
                isInt = int.TryParse(Console.ReadLine(), out intUserInput);
                if (isInt == false)
                {
                    Console.WriteLine("Invalid entry. Please reenter.\n");
                }
                else isInt = true;
            }
            return intUserInput;
        }

        public static double IsDouble()
        {
            bool isDouble = false;
            double doubleOut = 0;

            while (isDouble == false)
            {
                isDouble = double.TryParse(Console.ReadLine(), out doubleOut);
                if (isDouble == false)
                {
                    Console.WriteLine("Invalid entry. Please reenter.\n");
                }
                else isDouble = true;
            }
            return doubleOut;
        }

        public static int IsMonth()
        {
            bool isMonth = false;
            int month = 0;

            while (isMonth == false)
            {
                month = InputValidation.IsInt();
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("Please enter a valid month (MM).\n");
                }
                else isMonth = true;
            }
            return month;
        }

        public static int IsYear()
        {
            bool isYear = false;
            int year = 0;

            while (isYear == false)
            {
                year = InputValidation.IsInt();
                if (year >= int.Parse(DateTime.Now.ToString("yy")) && (year <= int.Parse(DateTime.Now.ToString("yy")) + 6))
                {
                    isYear = true;
                    return year;
                }
                else
                {
                    Console.WriteLine("Invalid year entered. Please reenter as 'YY'.\n");
                    isYear = false;
                }
            }
            return year;
        }

        public static string IsString(string stringInput)
        {
            bool isString = false;

            while (isString == false)
            {
                if (String.IsNullOrEmpty(stringInput) || stringInput.Any(c => char.IsDigit(c)))
                {
                    Console.Write($"Input cannot be empty or include digits. Please reenter.\n");
                }
                isString = true;
                stringInput.ToLower();
            }
            return stringInput;
        }

    }

}