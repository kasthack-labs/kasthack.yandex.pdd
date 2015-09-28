﻿using kasthack.yandex.pdd.Helpers;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Api {
    public class PddApi {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;
        public string PddToken
        {
            get { return Raw.PddToken; }
            set { Raw.PddToken = value; }
        }

        public YaToken AuthToken
        {
            get
            {
                return Raw.AuthToken;
            }
            set
            {
                Raw.AuthToken = value;
            }
        }

        public PddApi() : this( null, null ) { }

        public PddApi(string pddtoken, YaToken authtoken) {
            Raw = new PddRawApi();
            if (pddtoken != null ) PddToken = pddtoken;
            if ( authtoken != null ) AuthToken = authtoken;
        }

        public DomainContext Domain(string domain) => new DomainContext( this, domain );
    }

    public class DomainContext {
        private readonly PddApi _api;
        private readonly string _domain;

        internal DomainContext( PddApi api, string domain ) {
            _api = api;
            _domain = domain;
            Mail = new MailMethods( _api.Raw.Domain( _domain ).Mail );
            
        }

        public MailMethods Mail { get; }
    }
}