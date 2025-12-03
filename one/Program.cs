using System;

class Program
{
    private static class Globals
    {
        public static int stops = 0;
        public static int passes = 0;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PartOne();
    }

    static void PartOne()
    {
        string[] input = System.IO.File.ReadAllLines("./input");
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
        Console.WriteLine($"Part One: The dial stopped on 0 {Globals.stops} times");
        Console.WriteLine($"Part Two: The dial passed 0 {Globals.passes} times");
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
                Globals.passes = dial == 0 ? ++Globals.passes : Globals.passes;
            }
        }
        else if (direction == 'R')
        {
            for (int i = 0; i < steps; i++)
            {
                dial++;
                dial = dial > dialMax ? dialMin : dial;
                Globals.passes = dial == 0 ? ++Globals.passes : Globals.passes;
            }
        }
        Globals.stops = dial == 0 ? ++Globals.stops : Globals.stops;
        return dial;
    }
}
