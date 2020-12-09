using System;
using static System.Console;

namespace Assigment2
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteLine();
            WriteLine("2.) Polynomial calculation:");
            WriteLine("-------------------------------------");
            int x = (int)GetIntegerFromUser("Please enter an integer value for 'x': ");
            long polynomialValueLong = CalculatePolynomialLong(x);
            WriteLine($"  Long: 4x^3 + 5x - 2 = {polynomialValueLong.ToString("###,###")}");
            double polynomialValueDouble = CalculatePolynomialDouble(x);
            WriteLine($"Double: 4x^3 + 5x - 2 = {polynomialValueDouble.ToString("###,###")}");

            WriteLine();
            WriteLine("3.) Seconds to HH:MM:SS Converter:");
            WriteLine("-------------------------------------");
            int numSeconds = (int)GetIntegerFromUser("Please enter the number of seconds to convert: ");
            if (numSeconds < 0) numSeconds = 0;
            string hoursMinutesSeconds = ToHoursMinsSeconds((uint)numSeconds);

            WriteLine();
            WriteLine("4.) Min and Max of a number sequence:");
            WriteLine("-------------------------------------");
            int min = int.MaxValue;
            int max = int.MinValue;
            bool done = false;
            while (!done)
            {
                int? nextNumber = GetIntegerFromUser("Please enter an integer", "end");
                if (nextNumber == null)
                {
                    done = true;
                    break;
                }
                if (nextNumber < min) min = (int)nextNumber;
                if (nextNumber > max) max = (int)nextNumber;
            }
            if (min != int.MaxValue || max != int.MinValue)
            {
                WriteLine($"The smallest value entered: {min}");
                WriteLine($"The largest value entered: {max}");
            }
            else
            {
                WriteLine("Error: No data entered.  Min and Max are undefined.");
            }

            WriteLine();
            WriteLine("5.) Even integers between 0 and 200:");
            WriteLine("-------------------------------------");
            int j = 0;
            int numNumbers = 1;
            string line = "";
            while (j <= 200)
            {
                line += $"{j:D3}";
                if (j != 200)
                    line += ", ";
                if (numNumbers % 10 == 0)
                    line += "\n";
                j += 2;
                numNumbers++;
            }
            WriteLine(line);

            WriteLine();
            WriteLine("6.) Odd integers between 200 and 0:");
            WriteLine("-------------------------------------");
            int k = 200 - 1;
            numNumbers = 1;
            line = "";
            do
            {
                line += $"{k:D3}";
                if (k != 1)
                    line += ", ";
                if (numNumbers % 25 == 0)
                    line += "\n";
                k -= 2;
                numNumbers++;
            } while (k > 0);
            WriteLine(line);

            WriteLine();
            WriteLine("7.) Letter Grade Converter:");
            WriteLine("-------------------------------------");
            done = false;
            while (!done)
            {
                int? testScore = GetIntegerFromUser("Please enter a numeric score (0-100) for the test", "quit");
                if (testScore == null)
                {
                    done = true;
                    break;
                }

                int score = (int)testScore;
                if (score < 0 || score > 100)
                {
                    WriteLine("Error: That doesn't look like a number between 0 and 100.  Please try again.");
                    continue;
                }
                WriteLine($"A test score of {score} equates to a letter grade of {ConvertScoreToGrade(score)}");
            }
        }

        // ----------------------------------------------------------------------------------

        // Prompt the user and get a valid integer response.
        // Return null if the user types the (optional) quitWord (case-insensitive).
        private static int? GetIntegerFromUser(string prompt, string quitWord = null)
        {
            int? output = null;

            if (quitWord != null)
            {
                prompt += $" (or '{quitWord}' to stop): ";
                quitWord = quitWord.ToLower();
            }

            bool validInput = false;
            while (!validInput)
            {
                Write(prompt);
                string userInput = ReadLine().ToLower();

                if (quitWord != null && userInput.Contains(quitWord))
                    return null;

                try
                {
                    output = int.Parse(userInput);
                }
                catch (FormatException)       // Unfortunately, C# doesn't have (FormatException | OverflowException)
                {
                    WriteLine("Error: That doesn't appear to be a valid integer. Please try again.");
                    continue;
                }
                catch (OverflowException)
                {
                    WriteLine("Error: That number is too big. Please try again.");
                    continue;
                }
                validInput = true;
            }
            return output;
        }

        private static long SumOfIntArray(int[] integers)
        {
            long sum = 0;
            foreach (int i in integers)
            {
                sum += i;
            }
            return sum;
        }

        private static long CalculatePolynomialLong(int x)
        {
            return (4 * (long)Math.Pow(x, 3)) + (5 * x) - 2;
        }

        private static double CalculatePolynomialDouble(int x)
        {
            return (4 * Math.Pow(x, 3)) + (5 * x) - 2;
        }

        private static string ToHoursMinsSeconds(uint numSeconds)
        {
            int hours = (int)(numSeconds / (60 * 60));
            numSeconds -= (uint)(hours * (60 * 60));
            int minutes = (int)(numSeconds / 60);
            int seconds = (int)(numSeconds % 60);
            return $"{hours} hours, {minutes} minutes, {seconds} seconds";
        }

        private static string ConvertScoreToGrade(int score)
        {
            string grade = "unknown";

            if (score < 0 || score > 100)
                return "invalid score";

            switch ((score - 1) / 10)
            {
                case 9:
                    grade = "A";
                    break;

                case 8:
                    grade = "B";
                    break;

                case 7:
                    grade = "C";
                    break;

                case 6:
                    grade = "D";
                    break;

                default:
                    grade = "F";
                    break;
            }
            return grade;
        }

    }
}