using System;
using MySql.Data.MySqlClient;

namespace RickAndMorty_WebApi.BD
{
    public class Connection
    {
        MySqlConnection cnt = new MySqlConnection("Server= localhost;Database=RickAndMorty;user=root; pwd=PaodeF0rma");
        public static string msg;

        public MySqlConnection ConectarBD()
        {
            try
            {
                cnt.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cnt;
        }

        public void DesconectarBD()
        {
            try
            {
                cnt.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
        }

    }
}
