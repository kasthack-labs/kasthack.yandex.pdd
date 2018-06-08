using System;
using System.Collections.Generic;
using System.Text;

namespace kasthack.yandex.pdd.test
{
    internal class AccessData
    {
        public AccessData(string oauthToken, string domain, string pddToken) {
            OAuthToken = oauthToken;
            Domain = domain;
            PddToken = pddToken;
        }
        public string OAuthToken { get; }
        public string Domain { get; }
        public string PddToken { get; }
    }
}
