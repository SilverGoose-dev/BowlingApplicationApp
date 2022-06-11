using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BowlingAverage
{
    class Program

    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please insert scores and press Enter for Average.\nPress Esc to quit.");

            while (true)
            {
                ConsoleKeyInfo FirstKeyPress = Console.ReadKey();
                if (FirstKeyPress.Key == ConsoleKey.Escape)
                {
                    return;
                }
                string scoreString = FirstKeyPress.KeyChar + Console.ReadLine();
                bool IsValid = int.TryParse(scoreString, out int score);
                if (!IsValid || score < 0 || score > 300)
                {
                    Console.WriteLine("Please insert a valid score");
                    continue;
                }

                List<int> listOfScores = new List<int>();
                string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                using (StreamWriter sw = File.AppendText($"{filePath}\\BowlingAverage.txt"))
                {
                    sw.WriteLine(score);
                }
                List<string> AllBowlingScores = File.ReadAllLines($"{filePath}\\BowlingAverage.txt").ToList();

                foreach (string SingleScore in AllBowlingScores)
                {
                    int SingleScoreInt = int.Parse(SingleScore);
                    listOfScores.Add(SingleScoreInt);
                }
                double BowlingAverage = listOfScores.Average();

                Console.WriteLine("Your Average = " + Math.Round(BowlingAverage));
            }

            //Note for future additions.
            //Show all scores.
            //Menu options.
            //GUI
            //Clear scores
            //Bowling Season averages

        }
    }
}
