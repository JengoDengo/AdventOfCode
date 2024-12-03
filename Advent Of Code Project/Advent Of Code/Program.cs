namespace AdventOfCode;
class Program
{
    static void Main()
    {
        while (true)
            {
            Console.Write("Which day's program would you like to execute, QUIT to exit: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Days.Day01.Solve();
                    break;
                case "2":
                    Days.Day02.Solve();
                    break;
                case "3":
                    Days.Day03.Solve();
                    break;
                case "4":
                    Days.Day04.Solve();
                    break;
                case "QUIT":
                    return;
                default:
                    Console.WriteLine("Invalid input!");
                    break;                
            }
        }
    }
}