namespace CsvStatistics
{
    internal class ArgParser
    {
        public static void Parse(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            try
            {
                var data = CsvStatistics.CsvReader.Read(@"C:\Users\sailo\source\repos\csharp-learn\data\zdr2-1.csv", 8, 16);
                var stat = new CsvStatistics.Statistician<string, uint>(data);
                if (args[1] == "max")
                {
                    var key = stat.GetMax();
                    Console.WriteLine($"max value and its category: {data[key]}, {key}");
                }
                else if (args[1] == "min")
                {
                    var key = stat.GetMin();
                    Console.WriteLine($"min value and its category: {data[key]}, {key}");
                }
                else if (args[1] == "avg")
                {
                    Console.WriteLine($"avg value: {stat.GetAvg()}");
                }
                else if (args[1] == "variance")
                {
                    Console.WriteLine($"unbiased sample variance: {stat.GetUnbiasedVariance()}");
                }
                else
                {
                    Console.WriteLine("incorrect command line arguments");
                }
            }
            catch (ReaderException e)
            {
                Console.WriteLine($"reader error: {e}");
            }
            catch (StatisticianException e)
            {
                Console.WriteLine($"statistician error: {e}");
            }
        }
    }
}
