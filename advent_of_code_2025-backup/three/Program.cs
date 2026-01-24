class Three
{
    public static class Globals
    {
        public static int totalJoltage;
        public static long maxJoltage;
    }

    public static void Main()
    {
        Console.WriteLine("Hello World");
        string[] input = File.ReadAllLines("./input");
        PartOne(input);
        PartTwo(input);
        Console.WriteLine($"Part One, total Joltage = {Globals.totalJoltage}");
        Console.WriteLine($"Part Two, max Joltage = {Globals.maxJoltage}");
    }

    public static void PartOne(string[] input)
    {
        foreach (string line in input)
        {
            string num = line[..1];
            for (int i = 0; i < line.Length - 1; i++)
            {
                for (int j = i + 1; j < line.Length; j++)
                {
                    if (int.Parse($"{line[i]}{line[j]}") > int.Parse(num))
                    {
                        num = $"{line[i]}{line[j]}";
                    }
                }
            }
            Globals.totalJoltage += int.Parse(num);
        }
    }

    public static void PartTwo(string[] input)
    {
        for (int line = 0; line < input.Length; line ++)
        {
            string num = "";
            while (num.Length != 12)
            {
                for (int i = 9; i > 0; i--)
                {
                    int index = input[line].IndexOf(i.ToString());
                    if (index != -1 && index <= (input[line].Length - (12 - num.Length)))
                    {
                        num = $"{num}{input[line][index]}";
                        input[line] = input[line][(index+1)..];
                        break;
                    }
                }
            }
            Globals.maxJoltage += long.Parse(num);
        }
    }
}
