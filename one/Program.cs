
class One
{
    private static class Globals
    {
        public static int Stops;
        public static int Passes;
    }
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        PartOne();
    }

    static void PartOne()
    {
        // Multiline input
        string[] input = File.ReadAllLines("./input");
        int dial = 50;
        const int dialMax = 99;
        const int dialMin = 0;

        foreach (string line in input)
        {
            char direction = line[0];
            int steps = Int32.Parse(line[1..]);
            dial = RotateDial(dial, direction, steps, dialMax, dialMin);
        }
        Console.WriteLine($"Part One: The final dial position is {dial}");
        Console.WriteLine($"Part One: The dial stopped on 0 {Globals.Stops} times");
        Console.WriteLine($"Part Two: The dial passed 0 {Globals.Passes} times");
    }

    /*
        Rotates the dial in the specified direction by the specified number of steps.
        Returns an int representing the new position of the dial.
    */
    static int RotateDial(int dial, char direction, int steps, int dialMax, int dialMin)
    {
        if (direction == 'L')
        {
            for (int i = 0; i < steps; i++)
            {
                dial--;
                dial = dial < dialMin ? dialMax : dial;
                Globals.Passes = dial == 0 ? ++Globals.Passes : Globals.Passes;
            }
        }
        else if (direction == 'R')
        {
            for (int i = 0; i < steps; i++)
            {
                dial++;
                dial = dial > dialMax ? dialMin : dial;
                Globals.Passes = dial == 0 ? ++Globals.Passes : Globals.Passes;
            }
        }
        Globals.Stops = dial == 0 ? ++Globals.Stops : Globals.Stops;
        return dial;
    }
}
