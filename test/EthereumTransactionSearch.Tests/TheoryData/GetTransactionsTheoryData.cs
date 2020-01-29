using EthereumTransactionSearch.Api.Tests.Builders;
using EthereumTransactionSearch.Api.Tests.Builders.Provider;
using EthereumTransactionSearch.Models.Provider;
using System.Collections.Generic;
using System.Linq;

namespace EthereumTransactionSearch.Api.Tests.TheoryData
{
    public class GetTransactionsTheoryData
    {
        public string Address1;
        public string BlockNumber;
        
        private readonly string _address2;
        private readonly string _address3;
        private readonly string _transaction1BlockHash;
        private readonly string _transaction1Gas;
        private readonly string _transaction1Hash;
        private readonly string _transaction1To;
        private readonly string _transaction1Value;
        private readonly string _transaction2BlockHash;
        private readonly string _transaction2Gas;
        private readonly string _transaction2Hash;
        private readonly string _transaction2To;
        private readonly string _transaction2Value;
        private readonly string _transaction3BlockHash;
        private readonly string _transaction3Gas;
        private readonly string _transaction3Hash;
        private readonly string _transaction3To;
        private readonly string _transaction3Value;
        private readonly string _transaction4BlockHash;
        private readonly string _transaction4Gas;
        private readonly string _transaction4Hash;
        private readonly string _transaction4To;
        private readonly string _transaction4Value;
        private readonly string _transaction5BlockHash;
        private readonly string _transaction5Gas;
        private readonly string _transaction5Hash;
        private readonly string _transaction5To;
        private readonly string _transaction5Value;

        public GetTransactionsTheoryData()
        {
            Address1 = RandomBuilder.NextHexString();
            BlockNumber = RandomBuilder.NextHexString();
            
            _address2 = RandomBuilder.NextHexString();
            _address3 = RandomBuilder.NextHexString();
            _transaction1BlockHash = RandomBuilder.NextHexString();
            _transaction1Gas = RandomBuilder.NextHexString();
            _transaction1Hash = RandomBuilder.NextHexString();
            _transaction1To = RandomBuilder.NextHexString();
            _transaction1Value = RandomBuilder.NextHexString();
            _transaction2BlockHash = RandomBuilder.NextHexString();
            _transaction2Gas = RandomBuilder.NextHexString();
            _transaction2Hash = RandomBuilder.NextHexString();
            _transaction2To = RandomBuilder.NextHexString();
            _transaction2Value = RandomBuilder.NextHexString();
            _transaction3BlockHash = RandomBuilder.NextHexString();
            _transaction3Gas = RandomBuilder.NextHexString();
            _transaction3Hash = RandomBuilder.NextHexString();
            _transaction3To = RandomBuilder.NextHexString();
            _transaction3Value = RandomBuilder.NextHexString();
            _transaction4BlockHash = RandomBuilder.NextHexString();
            _transaction4Gas = RandomBuilder.NextHexString();
            _transaction4Hash = RandomBuilder.NextHexString();
            _transaction4To = RandomBuilder.NextHexString();
            _transaction4Value = RandomBuilder.NextHexString();
            _transaction5BlockHash = RandomBuilder.NextHexString();
            _transaction5Gas = RandomBuilder.NextHexString();
            _transaction5Hash = RandomBuilder.NextHexString();
            _transaction5To = RandomBuilder.NextHexString();
            _transaction5Value = RandomBuilder.NextHexString();
        }

        public EthereumResponse EthereumResponse =>
            new EthereumResponseBuilder()
                .WithEthereumError(null)
                .WithEthereumResult(
                    new EthereumResultBuilder()
                        .WithTransactions(
                            GetAllTransactions()));

        public List<EthereumTransaction> ExpectedAddressTransactions =>
            new List<EthereumTransaction>
            {
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction1BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(Address1)
                    .WithGas(_transaction1Gas)
                    .WithHash(_transaction1Hash)
                    .WithTo(_transaction1To)
                    .WithValue(_transaction1Value),
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction4BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(Address1)
                    .WithGas(_transaction4Gas)
                    .WithHash(_transaction4Hash)
                    .WithTo(_transaction4To)
                    .WithValue(_transaction4Value)
            };

        public List<EthereumTransaction> ExpectedAllTransactions => GetAllTransactions().ToList();

        private EthereumTransaction[] GetAllTransactions() =>
            new EthereumTransaction[]
            {
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction1BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(Address1)
                    .WithGas(_transaction1Gas)
                    .WithHash(_transaction1Hash)
                    .WithTo(_transaction1To)
                    .WithValue(_transaction1Value),
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction2BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(_address2)
                    .WithGas(_transaction2Gas)
                    .WithHash(_transaction2Hash)
                    .WithTo(_transaction2To)
                    .WithValue(_transaction2Value),
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction3BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(_address2)
                    .WithGas(_transaction3Gas)
                    .WithHash(_transaction3Hash)
                    .WithTo(_transaction3To)
                    .WithValue(_transaction3Value),
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction4BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(Address1)
                    .WithGas(_transaction4Gas)
                    .WithHash(_transaction4Hash)
                    .WithTo(_transaction4To)
                    .WithValue(_transaction4Value),
                new EthereumTransactionBuilder()
                    .WithBlockHash(_transaction5BlockHash)
                    .WithBlockNumber(BlockNumber)
                    .WithFrom(_address3)
                    .WithGas(_transaction5Gas)
                    .WithHash(_transaction5Hash)
                    .WithTo(_transaction5To)
                    .WithValue(_transaction5Value)
            };
    }
}