using EthereumTransactionSearch.Api.Tests.Builders;
using EthereumTransactionSearch.Api.Tests.Builders.Provider;
using EthereumTransactionSearch.Api.Tests.Fixtures;
using EthereumTransactionSearch.Api.Tests.TestDoubles;
using EthereumTransactionSearch.Api.Tests.TheoryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EthereumTransactionSearch.Models.Provider;
using FluentAssertions;
using Xunit;

namespace EthereumTransactionSearch.Api.Tests
{
    public class When_Retrieving_Transactions
    {
        public class And_Block_Number_Or_Address_Format_Is_Invalid
        {
            [Theory]
            [InlineData("123", null)]
            [InlineData("123", "")]
            [InlineData("123", "0x456")]
            [InlineData("0x123", "456")]
            public async Task A_Bad_Request_Response_Is_Returned(string blockNumber, string address)
            {
                var fixture = new GetTransactionsFixture();
                var response = await fixture.GetTransactions(blockNumber, address) as ObjectResult;

                Assert.Equal((int)HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        public class And_Exception_Occurs_When_Calling_Provider
        {
            [Fact]
            public void It_Retries_And_Throws_Exception()
            {
                var ethereumApiClient = new NotImplementedEthereumApiClient();
                var fixture = new GetTransactionsFixture()
                    .WithEthereumApiClient(ethereumApiClient);

                Assert.ThrowsAsync<Exception>(
                    () => fixture.GetTransactions(RandomBuilder.NextHexString(), null));

                Assert.Equal(1, ethereumApiClient.RetryCount);
            }
        }

        public class And_Block_Number_Can_Not_Be_Found
        {
            [Fact]
            public async Task It_Returns_Null_Response()
            {
                var ethereumApiClient = new EthereumApiClientStub()
                    .WithTransactionsResponse(
                        new EthereumResponseBuilder()
                            .WithEthereumResult(null));

                var fixture = new GetTransactionsFixture()
                    .WithEthereumApiClient(ethereumApiClient);

                var response = await fixture.GetTransactions(
                    RandomBuilder.NextHexString(),
                    RandomBuilder.NextHexString()) as ObjectResult;

                Assert.Null(response.Value);
            }
        }

        public class And_Block_Number_Is_Found
        {
            public class And_Address_Is_Not_Supplied
            {
                [Fact]
                public async Task It_Returns_All_Transactions_For_Given_Block_Number()
                {
                    var theoryData = new GetTransactionsTheoryData();

                    var ethereumApiClient = new EthereumApiClientStub()
                        .WithTransactionsResponse(theoryData.EthereumResponse);

                    var fixture = new GetTransactionsFixture()
                        .WithEthereumApiClient(ethereumApiClient);

                    var response = await fixture.GetTransactions(
                        theoryData.BlockNumber,
                        null) as ObjectResult;

                    response.Value.Should().BeEquivalentTo(theoryData.ExpectedAllTransactions);
                }
            }

            public class And_Address_Is_Supplied
            {
                [Fact]
                public async Task It_Returns_Transactions_From_Given_Address()
                {
                    var theoryData = new GetTransactionsTheoryData();

                    var ethereumApiClient = new EthereumApiClientStub()
                        .WithTransactionsResponse(theoryData.EthereumResponse);

                    var fixture = new GetTransactionsFixture()
                        .WithEthereumApiClient(ethereumApiClient);

                    var response = await fixture.GetTransactions(
                        theoryData.BlockNumber,
                        theoryData.Address1) as ObjectResult;

                    response.Value.Should().BeEquivalentTo(theoryData.ExpectedAddressTransactions);
                }
            }

            public class And_Address_Is_Supplied_And_Not_Found
            {
                [Fact]
                public async Task It_Returns_Empty_Response()
                {
                    var theoryData = new GetTransactionsTheoryData();

                    var ethereumApiClient = new EthereumApiClientStub()
                        .WithTransactionsResponse(theoryData.EthereumResponse);

                    var fixture = new GetTransactionsFixture()
                        .WithEthereumApiClient(ethereumApiClient);

                    var response = await fixture.GetTransactions(
                        theoryData.BlockNumber,
                        RandomBuilder.NextHexString()) as ObjectResult;

                    response.Value.Should().BeEquivalentTo(new List<EthereumTransaction>());
                }
            }
        }
    }
}