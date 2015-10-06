# Yandex PDD API for .NET
## Installation
```powershell
Install-Package kasthack.yandex.pdd
```
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
## API coverage
### Implemented
* Mail
    * Add
    * Del
    * List
    * Edit
    * Counters
* DKIM
    * Status
    * Enable
    * Disable
* DNS
    * Add
    * List
    * Edit
    * Delete
* Domain
    * Register
    * RegistrationStatus
    * Details
    * Delete
    * SetCountry
    * GetLogo
    * DeleteLogo
    * SetLogo
* Import
    * CheckSettings
    * StartOneImport
    * CheckImport
    * StopAllImports
* Maillist
    * Add
    * List
    * Delete
    * Subscribe
    * Subscribers
    * Unsubscribe
    * GetCanSendOnBehalf
    * SetCanSendOnBehalf
    * Import file
* Domains
    * List
* Deputy
    * Add
    * List
    * Delete