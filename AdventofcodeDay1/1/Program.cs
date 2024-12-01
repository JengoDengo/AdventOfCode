namespace AdventOfCode
{
    class Program 
    {
        const string filepath = "input.txt";
        static void Main()
        {
            // Every number is five characters long! (: Also 1000 numbers
            // Part 1!
            int[] numbersLeft = new int[1000];
            int[] numbersRight = new int[1000];
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    int leftNum = Convert.ToInt32(line.Substring(0,5));
                    int rightNum = Convert.ToInt32(line.Substring(8,5));
                    numbersLeft[i] = leftNum;
                    numbersRight[i] = rightNum;
                    i++;
                }
            }
            Array.Sort(numbersLeft);
            Array.Sort(numbersRight);
            int totalDiff = 0;
            for (int i = 0; i < numbersLeft.Length; i++)
            {
                int diff = Math.Abs(numbersRight[i] - numbersLeft[i]);
                totalDiff += diff;
            }
            Console.WriteLine(totalDiff);


            // Part 2!

            int total = 0;
            for (int i = 0; i < numbersLeft.Length; i++)
            {
                if (numbersLeft[i] < numbersRight[i])
                {
                    total += numbersLeft[i] * CheckDuplicates(numbersLeft[i], numbersRight, 0, i);
                }
                else if (numbersLeft[i] > numbersRight[i])
                {
                    total += numbersLeft[i] * CheckDuplicates(numbersLeft[i], numbersRight, i+1, numbersRight.Length);
                }
                else 
                {
                    total += numbersLeft[i] * CheckDuplicates(numbersLeft[i], numbersRight, 0, numbersRight.Length);
                }
            }
            Console.WriteLine(total);
        }

        // Checks for duplicates in a list in a certain range, returns number of duplicates
        static int CheckDuplicates(int num, int[] list, int start, int end)
        {
            int duplicates = 0;
            for (int i = start; i < end; i++)
            {
                if (list[i] == num)
                {
                    duplicates++;
                }
            }
            return duplicates;
        }
    }
}