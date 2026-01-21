namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; private set;}
        public string Useremail {get; private set;}
        public string Userphone {get; private set;}

        protected User () {}

        public User (string username, string useremail, string userphone) : base()
        {
            Username = username;
            Userphone = userphone;
            Useremail = useremail;
        }

    }
}