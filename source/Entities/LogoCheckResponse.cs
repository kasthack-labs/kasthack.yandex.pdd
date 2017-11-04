using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Entities
{
    public class LogoCheckResponse : Response
    {
        [JsonProperty("logo-url")]
        public string LogoUrl { get; set; }
    }
}