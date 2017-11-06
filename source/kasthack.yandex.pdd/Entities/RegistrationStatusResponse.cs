using System;

namespace kasthack.yandex.pdd.Entities
{
    public class RegistrationStatusResponse : Response
    {
        public RegistrationStage Stage { get; set; }
        public CheckResult CheckResults { get; set; }
        public DateTime NextCheck { get; set; }
        public DateTime LastCheck { get; set; }
        public Secrects Secrects { get; set; }
    }
}