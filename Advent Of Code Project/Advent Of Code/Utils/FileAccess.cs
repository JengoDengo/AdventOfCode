namespace AdventOfCode.Utils;
class FileAccess
{
    /// <summary>
    /// Reads text from a file and returns an array of every line in the file
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns>The array of the lines in the array</returns> <summary>
    /// 
    /// </summary>
    /// <param name="filepath">The path of the file to read from</param>
    /// <returns></returns>
    public static string[] ReadFile(string filepath)
    {
        List<string> outputList = new List<string>();
        using (StreamReader sr = new StreamReader(filepath))
        {
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                outputList.Add(line);
            }
        }
        return outputList.ToArray();
    }
}