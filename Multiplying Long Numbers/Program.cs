namespace Multiplying_Long_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Long Numbers Multiplier";

            int argsCount = args.Length;

            if (argsCount > 2 || argsCount <= 0)
            {
                Console.WriteLine("Params: <inputFile1> <inputFile2>, where files contains first and second number for multipliyng" +
                    Environment.NewLine + "OR <inputFile> which contains a number of factorial to calculate." +
                    Environment.NewLine + Environment.NewLine + "Output: out.txt which contains result or <number>!.txt in case of factorial calculation. Will be overwritten if exists." + Environment.NewLine);
                return;
            }

            if (argsCount == 1)
            {
                int inputData = Convert.ToInt32(FileReader.ReadRawDataFromFile(args[0]));
                Processor processor = new Processor();

                for (int i = 2; i <= inputData; ++i)
                {
                    processor.MultiplyResultBy(i.ToString());
                }

                FileReader.WriteDataToFile(processor.Result, $"{inputData}!.txt");
                Console.WriteLine($"{inputData}! = {processor}{Environment.NewLine}");
            }
            else
            {
                string firstNum = FileReader.ReadRawDataFromFile(args[0]);
                string secondNum = FileReader.ReadRawDataFromFile(args[1]);
                Processor processor = new Processor(firstNum, secondNum);
                processor.Multiply();

                FileReader.WriteDataToFile(processor.Result);
                Console.WriteLine($"{processor}{Environment.NewLine}");
            }
        }
    }
}