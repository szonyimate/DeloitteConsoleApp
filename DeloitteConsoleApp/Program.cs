using System;
using System.Collections.Generic;

namespace DeloitteConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // The current input line
            string inputLine;

            // List containing the numbers
            List<String> numbers = new List<string>();
            // List containing the texts
            List<String> texts = new List<string>();
            // List containing the dates
            List<String> dates = new List<string>();

            // 7 valid input required
            while ((numbers.Count + texts.Count + dates.Count) < 7)
            {
                // Clear the console and wait for the remaining inputs
                Console.Clear();
                Console.WriteLine("{0} input required:", 7 - (numbers.Count + texts.Count + dates.Count));
                // Choose the next input type
                Console.WriteLine("What is the next type? (Number - 1 / String - 2 / Datetime - 3)");
                inputLine = Console.ReadLine();
                int inputType = Int32.Parse(inputLine);

                // Value of current number, required for operations
                int numValue;
                bool isPrime = false;
                // Value of current text input
                string inputText;
                // String for current date input
                string inputDate;


                // Calls the methods based on the given valuetype and adds the valid input to the listOfValues list and the list of its type
                switch (inputType)
                {
                    // Number input
                    case 1:
                        // The return of ValidateNumber() method is the input string converted to int.
                        numValue = ValidateNumber();
                        
                        // Adds a string to the numbers list
                        if (isPrime = NumberIsPrime(numValue))
                        {
                            numbers.Add(numValue + " - " + NumberOperations(numValue) + " !prime");
                        }
                        else numbers.Add(numValue + " - " + NumberOperations(numValue));
                        break;
                    
                    // Text input
                    case 2:
                        inputText = ValidateText();
                        // The input is valid, so it can be added to the list
                        texts.Add(ConcatString(inputText));
                        break;

                    // Date input
                    case 3:
                        inputDate = ValidateDateTime();
                        
                        // Checking if its a leap year
                        if (DateTime.IsLeapYear(DateTime.ParseExact(inputDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year))
                        {
                            dates.Add(inputDate + " - " + DaysBetweenDates(inputDate).ToString() + " !leap year");
                        } else dates.Add(inputDate + " - " + DaysBetweenDates(inputDate).ToString());
                        break;

                    // Anything other then the listed options
                    default:
                        Console.WriteLine("Not a valid option!");
                        break;
                }
            }

            /*
             * OUTPUT
             */

            Console.Clear();
            Console.WriteLine("Numbers ({0}):", numbers.Count);
            foreach (string num in numbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nTexts ({0}):", texts.Count);
            foreach (string text in texts)
            {
                Console.WriteLine(text);
            }

            Console.WriteLine("\nDates ({0}):", dates.Count);
            foreach (string date in dates)
            {
                Console.WriteLine(date);
            }
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        // Called when the user tries to input a number
        static int ValidateNumber() 
        {
            int num = 0;
            bool repeat = true;

            Console.WriteLine("\nNumber:");

            // This runs until the input number is valid
            do
            {
                num = Int32.Parse(Console.ReadLine());

                if (num > 10 && num < 9999)
                {
                    repeat = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number! Please try again (10-9999)!");
                }
            } while (repeat);

            // returns the valid number 
            return num;
        }

        // Called when the user tries to input a string
        static string ValidateText() 
        {
            string inputString;
            bool repeat = true;

            Console.WriteLine("\nText:");

            // This runs until a valid text input is given
            do
            {
                inputString = Console.ReadLine();

                if (inputString.Length > 5 && inputString.Length < 45)
                {
                    repeat = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please try again! (Character limit: 5 - 45)");
                }

            } while (repeat);

            return inputString;
        }

        // Called when the user tries to input a date
        static string ValidateDateTime()
        {
            string inputString;
            // Stores the string as a DateTime
            DateTime inputDate;
            DateTime minimumValue = new DateTime(2000, 1, 1);
            bool repeat = true;

            Console.WriteLine("\nDate:");

            do
            {
                inputString = Console.ReadLine();

                // Checks the input format
                if (DateTime.TryParseExact(inputString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out inputDate))
                {
                    if (inputDate > minimumValue)
                    {
                        repeat = false;
                    }
                    else Console.WriteLine("Please try again with a date after 2000.01.01!");
                }
                else Console.WriteLine("Wrong format, please try again! (YYYYMMDD)");

            } while (repeat);

            return inputString;
        }

        // Called to check if the number is even
        static string NumberOperations(int num)
        {
            // If the remainder is 0 then the number is even and its divided by 2, otherwise its multiplied by 2
            if (num % 2 == 0)
            {
                num /= 2;
            }
            else num *= 2;

            return num.ToString();
        }

        // Called to check if the number is prime
        static bool NumberIsPrime(int num)
        {
            // 2 is the lowest prime number so return a false value if the num is lower
            if (num <= 1) return false;
            if (num == 2) return true;
            // Even numbers are not primes
            if (num % 2 == 0) return false;

            // the square root of num is stored for the loop (it's enough to check until this boundary)
            var boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        // Called to add the first few characters of our string to the input
        static string ConcatString(string text)
        {
            string deloitteText = "Making an impact that matters - Deloitte";

            text = text + " - " + deloitteText.Substring(0, text.Length);
            return text;
        }

        // Called to check the difference in days between the 2 dates
        static int DaysBetweenDates(string date)
        {
            DateTime givenDate = new DateTime(2002, 2, 20);
            DateTime inputDate = DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

            return (int)(givenDate - inputDate).Days;
        }

    }

}
