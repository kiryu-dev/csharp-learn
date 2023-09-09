using System.Globalization;
using System.Text.RegularExpressions;

namespace Temperature
{
    internal class ArgsParser
    {
        private static readonly string degreePattern = "^([+-]?\\d+(\\.\\d+)?)[CFK]$";
        private static readonly string scalePattern = "^[CFK]$";
        public static void Parse(string[] args)
        {
            uint degreeIdx = 0, scaleIdx = 0;
            for (uint i = 0; i < args.Length; ++i)
            {
                if (i + 1 == args.Length && (args[i].StartsWith("-") || args[i].StartsWith("--")))
                {
                    Console.WriteLine("incorrect command line arguments");
                    return;
                }
                if (args[i] == "--from" || args[i] == "-f")
                {
                    degreeIdx = i + 1;
                }
                else if (args[i] == "--to" || args[i] == "-t")
                {
                    scaleIdx = i + 1;
                }
            }
            if (degreeIdx == 0 && scaleIdx == 0)
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            if (!Regex.IsMatch(args[degreeIdx], degreePattern))
            {
                Console.WriteLine("incorrect degree format: expected '{{double}{CFK}}'");
                return;
            }
            if (!Regex.IsMatch(args[scaleIdx], scalePattern))
            {
                Console.WriteLine("incorrect scale format: expected '{C|F|K}'");
                return;
            }
            try
            {
                var degree = Double.Parse(args[degreeIdx][..^1], CultureInfo.InvariantCulture);
                var fromScale = CharToScale(args[degreeIdx][^1]);
                var toScale = CharToScale(args[scaleIdx].ToCharArray()[0]);
                Console.WriteLine($"result: {args[degreeIdx]} is {DegreeConverter.Convert(degree, fromScale, toScale)}{args[scaleIdx]}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"unexpected overflow: {e}");
            }
        }

        private static Scale CharToScale(char sym)
        {
            if (sym == 'F')
            {
                return Scale.Fahrenheit;
            }
            if (sym == 'K')
            {
                return Scale.Kelvin;
            }
            return Scale.Celsius;
        }
    }
}
