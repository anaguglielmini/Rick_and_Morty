using MySql.Data.MySqlClient;
using RickAndMorty_WebApi.Models;
using System.Collections.Generic;
using System.Data;

namespace RickAndMorty_WebApi.BD
{
    public class PesquisaBD
    {
        Connection cnt = new Connection();
        MySqlCommand cmd = new MySqlCommand();

        public long AdicionarPesquisa(Pesquisa pesq)
        {
            MySqlCommand cmd = new MySqlCommand("Insert into Pesquisa(nome_item, tipo_item, dtUltimoAcesso) Values ( @nomeItem, @tipoItem, @dtUltimoAcesso)", cnt.ConectarBD());
            cmd.Parameters.Add("@nomeItem", MySqlDbType.VarChar).Value = pesq.Nome_item;
            cmd.Parameters.Add("@tipoItem", MySqlDbType.VarChar).Value = pesq.Tipo_item;
            cmd.Parameters.Add("@dtUltimoAcesso", MySqlDbType.VarChar).Value = pesq.DtUltimoAcesso;

            cmd.Parameters.Add("@idPesquisa", MySqlDbType.Int16, 4).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;

            cnt.DesconectarBD();

            return id;
        }

        public Pesquisa ConsultarPesquisa(int id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Pesquisa where Id_pesquisa = @Id_pesquisa", cnt.ConectarBD());
            cmd.Parameters.Add("@Id_pesquisa", MySqlDbType.Int16).Value = id;

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            Pesquisa pesq = new Pesquisa();

            while (reader.Read())
            {
                pesq.Id_pesquisa = reader.GetInt16(reader.GetOrdinal("Id_pesquisa"));
                pesq.Nome_item = reader.GetString(reader.GetOrdinal("Nome_item"));
                pesq.Tipo_item = reader.GetString(reader.GetOrdinal("Tipo_item"));
                pesq.DtUltimoAcesso = reader.GetInt16(reader.GetOrdinal("DtUltimoAcesso"));
            }

            reader.Close();

            cnt.DesconectarBD();

            return pesq;
        }

        public List<Pesquisa> ListarPesquisa()
        {
            List<Pesquisa> Pesq = new List<Pesquisa>();

            MySqlCommand cmd = new MySqlCommand("Select * from Pesquisa", cnt.ConectarBD());

            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pesquisa pesq = new Pesquisa();

                pesq.Id_pesquisa = reader.GetInt16(reader.GetOrdinal("Id_pesquisa"));
                pesq.Nome_item = reader.GetString(reader.GetOrdinal("Nome_item"));
                pesq.Tipo_item = reader.GetString(reader.GetOrdinal("Tipo_item"));
                pesq.DtUltimoAcesso = reader.GetInt16(reader.GetOrdinal("DtUltimoAcesso"));
                Pesq.Add(pesq);
            }

            return Pesq;
        }

    }
}
