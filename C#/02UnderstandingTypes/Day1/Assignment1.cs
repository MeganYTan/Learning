using System;

namespace _02UnderstandingTypes
{
    class Types
    {
        public static void PrintTypes()
        {
            
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "Type", "Size (bytes)", "Min Value", "Max Value");
            Console.WriteLine(new string('-', 90));  
            // sbyte
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            // byte
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            // short
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "short", sizeof(short), short.MinValue, short.MaxValue);
            // ushort
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            // int
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "int", sizeof(int), int.MinValue, int.MaxValue);
            // uint
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            // long
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "long", sizeof(long), long.MinValue, long.MaxValue);
            // ulong
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            // float
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "float", sizeof(float), float.MinValue, float.MaxValue);
            // double
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "double", sizeof(double), double.MinValue, double.MaxValue);
            // decimal
            Console.WriteLine("{0, -10} {1, 15} {2, 30} {3, 30}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
            
        }
    }

    class CenturyConverter
    {
        private static void ConvertCenturies(uint centuries)
        {
            // years = * 100
            uint years = centuries * 100;
            // days
            ulong days = (ulong)(years * 365.24); // taking leap years into account
            // hours
            ulong hours = days * 24;
            // minutes
            ulong minutes = hours * 60;
            // seconds
            ulong seconds = minutes * 60;
            // milliseconds
            ulong milliseconds = seconds * 1000;
            // microseconds
            ulong microseconds = milliseconds * 1000;
            // nanoseconds
            decimal nanoseconds = microseconds * 1000;
            Console.WriteLine($"Output: {centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds ");
        }

        public static void GetNumberOfCenturiesAndConvert()
        {
            Console.Write("Input: ");
            uint numberOfCenturies = uint.Parse(Console.ReadLine());
            ConvertCenturies(numberOfCenturies);
        }
    }

    class FizzBuzz
    {
        public static void ExecuteFizzBuzz()
        {
            for (byte i = 0; i < 100; i++)
            {
                bool isFizzBuzz = false;
                if (i % 3 == 0)
                {
                    Console.Write("Fizz");
                    isFizzBuzz = true;
                }

                if (i % 5 == 0)
                {
                    Console.Write("Buzz");
                    isFizzBuzz = true;
                }

                if (!isFizzBuzz)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
                
            }
        }

        public static void CountTo500WithByte()
        {
            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                Console.WriteLine(i);
                
                if (i == 255)
                {
                    Console.WriteLine("Warning: 'i' will overflow after this point!");
                }
            }
        }
    }

    class RandomNumber
    {
        public static void PlayGuessingGame()
        {
            int guessedNumber = 0;
            while (guessedNumber < 1 || guessedNumber > 3)
            {
                Console.Write("Enter a number between 1 and 3: ");
                guessedNumber = int.Parse(Console.ReadLine());
            }
            int correctNumber = new Random().Next(3) + 1;
            if (correctNumber > guessedNumber)
            {
                Console.WriteLine("You guessed too low.");
            }
            else if (correctNumber < guessedNumber)
            {
                Console.WriteLine("You guessed too high.");
            }
            else
            {
                Console.WriteLine("You guessed right!");
            }
        }

    }

    class Pyramid
    {
        public static void PrintPyramid(int lines = 5)
        {
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < lines-1-i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = 0; k < i; k++)
                {
                    Console.Write("**");
                }
                Console.WriteLine();
            }
        }
    }

    class BirthDaysOld
    {
        public static void CalculateBirthDaysOld(DateTime birthDate = default)
        {
            if (birthDate == default)
            {
                birthDate = new DateTime(1990, 1, 1);
            }
            
            DateTime currentDate = DateTime.Now;
            
            TimeSpan ageInDays = currentDate - birthDate;
            int totalDaysOld = (int)ageInDays.TotalDays;
            
            Console.WriteLine($"You are {totalDaysOld} days old.");
            
            int daysToNextAnniversary = 10000 - (totalDaysOld % 10000);
            DateTime nextAnniversaryDate = currentDate.AddDays(daysToNextAnniversary);
            
            Console.WriteLine($"Your next 10,000-day anniversary will be in {daysToNextAnniversary} days, on {nextAnniversaryDate.ToShortDateString()}.");
        }
    }

    class Greeting
    {
        public static void GreetUser(DateTime time = default)
        {
            if (time == default)
            {
                time = DateTime.Now;
            }
            int hour = time.Hour;
            
            if (hour >= 5 && hour < 12)
            {
                Console.WriteLine("Good Morning");
            }
            if (hour >= 12 && hour < 17)
            {
                Console.WriteLine("Good Afternoon");
            }
            if (hour >= 17 && hour < 21)
            {
                Console.WriteLine("Good Evening");
            }
            if (hour >= 21 || hour < 5)
            {
                Console.WriteLine("Good Night");
            }
        }
    }

    class Counting
    {
        public static void CountTo24()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 24; j=j+i)
                {
                    Console.Write(j);
                    if (j < 24)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
    class Assignment1
    {
        public static void Main(string[] args)
        {
            
            // Practice number sizes and ranges
            // Q1 print types
            Console.WriteLine("Print Types");
            Types.PrintTypes();
            // Q2 Convert centuries
            Console.WriteLine("Convert Centuries");
            CenturyConverter.GetNumberOfCenturiesAndConvert();
            
            // Controlling Flow and Converting Types
            // Q1 Fizz Buzz
            Console.WriteLine("Fizz Buzz");
            FizzBuzz.ExecuteFizzBuzz();
            // Q2 Print-a-Pyramid
            Console.WriteLine("Print-a-Pyramid");
            Pyramid.PrintPyramid();
            // Q3 Guesssing game
            Console.WriteLine("Guessing Game");
            RandomNumber.PlayGuessingGame();
            // Q4 Calculate how many days old a person is
            Console.WriteLine("Calculate Birth Days Old");
            BirthDaysOld.CalculateBirthDaysOld(new DateTime(1997,5,16));
            // Q5 Greet User
            Console.WriteLine("Greet user based on time");
            Greeting.GreetUser();
            // Q6 Counting to 24 in increments
            Console.WriteLine("Count to 24 in increments");
            Counting.CountTo24();
            
            
            // Assignment 2 PracticeArray
            Console.WriteLine("Assignment 2 - PracticeArray");
            // Q1 - Copy Array
            Console.WriteLine("Copy Array");
            PracticeArrays.CopyArray();
            // Q2 - List Manager
            Console.WriteLine("List Manager");
            PracticeArrays.ListManager();
            // Q3 - Print Prime Numbers
            Console.WriteLine("Find primes in range");
            PracticeArrays.PrintArray(PracticeArrays.FindPrimesInRange(5,60));
            // Q4 - Rotate Array and Sum
            Console.WriteLine("Rotate array and sum");
            PracticeArrays.RotateArray();
            // Q5 - Longest Sequence of Equal Elements
            Console.WriteLine("Get longest sequence of equal elements");
            PracticeArrays.LongestSequenceOfEqualElements([0,1,1,5,2,2,6,3,3]);
            // Q7 Most Frequest Number
            Console.WriteLine("Get most frequent number");
            PracticeArrays.MostFrequentNumber([7,7,7,0,2,2,2,0,10,10,10]);
            
            // PracticeStrings
            // Q1 - Reverse Strings
            Console.WriteLine("PracticeStrings");
            Console.WriteLine("Reverse Strings");
            PracticeStrings.ReverseString("sample");
            // Q2 - Reverse Words In Sentence
            Console.WriteLine("Reverse Words in Sentence");
            PracticeStrings.ReverseWordsInSentence("The quick brown fox jumps over the lazy dog /Yes! Really!!!/.");
            // Q3 - Get palindroms
            Console.WriteLine("Get palindroms in sentence");
            PracticeStrings.GetPalindromes("Hi, exe? ABBA! Hog fully a string: ExE. Bob");
            // Q4 - Splitting URL
            Console.WriteLine("Split url into protocol, server, and resource");
            PracticeStrings.URLParser("https://google.com");
        }
    }
}
