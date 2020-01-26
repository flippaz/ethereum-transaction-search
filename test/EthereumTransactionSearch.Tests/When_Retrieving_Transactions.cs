using EthereumTransactionSearch.Api.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
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
    }
}