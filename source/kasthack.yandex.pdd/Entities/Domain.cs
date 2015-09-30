using System;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Domain {
    public class DomainsResponse : PageableResponse {
        public DomainInfo[] Domains { get; set; }
    }

    public class RegisterResponse : Response {
        public Secrects Secrects { get; set; }
    }

    public class RegistrationStatusResponse : Response {
        public RegistrationStage Stage { get; set; }
        public CheckResult CheckResults { get; set; }
        public DateTime NextCheck { get; set; }
        public DateTime LastCheck { get; set; }
        public Secrects Secrects { get; set; }
    }

    public class DetailsResponse : Response {
        public DomainStatus Status { get; set; }
        public RegistrationStage Stage { get; set; }
        public bool Delegated { get; set; }
        public Country Country { get; set; }
        public bool PopEnabled { get; set; }
        public bool ImapEnabled { get; set; }
        public string DefaultTheme { get; set; }
    }

    public class LogoCheckResponse : Response {
        [JsonProperty( "logo-url" )]
        public string LogoUrl { get; set; }
    }

    public class DomainInfo {
        public string Name { get; set; }
        public DomainStatus Status { get; set; }
        public string Stage { get; set; }
        public string[] Aliases { get; set; }
        public bool LogoEnabled { get; set; }
        public string LogoUrl { get; set; }
        public bool NsDelegated { get; set; }
        public bool MasterAdmin { get; set; }

        [JsonProperty( "dkim-ready" )]
        public bool DkimReady { get; set; }

        [JsonProperty( "emails-max-count" )]
        public int EmailsMaxCount { get; set; }

        [JsonProperty( "emails-count" )]
        public int EmailsCount { get; set; }

        public bool NoDKIM { get; set; }
    }

    public enum Country {
        RU,
        EN,
        UA,
        TR,
        BY,
        AZ,
        RO,
        GE,
        KZ,
    }

    public enum RegistrationStage {
        OwnerCheck,
        MXCheck,
        Added
    }

    public enum DomainStatus {
        DomainActivate,
        MxActivate,
        Added
    }

    public class Secrects {
        public string Name { get; set; }
        public string Content { get; set; }
    }

    public enum CheckResult {
        OK,
        NoCNameNoFile,
        BadCNameBadFile,
        BadCNameNoFile,
        DomainNotFound,
        Occupied,
        MXWrong,
        MXNotFound
    }
}