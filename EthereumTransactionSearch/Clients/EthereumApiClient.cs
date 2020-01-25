﻿using EthereumTransactionSearch.Exceptions;
using EthereumTransactionSearch.Extensions;
using EthereumTransactionSearch.Models.Provider;
using EthereumTransactionSearch.ReferenceData;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Clients
{
    public class EthereumApiClient : IEthereumApiClient
    {
        private const int EthereumRequestId = 1;
        private const string JsonRpc2 = "2.0";
        private const bool ShowTransactionDetails = true;
        private readonly HttpClient _httpClient;
        private readonly ILogger<EthereumApiClient> _logger;
        private readonly string _projectId;

        public EthereumApiClient(IOptions<EthereumApiClientSettings> settings, ILogger<EthereumApiClient> logger)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(settings.Value.EthereumApiUrl),
                Timeout = TimeSpan.FromMinutes(5)
            };
            _projectId = settings.Value.ProjectId;
            _logger = logger;
        }

        public async Task<EthereumResponse> GetAllTransactionsByBlockNumber(string blockNumber)
        {
            var ethereumRequest = new EthereumRequest
            {
                JsonRpc = JsonRpc2,
                Method = EthereumMethod.GetBlockByNumber.GetDescription(),
                Params = new object[]
                {
                    blockNumber, ShowTransactionDetails
                },
                Id = EthereumRequestId
            };

            string requestContent = ModelConverter.ToJsonString(ethereumRequest);

            using (var request = new HttpRequestMessage(HttpMethod.Post, _projectId))
            {
                using (var content = new StringContent(requestContent, Encoding.UTF8))
                {
                    request.Content = content;

                    using (HttpResponseMessage response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                    {
                        string stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        if (stringContent.Contains("error"))
                        {
                            throw new InvalidRequestException(JsonConvert.DeserializeObject<EthereumErrorResponse>(stringContent).Error.Message);
                        }

                        return JsonConvert.DeserializeObject<EthereumResponse>(stringContent);
                    }
                }
            }
        }
    }
}