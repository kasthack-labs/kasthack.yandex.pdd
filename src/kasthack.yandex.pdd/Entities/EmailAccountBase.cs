using System;

namespace kasthack.yandex.pdd.Entities
{
    public class EmailAccountBase : EmailAccountId
    {
        public EmailAccountBase() { }

        public EmailAccountBase(
            long? uid = null,
            string login = null,
            string password = null,
            string iname = null,
            string fname = null,
            bool? enabled = null,
            Sex? sex = null,
            string hintq = null,
            string hinta = null,
            DateTime? birthDate = null)
        {
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
}