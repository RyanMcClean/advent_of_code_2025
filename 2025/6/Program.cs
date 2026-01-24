using System.Text.RegularExpressions;

partial class Six
{
    public class Globals
    {
        public static long grandTotal = 0;
    }

    public static void Main()
    {
        string[] input = File.ReadAllLines("./input");
        PartOne(input);
        Console.WriteLine($"Homework grand total = {Globals.grandTotal}");
    }

    public static void PartOne(string[] input)
    {
        int width = 0;
        foreach (var item in MyRegex().Replace(input[0].Trim(), ";").Split(";"))
        {
            width += (item.Length > 0) ? 1 : 0;
        }
        for (int i = 0; i < width; i++)
        {
            List<long> numbers = [];
            long total = 0;
            foreach (string line in input)
            {
                string trimmedLine = line.Trim();
                string number = MyRegex().Replace(trimmedLine, ";").Split(";")[i];
                if (number != "+" && number != "*")
                {
                    numbers.Add(int.Parse(number));
                }
                else if (number == "+")
                {
                    foreach (long num in numbers)
                    {
                        total += num;
                    }
                }
                else if (number == "*")
                {
                    total = 1;
                    foreach (long num in numbers)
                    {
                        total *= num;
                    }
                }
            }
            Globals.grandTotal += total;
        }
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex MyRegex();
}