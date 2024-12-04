namespace AdventOfCode.Days;

using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Utils;
public class Day04
{
    const string filepath = "Inputs/Day04.txt";
    public static void Solve()
    {
        string text = File.ReadAllText(filepath);
        // check horizontals with regex because why not i guess.
        string pattern = @"XMAS";
        string pattern2 = @"SAMX";
        Regex rg = new Regex(pattern);
        MatchCollection matches = rg.Matches(text);
        rg = new Regex(pattern2);
        MatchCollection matches2 = rg.Matches(text);
        int xmases = matches.Count + matches2.Count;
        Console.WriteLine(matches.Count + matches2.Count);
        // 140 characters across
        string[] textMatrix = new string[140];
        int i = 0;
        using (StreamReader sr = new StreamReader(filepath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
            textMatrix[i] = line;
            i++;
            }
        }
        for (int x = 0; x < 140; x++)
        {
            for (int y = 0; y < 140; y++)
            {
                if (textMatrix[x][y] == 'X')
                {
                    if (x >=3)
                    {
                        if (textMatrix[x-1][y] == 'M' && textMatrix[x-2][y] == 'A' && (textMatrix[x-3][y] == 'S'))
                        {
                            xmases++;
                        }
                        if (y >= 3)
                        {
                            if (textMatrix[x-1][y-1] == 'M' && textMatrix[x-2][y-2] == 'A' && textMatrix[x-3][y-3] == 'S')
                            {
                                xmases++;
                            }
                        }
                        if (y <= 136)
                        {
                            if (textMatrix[x-1][y+1] == 'M' && textMatrix[x-2][y+2] == 'A' && textMatrix[x-3][y+3] == 'S')
                            {
                                xmases++;
                            }
                        }
                    }
                    if (x <= 136)
                    {
                        if (textMatrix[x+1][y] == 'M' && textMatrix[x+2][y] == 'A' && textMatrix[x+3][y] == 'S')
                        {
                            xmases++;
                        }
                        if (y >= 3)
                        {
                            if (textMatrix[x+1][y-1] == 'M' && textMatrix[x+2][y-2] == 'A' && textMatrix[x+3][y-3] == 'S')
                            {
                                xmases++;
                            }
                        }
                        if (y <= 136)
                        {
                            if (textMatrix[x+1][y+1] == 'M' && textMatrix[x+2][y+2] == 'A' && textMatrix[x+3][y+3] == 'S')
                            {
                                xmases++;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(xmases);
        int mas_count = 0;
        for (int x = 0; x < 140; x++)
        {
            for (int y = 0; y < 140; y++)
            {
                bool dir1 = false;
                bool dir2 = false;
                if (textMatrix[y][x] == 'A')
                {
                    if (y >= 1 && y <= 138 && x >= 1 && x <= 138)
                    {
                        if (textMatrix[y-1][x+1] == 'M' && textMatrix[y+1][x-1] == 'S')
                        {
                            dir1 = true;
                        }
                        if (textMatrix[y-1][x-1] == 'M' && textMatrix[y+1][x+1] == 'S')
                        {
                            dir2 = true;
                        }
                        if (textMatrix[y+1][x+1] == 'M' && textMatrix[y-1][x-1] == 'S')
                        {
                            dir2 = true;
                        }
                        if (textMatrix[y+1][x-1] == 'M' && textMatrix[y-1][x+1] == 'S')
                        {
                            dir1 = true;
                        }
                    }
                    if (dir1 == true && dir2 == true)
                    {
                        mas_count++;
                    }
                }
            }
        }
        Console.WriteLine(mas_count);
    }
}