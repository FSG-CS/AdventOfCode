using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChallengeSolutions.Helpers
{
    public class MyIO
    {
        private static string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\PuzzleSolutions");

        public static void CreateEmptyDataFiles(int year)
        {
            for (int day = 1; day < 26; day++)
            {
                for (int part = 1; part < 3; part++)
                {
                    var dataFilePath = GetDataFilePath(year, day, part, false);
                    var testFilePath = GetDataFilePath(year, day, part, true);
                    CreateEmptyDataFile(dataFilePath);
                    CreateEmptyDataFile(testFilePath);
                }
            }
        }



        public static List<string> ReadStringsFromFile(int year, int day = 1, int part = 1, bool isTestFile = false)
        {
            var dataFilePath = GetDataFilePath(year, day, part, isTestFile);
            List<string> lines = System.IO.File.ReadAllLines(dataFilePath).ToList();
            return lines;
        }

        public static List<int> ReadIntsFromFile(int year, int day = 1, int part = 1, bool isTestFile = false)
        {
            var lines = ReadStringsFromFile(year, day, part, isTestFile);
            var intList = TryParseStringListToInt(lines, out var success);
            return intList;
        }

        private static void CreateEmptyDataFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path);
        }

        private static List<int> TryParseStringListToInt(List<string> list, out bool success)
        {
            success = true;
            var intList = new List<int>();
            foreach (string item in list)
            {
                if (Int32.TryParse(item, out var result))
                    intList.Add(result);
                else
                {
                    success = false;
                    return new List<int>() { 999 };
                }
            }
            return intList;
        }



        private static string GetDataFilePath(int year, int day, int part, bool isTestFile)
        {
            var directory = isTestFile ? "TestInputs" : "PuzzleInputs";
            var filename = isTestFile ? $"Test Y{year} D{day} P{part}.txt" : $"Y{year} D{day} P{part}.txt";
            return Path.Combine(_filePath, $"Y{year}", directory, filename);
        }
    }
}