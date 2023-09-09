namespace Temperature
{
    public enum Scale : byte
    {
        Celsius,
        Fahrenheit,
        Kelvin
    }

    internal class DegreeConverter
    {
        public static double Convert(double value, Scale from, Scale to)
        {
            return ConvertFromCelsius(ConvertToCelsius(value, from), to);
        }

        private static double ConvertToCelsius(double value, Scale from)
        {
            if (from == Scale.Kelvin)
            {
                return value - 273.15;
            }
            if (from == Scale.Fahrenheit)
            {
                return 5D * (value - 32D) / 9D;
            }
            return value;
        }

        private static double ConvertFromCelsius(double value, Scale to)
        {
            if (to == Scale.Kelvin)
            {
                return value + 273.15;
            }
            if (to == Scale.Fahrenheit)
            {
                return 9D * value / 5D + 32D;
            }
            return value;
        }

    }
}
