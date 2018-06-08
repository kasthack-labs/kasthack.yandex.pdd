using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Entities
{
    public class DomainInfo
    {
        public string Name { get; set; }
        public DomainStatus Status { get; set; }
        public RegistrationStage Stage { get; set; }
        public string[] Aliases { get; set; }
        public bool LogoEnabled { get; set; }
        public string LogoUrl { get; set; }
        public bool Nsdelegated { get; set; }
        public bool MasterAdmin { get; set; }

        [JsonProperty("dkim-ready")]
        public bool? DkimReady { get; set; }

        [JsonProperty("emails-max-count")]
        public int EmailsMaxCount { get; set; }

        [JsonProperty("emails-count")]
        public int EmailsCount { get; set; }

        public bool Nodkim { get; set; }

        //---------------------undocumented
        public bool FromRegistrar { get; set; }
        public bool WsTechnical { get; set; }
    }
}