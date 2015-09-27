using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.Email {
    //public class PddEmailApi {

    //}

    //public abstract class PddEmailRawApi {
    //    //private const string root = "https://pddimp.yandex.ru/api2/admin";
    //    //public abstract Task<string> Add( string login, string password );
    //    //public abstract Task<string> List( int? page = null, int? onPage = null );
    //    //public abstract Task<string> Edit( AccountBase account );
    //    //public abstract Task<string> Del( AccountId id );
    //    //public abstract Task<string> Counters( AccountId id );
    //}

    public enum Sex {
        Default = 0,
        Male = 1,
        Female = 2
    }

    public class AddResponse : Response {
        public string Login { get; set; }
        public long Uid { get; set; }
    }

    public class ListResponse : PageableResponse {
        public Account[] Accounts { get; set; }
    }

    public class EditResponse : Response {
        public AccountF Account { get; set; }
    }

    public class DelResponse : Response {
        public string Login { get; set; }
    }

    public class CountersResponse : Response {
        public Counters Counters { get; set; }
    }

    public class AccountId {
        public string Login { get; set; }
        public long? Uid { get; set; }

        public static implicit operator AccountId(string login) => new AccountId() { Login = login };
        public static implicit operator AccountId( long? uid ) => new AccountId() { Uid = uid };
        public static implicit operator AccountId( int? uid ) => new AccountId() { Uid = uid };
        public static implicit operator AccountId( int uid ) => new AccountId() { Uid = uid };
        public static implicit operator AccountId( long uid ) => new AccountId() { Uid = uid };
    }

    public class AccountBase : AccountId {
        public AccountBase() { }

        public AccountBase(
            long? uid = null,
            string login = null,
            string password = null,
            string iname = null,
            string fname = null,
            bool? enabled = null,
            Sex? sex = null,
            string hintq = null,
            string hinta = null ) {
            Uid = uid;
            Login = login;
            Password = password;
            Iname = iname;
            Fname = fname;
            Enabled = enabled;
            Sex = sex;
            Hintq = hintq;
            Hinta = hinta;
        }

        public string Password { get; set; }

        public string Iname { get; set; }

        public string Fname { get; set; }

        public bool? Enabled { get; set; }

        public Sex? Sex { get; set; }

        public string Hintq { get; set; }

        public string Hinta { get; set; }
    }

    public class Account : AccountBase {
        public DateTime BirthDate { get; set; }
        public bool Ready { get; set; }
        public bool MailList { get; set; }
        public string[] Aliases { get; set; }
    }

    public class AccountF : Account {
        public string Fio { get; set; }
    }

    public class Counters {
        public int Unread { get; set; }
        public int New { get; set; }
    }
}