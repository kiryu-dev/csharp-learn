namespace Rabbits
{
    internal class ArgParser
    {
        public static void Parse(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            if (args[1] != "--month-num" && args[1] != "-m")
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            try
            {
                var pairs = RabbitPairsCounter.Count(uint.Parse(args[2]));
                Console.WriteLine($"after {args[2]} months there will be {pairs} pairs of rabbits");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"unexpected overflow: {e}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"invalid format for entered number of months: {e}");
            }
        }
    }
}
