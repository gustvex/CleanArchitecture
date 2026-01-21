using System.Text.RegularExpressions;

namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set;}
        public string Useremail {get; private set;}
        public string Userphone {get; private set;}
        public string Cpf { get; private set; }

        protected User () {}

        public User (string username, string useremail, string userphone, string cpf)
        {
            Id = Guid.NewGuid().GetHashCode();
            Username = username;
            Userphone = CleanPhone(userphone);
            Useremail = useremail;
            Cpf = CleanCpf(cpf);
        }

        // Remove caracteres especiais do CPF (mantém apenas números)
        private static string CleanCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return string.Empty;
            
            return Regex.Replace(cpf, @"[^\d]", "");
        }

        // Remove caracteres especiais do telefone (mantém apenas números)
        private static string CleanPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;
            
            return Regex.Replace(phone, @"[^\d]", "");
        }

    }
}