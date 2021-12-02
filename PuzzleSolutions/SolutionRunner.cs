using ChallengeSolutions.Helpers;
using PuzzleSolutions.Y2021;
using System;

namespace PuzzleSolutions
{
    public class SolutionRunner
    {
        public static void Main(string[] args)
        {
            MyIO.CreateEmptyDataFiles(2021);
            var part1 = Y2021_D1.SolvePart1();
            var part2 = Y2021_D1.SolvePart2();
            Console.WriteLine($"Part 1 Answer: {part1}");
            Console.WriteLine($"Part 2 Answer: {part2}");
        }
    }
}
