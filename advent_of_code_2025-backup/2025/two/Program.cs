class Two
{
    private static class Globals
    {
        public static Int64 invalidCountOne;
        public static Int64 invalidCountTwo;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Day Two");
        DayTwo();
    }

    static void DayTwo()
    {
        // Singleline input
        string input = File.ReadLines("./input").First();
        string[] splitInput = input.Split(",");
        // For each int in the range given, inclusive
        foreach (string range in splitInput)
        {
            for (Int64 i = Int64.Parse(range.Split("-")[0]); i <= Int64.Parse(range.Split("-")[1]); i++)
            {
                Globals.invalidCountOne += IsValidOne(i);
                Globals.invalidCountTwo += IsValidTwo(i);
            }
        }
        Console.WriteLine($"Total aggregate value of invalid ids: {Globals.invalidCountOne}");
        Console.WriteLine($"Total aggregate value of invalid ids: {Globals.invalidCountTwo}");
    }

    static long IsValidOne(long num)
    {
        return num.ToString().Length % 2 == 0 && num.ToString()[..(num.ToString().Length / 2)] == num.ToString()[(num.ToString().Length / 2)..] ? num : 0;
    }

    static long IsValidTwo(long num)
    {
        int numLen = num.ToString().Length;
        int mid = numLen / 2;

        for (long i = 1; i <= mid; i++)
        {
            if (numLen % i == 0)
            {
                string subString = num.ToString()[..(int)i];
                int divisible = numLen / (int)i;
                string newString = "";
                for (int j = 0; j < divisible; j++)
                {
                    newString += subString;
                }
                if (newString == num.ToString())
                {
                    return num;
                }
            }
        }
        return 0;
    }

}
