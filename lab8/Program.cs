using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Lab_2_2_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string fileName = "input.txt";
            string pattern = @"^<[+-][0-5P-Z]+>$";

            string[] testWords = {
                "<+123P>",      // Вірно
                "<-Z50P>",      // Вірно
                "<+5>",         // Вірно
                "<+6Z>",        // Невірно (6 поза діапазоном)
                "<-ABC>",       // Невірно (ABC поза діапазоном P-Z)
                "<+PZ",         // Невірно (немає >)
                "+PZ>",         // Невірно (немає <)
                "<*PZ>",        // Невірно (немає + або -)
                "<+P5Z>"        // Вірно
            };

            File.WriteAllLines(fileName, testWords);
            Console.WriteLine($"Файл '{fileName}' створено з {testWords.Length} словами.");
            Console.WriteLine($"Регулярний вираз: {pattern}");
            Console.WriteLine(new string('-', 40));

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                List<string> matchedWords = new List<string>();

                foreach (string word in lines)
                {
                    if (Regex.IsMatch(word.Trim(), pattern))
                    {
                        matchedWords.Add(word.Trim());
                    }
                }

                Console.WriteLine("Знайдені слова, що відповідають синтаксису:");
                if (matchedWords.Count > 0)
                {
                    foreach (var match in matchedWords)
                    {
                        Console.WriteLine($"[OK] : {match}");
                    }
                }
                else
                {
                    Console.WriteLine("Збігів не знайдено.");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Файл не знайдено.");
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}