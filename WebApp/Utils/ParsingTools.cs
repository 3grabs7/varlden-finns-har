using System;
using System.Collections.Generic;
using System.IO;

namespace WebApp.Utils
{
    public static class ParsingTools
    {
        public static string ToHMTimestamp(int input)
        {
            if (input % 100 != 0)
            {
                input -= 20;
            }
            string inputAsString = input.ToString();
            return inputAsString.Insert(inputAsString.Length - 2, ":");
        }

        public static DateTime ToHMDateTIme(string timeStamp)
        {
            if (timeStamp.Length < 5)
            {
                timeStamp = $"0{timeStamp}";
            }
            return DateTime.ParseExact(timeStamp, "HH:mm", null);
        }

        public static List<string> ReadExcelFile(string filepath)
        {
            List<string> result = new();

            using var reader = new StreamReader(filepath, System.Text.Encoding.Latin1);
            while (!reader.EndOfStream)
                result.Add(reader.ReadLine());

            return result;
        }
    }
}
