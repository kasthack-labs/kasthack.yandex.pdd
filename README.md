Yandex PDD API for .NET
===========

Docs
===========
API Description by yandex: https://tech.yandex.ru/pdd/doc/about-docpage/

Sample:

```c#
	var unread = (
		await new PddApi ("TestToken")
			.Domain( "who.ec" )
			.Mail
			.Counters( "test@who.ec" )
		).Counters.Unread;
```

Implemented Methods
===========	
	* Mail
		
		* Add
		
		* Del
		
		* List
		
		* Edit
		
		* Counters
		
	