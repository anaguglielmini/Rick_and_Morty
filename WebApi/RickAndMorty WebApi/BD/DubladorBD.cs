using MySql.Data.MySqlClient;
using RickAndMorty_WebApi.Models;
using System.Collections.Generic;
using System.Data;


namespace RickAndMorty_WebApi.BD
{
    public class DubladorBD
    {
        Connection cnt = new Connection();
        MySqlCommand cmd = new MySqlCommand();
              
        public Dublador ConsultarDublador(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Dublador where Id_dub = @Id_dub", cnt.ConectarBD());
            cmd.Parameters.Add("@Id_dub", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Dublador dub = new Dublador();

            while (reader.Read())
            {
                dub.Id_dub = reader.GetInt16(reader.GetOrdinal("Id_dub"));
                dub.Personagem_dub = reader.GetString(reader.GetOrdinal("Personagem_dub"));
                dub.Nome_dub = reader.GetString(reader.GetOrdinal("Nome_dub"));
                dub.Temporada_dub = reader.GetString(reader.GetOrdinal("Temporada_dub"));
            }

            reader.Close();

            cnt.DesconectarBD();

            return dub;
        }

        public List<Dublador> ListarDublador()
        {
            List<Dublador> Dublador = new List<Dublador>();

            MySqlCommand cmd = new MySqlCommand("Select * from Dublador", cnt.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dublador dub = new Dublador();

                dub.Id_dub = reader.GetInt16(reader.GetOrdinal("Id_dub"));
                dub.Personagem_dub = reader.GetString(reader.GetOrdinal("Personagem_dub"));
                dub.Nome_dub = reader.GetString(reader.GetOrdinal("Nome_dub"));
                dub.Temporada_dub = reader.GetString(reader.GetOrdinal("Temporada_dub"));
                Dublador.Add(dub);
            }

            return Dublador;
        }

    }
}