Main();

void Main()
{
    uint m = (uint)Math.Pow(2, 31);
    uint a = (uint)Math.Pow(2, 16);
    uint c = 28657;
    uint start = 33;
    uint number = 100;

    string fileName = "output.txt";

    bool success = true;

    while(true)
    {
        success = true;
        Console.WriteLine("Default - d | Custom - c | f- File | Exit - e");
        string? value = Console.ReadLine();

        switch (value)
        {
            case "d":
                Console.WriteLine($"Values: m - {m} | a - {a} | c - {c} | start - {start}");
                Console.WriteLine("Enter number:");

                if (!ReadInt(ref number) || number <= 0)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                }

                break;
            case "c":
                Console.WriteLine("Enter m:");
                if (!ReadInt(ref m) || m <= 0)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                    break;
                }

                Console.WriteLine("Enter a:");
                if (!ReadInt(ref a) || a < 0 || a >= m)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                    break;
                }

                Console.WriteLine("Enter c:");
                if (!ReadInt(ref c) || c < 0 || c >= m)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                    break;
                }

                Console.WriteLine("Enter start:");
                if (!ReadInt(ref start) || start < 0 || start >= m)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                    break;
                }

                Console.WriteLine("Enter number:");
                if (!ReadInt(ref number) || number <= 0)
                {
                    Console.WriteLine("Wrong number.");
                    Console.WriteLine("Try again.");
                    success = false;
                }

                break;
            case "f":
                Console.WriteLine("Enter file path:");
                fileName = Console.ReadLine();
                if (String.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("Wrong file path.");
                    Console.WriteLine("Try again.");
                    fileName = "output.txt";
                }

                success = false;
                break;
            case "e":
                return;
            default:
                Console.WriteLine("Wrong parameter.");
                Console.WriteLine("Try again.");
                success = false;
                break;
        }

        if (success)
        {
            ulong[] result = LinearPseudoGenerator(m, a, c, start, number);

            Console.Write("Sequence: ");
            File.AppendAllText(fileName, "Sequence: ");
            foreach (ulong num in result)
            {
                Console.Write(num + " ");
                File.AppendAllText(fileName, num + " ");
            }

            int period = FindPeriod2(m, a, c, start);
            Console.WriteLine("\nPeriod: " + period);
            File.AppendAllText(fileName, "\nPeriod: " + period + "\n\n");
        }
    }
}

ulong[] LinearPseudoGenerator(uint m, uint a, uint c, uint start, uint number)
{
    ulong[] resultSequence = new ulong[number];
    resultSequence[0] = start;

    for (int i = 1; i < number; i++)
    {
        resultSequence[i] = (a * resultSequence[i - 1] + c) % m;
    }

    return resultSequence;
}

int FindPeriod(uint m, uint a, uint c, uint start)
{
    int count = 0;

    List<ulong> resultSequence = new List<ulong>();
    ulong prev = start;

    do
    {
        resultSequence.Add(prev);
        prev = (a * prev + c) % m;
        ++count;
    } while (resultSequence.FindIndex(x => x == prev) < 0);

    return count;
}

bool ReadInt(ref uint number)
{
    return UInt32.TryParse(Console.ReadLine(), out number);
}