using MySql.Data.MySqlClient;
using RickAndMorty_WebApi.Models;
using System.Collections.Generic;
using System.Data;

namespace RickAndMorty_WebApi.BD
{
    public class UserBD
    {
        Connection cnt = new Connection();
        MySqlCommand cmd = new MySqlCommand();

        public long CadastrarUser(User user)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into User(nome_user, email_user, senha_user) Values ( @nomeUser, @emailUser, @senhaUser)", cnt.ConectarBD());
            cmd.Parameters.Add("@nomeUser", MySqlDbType.VarChar).Value = user.Nome_user;
            cmd.Parameters.Add("@emailUser", MySqlDbType.VarChar).Value = user.Email_user;
            cmd.Parameters.Add("@senhaUser", MySqlDbType.VarChar).Value = user.Senha_user;

            cmd.Parameters.Add("@idUser", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cnt.DesconectarBD();

            return id;
        }

        public User ConsultarUser(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM User where Id_user = @Id_user", cnt.ConectarBD());
            cmd.Parameters.Add("@Id_user", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            User user = new User();

            while (reader.Read())
            {
                user.Id_user = reader.GetInt16(reader.GetOrdinal("Id_user"));
                user.Nome_user = reader.GetString(reader.GetOrdinal("Nome_user"));
                user.Email_user = reader.GetString(reader.GetOrdinal("Email_user"));
                user.Senha_user = reader.GetString(reader.GetOrdinal("Senha_user"));
            }

            reader.Close();

            cnt.DesconectarBD();

            return user;
        }

        public List<User> ListarUser()
        {
            List<User> User = new List<User>();

            MySqlCommand cmd = new MySqlCommand("Select * from User", cnt.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();

                user.Id_user = reader.GetInt16(reader.GetOrdinal("Id_user"));
                user.Nome_user = reader.GetString(reader.GetOrdinal("Nome_user"));
                user.Email_user = reader.GetString(reader.GetOrdinal("Email_user"));
                user.Senha_user = reader.GetString(reader.GetOrdinal("Senha_user"));
                User.Add(user);
            }

            return User;
        }

    }
}