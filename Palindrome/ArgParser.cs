using System.Text.RegularExpressions;

namespace Palindrome
{
    internal class ArgParser
    {
        private static readonly string wordPattern = "^[A-Za-z]+(-[A-Za-z]+)?$";
        public static void Parse(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            if (args[1] != "--word" && args[1] != "-w")
            {
                Console.WriteLine("incorrect command line arguments");
                return;
            }
            if (!Regex.IsMatch(args[2], wordPattern))
            {
                Console.WriteLine("the word must consist of the letters of the latin alphabet\nit may also contain a dash between parts of the word");
                return;
            }
            if (PalindromeChecker.IsPalindrome(args[2]))
            {
                Console.WriteLine($"The word {args[2]} is a palindrome");
            }
            else
            {
                Console.WriteLine($"The word {args[2]} is NOT a palindrome");
            }
        }
    }
}
