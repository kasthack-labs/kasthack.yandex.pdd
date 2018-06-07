using System;

namespace kasthack.yandex.pdd.sampleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            string appid;
            appid = "<repo_stub>";
            var oauthUrl = YaToken.GetOAuthUri(appid);
            Console.WriteLine(oauthUrl);
            Console.ReadLine();
        }
    }
}
