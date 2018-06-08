
using System;

namespace kasthack.yandex.pdd.test
{
    static class SetupHelper
    {
        public static AccessData GetData() {

            return new AccessData(
                oauthToken: Environment.GetEnvironmentVariable("KYPTOKEN"),
                pddToken: Environment.GetEnvironmentVariable("KYPPDD"),
                domain: Environment.GetEnvironmentVariable("KYPDOM")
            );
        }
    }
}
