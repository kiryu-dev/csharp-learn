namespace CsvStatistics
{
    public class ReaderException : Exception
    {
        public ReaderException() { }
        public ReaderException(string message) : base(message) { }
        public ReaderException(string message, Exception innerException) : base(message, innerException) { }
    }

    internal class CsvReader
    {
        public static Dictionary<string, uint> Read(string filename, uint ignoreLines, uint readLines)
        {
            using var reader = new StreamReader(filename);
            for (uint i = 0; i < ignoreLines; ++i)
            {
                reader.ReadLine();
            }
            var result = new Dictionary<string, uint>();
            for (uint i = 0; i < readLines; ++i)
            {
                var line = reader.ReadLine() ?? throw new ReaderException("unexpected end of file");
                var values = SplitLine(line, ',');
                if (values.Count <= 2)
                {
                    throw new ReaderException($"unexpected values count in line {ignoreLines + i + 1} in CSV file {filename}");
                }
                try
                {
                    result[values[0]] = uint.Parse(values[^1]);
                }
                catch (Exception e) when (e is FormatException || e is OverflowException)
                {
                    throw new ReaderException($"failed to parse value {values[^1]} in line {ignoreLines + i + 1} in CSV file {filename}", e);
                }
            }
            return result;
        }
        private static List<string> SplitLine(string line, char sep)
        {
            var isInQuotes = false;
            var values = new List<string>();
            var startIdx = 0;
            for (var i = 0; i < line.Length; ++i)
            {
                if (line[i] == '"')
                {
                    isInQuotes ^= true;
                    continue;
                }
                if (!isInQuotes && line[i] == sep)
                {
                    values.Add(line[startIdx..i]);
                    startIdx = i + 1;
                }
            }
            if (!isInQuotes && startIdx != line.Length)
            {
                values.Add(line[startIdx..]);
            }
            return values;
        }
    }
}
