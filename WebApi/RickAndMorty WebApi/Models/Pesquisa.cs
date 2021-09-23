using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty_WebApi.Models
{
    public class Pesquisa
    {
        public Pesquisa()
        {
        }
        public Pesquisa(int id,string nome, string tipo, int data)
        {
            Id_pesquisa = id;
            Nome_item = nome;
            Tipo_item = tipo;
            DtUltimoAcesso = data;
        }
        public int Id_pesquisa { get; set; }
        public string Nome_item { get; set; }
        public string Tipo_item { get; set; }
        public int DtUltimoAcesso { get; set; }
    }
}

