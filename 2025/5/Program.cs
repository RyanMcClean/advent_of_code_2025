class Five
{
    public class Globals
    {
        public static int numFresh = 0;
        public static long totalIds = 0;
    }

    public static void Main()
    {
        string[] input = File.ReadAllLines("./input");
        PartOne(input);
        Console.WriteLine($"Fresh fruit count: {Globals.numFresh}");
        PartTwo(input);
        Console.WriteLine($"Total number of Ids: {Globals.totalIds}");
    }

    public static void PartOne(string[] input)
    {
        // Range of fresh ingedients
        string range = "";
        // available fruits
        string available = "";
        // flag to check if after the break in the input
        bool after = false;
        foreach (string line in input)
        {
            if (line == "")
            {
                after = true;
            }
            else if (after)
            {
                available = available.Length > 0 ? $"{available},{line}" : $"{line}";
            }
            else if (!after)
            {
                range = range.Length > 0 ? $"{range},{line}" : $"{line}";
            }
        }
        foreach (string fruit in available.Split(","))
        {
            // If the fruit is within a range, then count
            if (fruit != "" && range.Split(",").Any(x => long.Parse(x.Split("-")[0]) <= long.Parse(fruit) && long.Parse(fruit) <= long.Parse(x.Split("-")[1])))
            {
                Globals.numFresh++;
            }
        }
    }

    public static void PartTwo(string[] input)
    {
        // Only the first section of the input is necessary, when reading the input, break on a newline

        // The above crashed the vscodium server
        // Need to collect the ranges, then compare them
        // If any exist within the already existing ranges, then the range it exists within needs to be modified accordingly
        List<long[]> ranges = [];
        foreach (string line in input)
        {
            bool overlap = false;
            if (line == "")
            {
                break;
            }
            else
            {
                var rangeSplit = line.Split("-");
                long start = long.Parse(rangeSplit[0]);
                long end = long.Parse(rangeSplit[1]);
                if (ranges.Count != 0)
                {
                    // check if the start and end exist within the already existing ranges
                    for (int i = 0; i < ranges.Count; i++)
                    {
                        // is the start less than or equal to the end of the current range?
                        // is is the end greater than or equal to the start of the current range?
                        // Then there is an overlap
                        if (ranges[i][0] <= end && ranges[i][1] >= start)
                        {
                            overlap = true;
                            if (start < ranges[i][0])
                            {
                                ranges[i][0] = start;
                            }
                            if (end > ranges[i][1])
                            {
                                ranges[i][1] = end;
                            }
                            break;
                        }
                    }
                }
                if (!overlap)
                {
                    ranges.Add([start, end]);
                }
            }
        }

        int numChanged = 1;
        while (numChanged > 0)
        {
            numChanged = 0;
            for (int i = 0; i < ranges.Count; i++)
            {
                // is the start less than the end of the current range?
                // is is the end greater than the start of the current range?
                // Then there is an overlap
                var start = ranges[i][0];
                var end = ranges[i][1];
                for (int j = i + 1; j < ranges.Count; j++)
                {
                    if (ranges[j][0] <= end && ranges[j][1] >= start)
                    {
                        if (start > ranges[j][0])
                        {
                            ranges[i][0] = ranges[j][0];
                        }
                        if (end < ranges[j][1])
                        {
                            ranges[i][1] = ranges[j][1];
                        }
                        ranges.RemoveAt(j);
                        numChanged++;
                        break;
                    }
                }
            }
        }


        foreach (long[] range in ranges)
        {
            if (range != null)
            {
                // Plus 1 to account for inclusive ranges
                Globals.totalIds += (range[1] - range[0]) + 1;
            }
        }
    }
}
