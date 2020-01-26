using System;

namespace EthereumTransactionSearch.Api.Tests.Builders
{
    public static class RandomBuilder
    {
        private static readonly Random Random = new Random();

        public static bool NextBool()
        {
            return NextNumber(2) == 0;
        }

        public static byte NextByte()
        {
            lock (Random)
            {
                var b = new byte[1];
                Random.NextBytes(b);

                return b[0];
            }
        }

        public static DateTime NextDateTime()
        {
            return new DateTime(NextNumber());
        }

        public static DateTime NextDateTimeToMillisecond()
        {
            var startTime = new DateTime(2000, 01, 01, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan maxOffset = DateTime.UtcNow - startTime;
            int totalSeconds = NextNumber((int)maxOffset.TotalSeconds);
            int milliseconds = NextNumber(1000);

            return startTime + TimeSpan.FromSeconds(totalSeconds) + TimeSpan.FromMilliseconds(milliseconds);
        }

        public static decimal NextDecimal()
        {
            return (decimal)NextDouble();
        }

        public static double NextDouble()
        {
            lock (Random)
            {
                return Random.NextDouble();
            }
        }

        public static T NextEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));

            return (T)values.GetValue(NextNumber(values.Length));
        }

        public static int NextNumber()
        {
            lock (Random)
            {
                return Random.Next();
            }
        }

        public static int NextNumber(int maxValue)
        {
            lock (Random)
            {
                return Random.Next(maxValue);
            }
        }

        public static string NextString()
        {
            return Guid.NewGuid().ToString();
        }
    }
}