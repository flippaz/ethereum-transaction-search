using System;

namespace EthereumTransactionSearch.Api.Tests.Builders
{
    public static class RandomBuilder
    {
        private static readonly Random Random = new Random();

        public static string NextHexString()
        {
            return $"0x{NextNumber():x}";
        }

        public static int NextNumber()
        {
            lock (Random)
            {
                return Random.Next();
            }
        }
    }
}