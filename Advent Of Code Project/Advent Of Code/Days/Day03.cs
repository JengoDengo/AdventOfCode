namespace AdventOfCode.Days;

using System.Text.RegularExpressions;
using AdventOfCode.Utils;
public class Day03
{
    const string filepath = "Inputs/Day03.txt";
    public static void Solve()
    {
        string text = File.ReadAllText(filepath);
        string pattern = @"mul\(\d+,\d+\)";
        Regex rg = new Regex(pattern);
        MatchCollection matchedWords = rg.Matches(text);
        int total = 0;

        string patternDo = @"do\(\)";
        string patternDont = @"don't\(\)";
        rg = new Regex(patternDo);
        MatchCollection matchedDos = rg.Matches(text);
        rg = new Regex(patternDont);

        MatchCollection matchedDonts = rg.Matches(text);

        for (int i = 0; i < matchedWords.Count; i++)
        {
            string match = matchedWords[i].ToString();
            int matchIndex = matchedWords[i].Index;

            int doIndex = GetClosestMatch(matchIndex, matchedDos);
            int dontIndex = GetClosestMatch(matchIndex, matchedDonts);
            if (dontIndex > doIndex)
                continue;

            if (doIndex < dontIndex)
                continue;
            //remove mul(
            match = match.Remove(0,4);
            match = match.Replace(")","");
            string[] numbers = match.Split(",");
            total += Convert.ToInt32(numbers[0]) * Convert.ToInt32(numbers[1]);
        }
        Console.WriteLine(total);
    }

    static int GetClosestMatch(int index, MatchCollection collection)
    {
        int closestIndex = -1;
        for (int i = 0; i < collection.Count; i++)
        {
            if (index > collection[i].Index && collection[i].Index > closestIndex)
            {
                closestIndex = collection[i].Index;
            }
        }
        return closestIndex;
    }
}