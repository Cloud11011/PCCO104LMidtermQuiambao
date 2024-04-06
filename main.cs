using System;

class Program
{
    static void Main(string[] args)
    {
        int baseFanPower = 10;
        int numCycles = 10; // Specify the number of oscillation cycles

        while (true)
        {
            Console.WriteLine("Enter fan speed (1, 2, or 3):");
            string speedInput = Console.ReadLine();

            int fanSpeed;
            if (!int.TryParse(speedInput, out fanSpeed) || fanSpeed < 1 || fanSpeed > 3)
            {
                Console.WriteLine("Invalid input. Please enter a valid fan speed (1, 2, or 3).");
                continue;
            }

            Console.WriteLine("Oscillate? (Y/N):");
            string oscillateInput = Console.ReadLine().ToUpper();

            bool oscillate;
            if (oscillateInput != "Y" && oscillateInput != "N")
            {
                Console.WriteLine("Invalid input. Please enter Y or N for oscillate option.");
                continue;
            }

            oscillate = oscillateInput == "Y";

            int fanPowerOutput = baseFanPower * fanSpeed;

            if (oscillate)
            {
                Console.WriteLine("Oscillate output:");
                DisplayOscillateOutput(fanPowerOutput, numCycles);
            }
            else
            {
                Console.WriteLine("Steady output:");
                for (int i = 0; i < 10; i++)
                {
                    DisplaySteadyOutput(fanPowerOutput);
                }
            }

            Console.WriteLine("Do you want to simulate again? (Y/N):");
            string repeatInput = Console.ReadLine().ToUpper();
            if (repeatInput != "Y")
                break;
        }
    }

    static void DisplayOscillateOutput(int fanPower, int numCycles)
    {
        int consoleWidth = Console.WindowWidth;
        bool moveRight = true;
        int startPosition = 0;
        bool isIncreasing = true;
        int cycleCount = 0;

        while (cycleCount < numCycles)
        {
            Console.Clear();

            if (isIncreasing)
            {
                for (int i = 3; i <= fanPower; i += 3)
                {
                    Console.SetCursorPosition(startPosition, Console.CursorTop);
                    Console.WriteLine(new string('~', i));
                }
            }
            else
            {
                for (int i = fanPower; i >= 3; i -= 3)
                {
                    Console.SetCursorPosition(startPosition, Console.CursorTop);
                    Console.WriteLine(new string('~', i));
                }
            }

            if (moveRight)
            {
                startPosition++;
                if (startPosition + fanPower > consoleWidth)
                {
                    moveRight = false;
                    startPosition = consoleWidth - fanPower;
                }
            }
            else
            {
                startPosition--;
                if (startPosition < 0)
                {
                    moveRight = true;
                    startPosition = 0;
                }
            }

            isIncreasing = !isIncreasing;
            cycleCount++;
            System.Threading.Thread.Sleep(100); // Adjust speed of oscillation
        }
    }

    static void DisplaySteadyOutput(int fanPower)
    {
        Console.WriteLine(new string('~', fanPower));
    }
}
