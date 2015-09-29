# Yandex PDD API for .NET
## Docs
### API Description by yandex
https://tech.yandex.ru/pdd/doc/about-docpage/
### Sample:
```c#
var unread =
    (
        await                   // we only have async methods
            new PddApi(
                "PddToken",
                /*
                    get it here: https://pddimp.yandex.ru/api2/admin/get_token
                */
                "OAuthToken"
                /*
                    Getting oauth token:
                        a)
                            build oauth uri with YaToken.GetOAuthURL
                            feed redirect uri to FromRedirectUrl
                        b)
                            implicit cast from token string like here
                */
            )
            .Domain( "who.ec" ) //get domain context
            .Mail
            .Counters( "test@who.ec" )
    )
    .Counters
    .Unread;
```
## Implemented Methods
* Mail
    * Add
    * Del
    * List
    * Edit
    * Counters