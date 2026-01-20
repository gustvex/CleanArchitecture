namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set;}
        public string Useremail {get; private set;}

        protected User () {}

        public User (string username, string useremail)
        {
            Id = Guid.NewGuid().GetHashCode();
            Username = username;
            Useremail = useremail;

        }

    }
}