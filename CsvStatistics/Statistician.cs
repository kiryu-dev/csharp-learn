using System.Numerics;

namespace CsvStatistics
{
    public class StatisticianException : Exception
    {
        public StatisticianException() { }
        public StatisticianException(string message) : base(message) { }
        public StatisticianException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class Statistician<T, V> where T : IComparable<T> where V : INumber<V>
    {
        private Dictionary<T, V> Data { get; }

        public Statistician(Dictionary<T, V> data)
        {
            if (data.Count == 0)
            {
                throw new StatisticianException("got empty data");
            }
            Data = data;
        }

        public T GetMax()
        {
            var key = Data.Keys.Max();
            foreach (var kvp in Data)
            {
                if (kvp.Value.CompareTo(Data[key]) > 0)
                {
                    key = kvp.Key;
                }
            }
            return key;
        }
        public T GetMin()
        {
            var key = Data.Keys.Min();
            foreach (var kvp in Data)
            {
                if (kvp.Value.CompareTo(Data[key]) < 0)
                {
                    key = kvp.Key;
                }
            }
            return key;
        }
        public double GetAvg()
        {
            double sum = 0D;
            foreach (var pair in Data) { sum += Convert.ToDouble(pair.Value); }
            return sum / Data.Count;
        }
        public double GetUnbiasedVariance()
        {
            var avg = Convert.ToDouble(GetAvg());
            double sum = 0D;
            foreach (var pair in Data) { sum += Math.Pow(Convert.ToDouble(pair.Value) - avg, 2); }
            return sum / (Data.Count - 1);
        }
    }
}
