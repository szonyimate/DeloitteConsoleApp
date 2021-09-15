using System;
using System.Collections.Generic;

namespace DeloitteConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // List for storing the input
            List<String> listOfValues = new List<string>();
            // The current input line
            string s;

            // List for the numbers
            List<String> numbers = new List<string>();
            // List for the texts
            List<String> texts = new List<string>();
            // List for the dates
            List<String> dates = new List<string>();

            while (listOfValues.Count < 7)
            {
                // Clear the console and wait for the remaining inputs
                Console.Clear();
                Console.WriteLine("Enter {0} more values:", (7-listOfValues.Count));
                // Asks the user of the next value type
                Console.WriteLine("What is the next type? (Number - 1 / String - 2 / Datetime - 3)");
                s = Console.ReadLine();
                int i = Int32.Parse(s);
                // Value of current number, required for operations
                int numValue;
                bool isPrime = false;
                // Value of current text input
                string inputText;
                // String for current date input
                string inputDate;


                // Calls the methods based on the given valuetype and ands the valid input to the listOfValues list
                switch (i)
                {
                    case 1:
                        numValue = checkNumberValue();
                        listOfValues.Add(numValue.ToString());
                        
                        if (isPrime = checkIfNumberIsPrime(numValue))
                        {
                            numbers.Add(numValue + " - " + numberOperations(numValue).ToString() + " !prime");
                        }
                        else numbers.Add(numValue + " - " + numberOperations(numValue).ToString());
                        break;

                    case 2:
                        inputText = checkStringLength();
                        listOfValues.Add(inputText);
                        texts.Add(concatString(inputText));
                        break;
                    case 3:
                        inputDate = checkDateValue();
                        listOfValues.Add(inputDate);
                        
                        if (DateTime.IsLeapYear(DateTime.ParseExact(inputDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Year))
                        {
                            dates.Add(inputDate + " - " + dateDifference(inputDate).ToString() + " !leap year");
                        } else dates.Add(inputDate + " - " + dateDifference(inputDate).ToString());
                        break;
                    default:
                        Console.WriteLine("Not a valid option!");
                        break;
                }
            }

            // Output
            Console.Clear();
            Console.WriteLine("Numbers {0}", numbers.Count);
            foreach (string num in numbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nTexts {0}", texts.Count);
            foreach (string text in texts)
            {
                Console.WriteLine(text);
            }

            Console.WriteLine("\nDates {0}", dates.Count);
            foreach (string date in dates)
            {
                Console.WriteLine(date);
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        // This method is called when the user tries to input a number
        static int checkNumberValue() 
        {
            int num = 0;
            bool repeat = true;

            Console.Clear();
            Console.WriteLine("Number:");

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

        // This method is called when the user tries to input a string
        static string checkStringLength() 
        {
            string inputString;
            int lengthOfString;
            bool repeat = true;

            Console.Clear();
            Console.WriteLine("Text:");

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

        // This method is called when the user tries to input a date
        static string checkDateValue()
        {
            string inputString;
            // Stores the string as a DateTime
            DateTime inputDate;
            DateTime minimumValue = new DateTime(2000, 1, 1);
            bool repeat = true;

            Console.Clear();
            Console.WriteLine("Date:");

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

        static int numberOperations(int num)
        {
            // If the remainder is 0 then the number is divided by 2, otherwise its multiplied by 2
            if (num % 2 == 0)
            {
                num /= 2;
            }
            else num *= 2;

            return num;
        }

        static bool checkIfNumberIsPrime(int num)
        {
            // 2 is the lowest prime number so return a false value if the num is lower
            if (num <= 1) return false;
            if (num == 2) return true;
            // Even numbers are not primes
            if (num % 2 == 0) return false;

            // the square root of num is stored for the loop
            var boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        static string concatString(string text)
        {
            string deloitteText = "Making an impact that matters - Deloitte";

            text = text + " - " + deloitteText.Substring(0, text.Length);
            return text;
        }

        static int dateDifference(string date)
        {
            DateTime givenDate = new DateTime(2002, 2, 20);
            DateTime inputDate = DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

            return (int)(givenDate - inputDate).Days;
        }

    }

}
