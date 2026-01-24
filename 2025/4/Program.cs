using System.Text;

class Four
{
    public static class Globals
    {
        public static int accessibleRolls = 0;
        public static int removedRolls = 0;
    }

    public static void Main()
    {
        string[] input = File.ReadAllLines("./input");
        PartOne(input);
        Console.WriteLine($"Accessible Rolls: {Globals.accessibleRolls}");
        Console.WriteLine($"Removed Rolls: {Globals.removedRolls}");
    }
    public static void PartOne(string[] input)
    {
        StringBuilder[] modifiedInput = new StringBuilder[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            modifiedInput[i] = new StringBuilder(input[i]);
        }

        // Find roll
        // check if roll can be accessed
        // accumulate
        int removed = 1;
        while (removed > 0)
        {
            for (int i = 0; i < modifiedInput.Length; i++)
            {
                for (int j = 0; j < modifiedInput[i].Length; j++)
                {
                    if (modifiedInput[i][j] == '@')
                    {
                        // The top and bottom row can only have 5 around them
                        if (i < 1 || i == modifiedInput.Length - 1)
                        {
                            // If top and bottom row, and in the corner, then it can only have 3 around it
                            // So it is always accessible
                            if (j < 1 || j == modifiedInput[i].Length - 1)
                            {
                                Globals.accessibleRolls++;
                                modifiedInput[i][j] = '.';
                                removed++;
                                Globals.removedRolls++;
                            }
                            // If top or bottom row, and not in the corner, then it can have 5 around it
                            // If two are clear, then its accessible 
                            else if (i < 1)
                            {
                                int count = 0;
                                count += modifiedInput[i][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j + 1] == '@' ? 1 : 0;
                                Globals.accessibleRolls += count > 3 ? 0 : 1;
                                if (count < 4)
                                {
                                    modifiedInput[i][j] = '.';
                                    removed++;
                                    Globals.removedRolls++;
                                }
                            }
                            else if (i == modifiedInput.Length - 1)
                            {
                                int count = 0;
                                count += modifiedInput[i][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j + 1] == '@' ? 1 : 0;
                                Globals.accessibleRolls += count > 3 ? 0 : 1;
                                if (count < 4)
                                {
                                    modifiedInput[i][j] = '.';
                                    removed++;
                                    Globals.removedRolls++;
                                }
                            }
                        }
                        else if (i > 0 && i < modifiedInput.Length - 1)
                        {
                            if (j < 1)
                            {
                                int count = 0;
                                count += modifiedInput[i - 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j + 1] == '@' ? 1 : 0;
                                Globals.accessibleRolls += count > 3 ? 0 : 1;
                                if (count < 4)
                                {
                                    modifiedInput[i][j] = '.';
                                    removed++;
                                    Globals.removedRolls++;
                                }
                            }
                            else if (j == modifiedInput[i].Length - 1)
                            {
                                int count = 0;
                                count += modifiedInput[i - 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j - 1] == '@' ? 1 : 0;
                                Globals.accessibleRolls += count > 3 ? 0 : 1;
                                if (count < 4)
                                {
                                    modifiedInput[i][j] = '.';
                                    removed++;
                                    Globals.removedRolls++;
                                }
                            }
                            else if (j > 0 && j < modifiedInput[i].Length - 1)
                            {
                                int count = 0;
                                count += modifiedInput[i + 1][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i + 1][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i][j + 1] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j - 1] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j] == '@' ? 1 : 0;
                                count += modifiedInput[i - 1][j + 1] == '@' ? 1 : 0;
                                Globals.accessibleRolls += count > 3 ? 0 : 1;
                                if (count < 4)
                                {
                                    modifiedInput[i][j] = '.';
                                    removed++;
                                    Globals.removedRolls++;
                                }
                            }
                        }
                    }
                }
            }
            removed--;
        }
    }
}
