

namespace Eum.EventBus.Core.Serialization
{
    public class JsonEventSerializer : IEventSerializer
    {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.None,
            Converters = new[] { new StringEnumConverter() },
        };

        public string Serialize<TEvent>(TEvent @event)
        {
            return JsonConvert.SerializeObject(@event, _jsonSerializerSettings);
        }
    }
}
