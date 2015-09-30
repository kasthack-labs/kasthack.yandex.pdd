using System;

namespace kasthack.yandex.pdd.Email {
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

    public class DeleteResponse : Response {
        public string Login { get; set; }
    }

    public class CountersResponse : Response {
        public Counters Counters { get; set; }
    }

    public class AccountId {
        public string Login { get; set; }
        public long? Uid { get; set; }

        public static implicit operator AccountId( string login ) => new AccountId { Login = login };
        public static implicit operator AccountId( long? uid ) => new AccountId { Uid = uid };
        public static implicit operator AccountId( long uid ) => new AccountId { Uid = uid };
        public override string ToString() => $"{Login} [UID={Uid}]";
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
            string hinta = null,
            DateTime? birthDate = null ) {
            Uid = uid;
            Login = login;
            Password = password;
            Iname = iname;
            Fname = fname;
            Enabled = enabled;
            Sex = sex;
            Hintq = hintq;
            Hinta = hinta;
            BirthDate = birthDate;
        }

        public string Password { get; set; }

        public string Iname { get; set; }

        public string Fname { get; set; }

        public bool? Enabled { get; set; }

        public Sex? Sex { get; set; }

        public string Hintq { get; set; }

        public string Hinta { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class Account : AccountBase {
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