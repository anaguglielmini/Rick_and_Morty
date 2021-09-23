using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty_WebApi.Models
{
    public class User
    {
        public User()
        {
        }
        public User(int id, string nome, string email, string senha)
        {
            Id_user = id;
            Nome_user = nome;
            Email_user = email;
            Senha_user = senha;
        }

        public int Id_user { get; set; }
        public string Nome_user { get; set; }
        public string Email_user { get; set; }
        public string Senha_user { get; set; }
    }
}