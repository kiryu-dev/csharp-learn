namespace Palindrome
{
    internal class PalindromeChecker
    {
        public static bool IsPalindrome(string word)
        {
            for (var i = 0; i < word.Length / 2; ++i)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
