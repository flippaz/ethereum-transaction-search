using Newtonsoft.Json;

namespace EthereumTransactionSearch.Models.Provider
{
    public class EthereumRequest
    {
        public int Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }

        public string Method { get; set; }

        public object[] Params { get; set; }
    }
}