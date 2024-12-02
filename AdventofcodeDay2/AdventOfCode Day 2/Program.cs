namespace AdventOfCode
{
    class Program
    {
        const string filepath = "input.txt";
        static void Main()
        {
            // Quite badly written but I wanted to do this one quickly
            // Also leaving all programs as they were written when i did this, not changing them afterwards
            string[] reports = new string[1000];
            using (StreamReader sr = new StreamReader(filepath))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    reports[i] = line;
                    i++;
                }
            }
            int safeReports = 0;
            for (int i = 0; i < reports.Length; i++)
            {
                List<int> intReport = new List<int>();
                foreach (string item in reports[i].Split(" "))
                {
                    intReport.Add(Convert.ToInt32(item));
                }
                bool ascending = false;
                int unsafe_instances = 0;
                for (int j = 1; j < intReport.Count; j++)
                {
                    if (j == 1)
                    {
                        ascending = intReport[1] > intReport[0];
                        if (intReport[1] > intReport[0] + 3 || intReport[1] < intReport[0] - 3)
                        {
                            // Unsafe
                            unsafe_instances++;
                        }
                    }
                    else if (ascending == true)
                    {
                        if (intReport[j] < intReport[j-1])
                        {
                            Console.WriteLine("Unsafe");
                            unsafe_instances++;
                        }
                        if (intReport[j] > intReport[j-1] + 3)
                        {
                            Console.WriteLine("Unsafe");
                            // Unsafe
                            unsafe_instances++;
                        }
                    }
                    else
                    {
                        if (intReport[j] > intReport[j-1])
                        {
                            Console.WriteLine("Unsafe");
                            // Unsafe
                            unsafe_instances++;
                        }
                        if (intReport[j] < intReport[j-1] - 3)
                        {
                            Console.WriteLine("Unsafe");
                            // Unsafe
                            unsafe_instances++;
                        }
                    }


                    if (intReport[j] == intReport[j-1])
                    {
                        Console.WriteLine("Unsafe");
                        // Unsafe
                        unsafe_instances++;
                    }
                }
                if (unsafe_instances <= 1)
                {
                    safeReports++;
                }
            }
            Console.WriteLine(safeReports);
        }
    }
}