using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EthereumTransactionSearch.Extensions
{
    public class ModelConverter
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings;

        static ModelConverter()
        {
            JsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static string ToJsonString(object model)
        {
            return JsonConvert.SerializeObject(model, JsonSerializerSettings);
        }
    }
}