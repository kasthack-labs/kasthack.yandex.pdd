using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Dns;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class DnsRawMethods : RawMethodsBase {
        internal DnsRawMethods( DomainRawContext context ) : base( context ) { }

        public async Task<string> Add( AddRecord record ) =>
                await Context.ProcessRequestPost( "dns/add", new Dictionary<string, string> {
                        { nameof( record.Type ).ToLowerInvariant(), record.Type.ToNCString() },
                        { nameof( record.AdminMail ).ToSnake(), record.AdminMail },
                        { nameof( record.Content ).ToLowerInvariant(), record.Content },
                        { nameof( record.Priority ).ToLowerInvariant(), record.Priority.ToNCString() },
                        { nameof( record.Weight ).ToLowerInvariant(), record.Weight.ToNCString() },
                        { nameof( record.Port ).ToLowerInvariant(), record.Port.ToNCString() },
                        { nameof( record.Target ).ToLowerInvariant(), record.Target }
                    } ).ConfigureAwait( false );

        public async Task<string> List() => await Context.ProcessRequestPost( "dns/list", EmptyParams ).ConfigureAwait( false );

        public async Task<string> Edit( Record record )
            =>
                await
                Context.ProcessRequestPost(
                    "dns/edit",
                    new Dictionary<string, string> {
                        { nameof( record.Type ).ToLowerInvariant(), record.Type.ToNCString() },
                        { nameof( record.AdminMail ).ToSnake(), record.AdminMail },
                        { nameof( record.Content ).ToLowerInvariant(), record.Content },
                        { nameof( record.Priority ).ToLowerInvariant(), record.Priority.ToNCString() },
                        { nameof( record.Weight ).ToLowerInvariant(), record.Weight.ToNCString() },
                        { nameof( record.Port ).ToLowerInvariant(), record.Port.ToNCString() },
                        { nameof( record.Target ).ToLowerInvariant(), record.Target },
                        { nameof( record.Fqdn ).ToLowerInvariant(), record.Fqdn },
                        { nameof( record.Subdomain ).ToLowerInvariant(), record.Subdomain },
                        { nameof( record.RecordId ).ToSnake(), record.RecordId.ToNCString() },
                        { nameof( record.Ttl ).ToSnake(), record.Ttl.ToNCString() },
                        { nameof( record.Refresh ).ToSnake(), record.Refresh.ToNCString() },
                        { nameof( record.Retry ).ToSnake(), record.Retry.ToNCString() },
                        { nameof( record.Expire ).ToSnake(), record.Expire.ToNCString() },
                        { nameof( record.NegCache ).ToSnake(), record.NegCache.ToNCString() },
                    } ).ConfigureAwait( false );

        public async Task<string> Delete( long recordId )
            =>
                await
                Context.ProcessRequestPost(
                    "dns/del",
                    new Dictionary<string, string> { { nameof( recordId ).ToSnake(), recordId.ToNCString() } } ).ConfigureAwait( false );
    }
}