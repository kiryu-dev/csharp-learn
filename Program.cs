internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("need some cmd args");
        }
        else if (args[0] == "temperature")
        {
            Temperature.ArgsParser.Parse(args);
        }
        else if (args[0] == "palindrome")
        {
            Palindrome.ArgParser.Parse(args);
        }
        else if (args[0] == "rabbits")
        {
            Rabbits.ArgParser.Parse(args);
        }
        else if (args[0] == "csvstat")
        {
            CsvStatistics.ArgParser.Parse(args);
        }
        else if (args[0] == "help")
        {
            Console.WriteLine(
                "supported options:\n\t./app temperature --from '{{double}{CFK}}' --to '{C|F|K}'\n\t" +
                "./app palindrome --word '{alphabetic chars with one dash}'\n\t" +
                "./app rabbits --month-num '{integer}'\n\t./app csvstat '{max|min|avg|variance}'\n\t./app help\n"
            );
        }
        else
        {
            Console.WriteLine("invalid option\nlaunch util with 'help' to find out supported options");
        }
    }
}