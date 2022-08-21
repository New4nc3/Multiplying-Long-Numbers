namespace Multiplying_Long_Numbers
{
    internal static class FileReader
    {
        public static string ReadRawDataFromFile(string inputFileName)
        {
            if (File.Exists(inputFileName))
            {
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string data = reader.ReadToEnd();
                    int i, count = data.Length;

                    for (i = 0; i < count; ++i)
                    {
                        if (!char.IsDigit(data[i]))
                        {
                            throw new ArgumentException("Input file contains non-digit symbols");
                        }
                    }

                    return data;
                }
            }

            throw new FileNotFoundException();
        }

        public static void WriteDataToFile(string data, string fileName = "out.txt")
        {
            using (StreamWriter writer = new StreamWriter(fileName, append: false))
            {
                writer.Write(data);
            }

            Console.WriteLine($"Successfully saved to \"{fileName}\".{Environment.NewLine}");
        }
    }
}