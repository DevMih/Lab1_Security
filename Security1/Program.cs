Main();

void Main()
{
    int m = (int)Math.Pow(2, 15) - 1;
    int a = (int)Math.Pow(2, 3);
    int c = 8;
    int start = 64;
    int number = 100;
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
            double[] result = LinearPseudoGenerator(m, a, c, start, number);

            Console.Write("Sequence: ");
            File.AppendAllText(fileName, "Sequence: ");
            foreach (double num in result)
            {
                Console.Write(num + " ");
                File.AppendAllText(fileName, num + " ");
            }

            int period = FindPeriod(m, a, c, start);
            Console.WriteLine("\nPeriod: " + period);
            File.AppendAllText(fileName, "\nPeriod: " + period + "\n\n");
        }
    }
}

double[] LinearPseudoGenerator(double m, double a, double c, double start, int number)
{
    double[] resultSequence = new double[number];
    resultSequence[0] = start;

    for (int i = 1; i < number; i++)
    {
        resultSequence[i] = (a * resultSequence[i - 1] + c) % m;
    }

    return resultSequence;
}

int FindPeriod(double m, double a, double c, double start)
{
    double next = start;
    int count = 0;

    do
    {
        next = (a * next + c) % m;
        ++count;

    } while (next != start);

    return count;
}


bool ReadInt(ref int number)
{
    return Int32.TryParse(Console.ReadLine(), out number);
}