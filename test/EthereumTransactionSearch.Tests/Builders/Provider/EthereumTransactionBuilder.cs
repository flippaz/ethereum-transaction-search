using EthereumTransactionSearch.Models.Provider;

namespace EthereumTransactionSearch.Api.Tests.Builders.Provider
{
    public class EthereumTransactionBuilder : EthereumTransaction
    {
        public EthereumTransactionBuilder()
        {
            WithBlockHash(RandomBuilder.NextHexString());
            WithBlockNumber(RandomBuilder.NextHexString());
            WithFrom(RandomBuilder.NextHexString());
            WithGas(RandomBuilder.NextHexString());
            WithHash(RandomBuilder.NextHexString());
            WithTo(RandomBuilder.NextHexString());
            WithValue(RandomBuilder.NextHexString());
        }

        public EthereumTransactionBuilder WithBlockHash(string blockHash)
        {
            BlockHash = blockHash;

            return this;
        }

        public EthereumTransactionBuilder WithBlockNumber(string blockNumber)
        {
            BlockNumber = blockNumber;

            return this;
        }

        public EthereumTransactionBuilder WithFrom(string from)
        {
            From = from;

            return this;
        }

        public EthereumTransactionBuilder WithGas(string gas)
        {
            Gas = gas;

            return this;
        }

        public EthereumTransactionBuilder WithHash(string hash)
        {
            Hash = hash;

            return this;
        }

        public EthereumTransactionBuilder WithTo(string to)
        {
            To = to;

            return this;
        }

        public EthereumTransactionBuilder WithValue(string value)
        {
            Value = value;

            return this;
        }
    }
}