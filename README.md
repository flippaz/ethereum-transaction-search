# Ethereum Transaction Service
The Ethereum Transaction Service allows searching an Ethereum block for all transactions associated with an address. The results of the transactions are displayed in a tabulated form:

| Block Hash | Block Number | Gas | Hash | From | To | Value |

## Requirements and set up
The `dotnetcore3.1` sdk is required to run the application and execute tests. Installation can be found [here](https://dotnet.microsoft.com/download).

### Steps
Set `ProjectId` within `appsettings.Development.json` if running from local development or as an environment variable `EthreumTransactionSearch_ProjectId`.

## Running the Service

### Steps
From within the solution folder, run the following commands to:

1. Execute tests `dotnet test test\EthereumTransactionSearch.Tests\EthereumTransactionSearch.Api.Tests.csproj`
2. Run the application `dotnet run -p src\EthereumTransactionSearch`