using System.Runtime.Versioning;

namespace Rabbits
{
    internal class RabbitPairsCounter
    {
        public static uint Count(uint monthNumber)
        {
            uint prev = 1, cur = 1;
            for (uint i = 1; i < monthNumber; ++i)
            {
                var tmp = cur;
                cur += prev;
                prev = tmp;
            }
            return cur;
        }
    }
}
