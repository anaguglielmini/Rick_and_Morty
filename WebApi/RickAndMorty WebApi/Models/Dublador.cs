using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMorty_WebApi.Models
{
        public class Dublador
        {
            public Dublador()
            {
            }
            public Dublador(int id, string pesonagem, string nome, string temporada)
            {
                Id_dub = id;
                Personagem_dub = pesonagem;
                Nome_dub = nome;
                Temporada_dub = temporada;
            }

            public int Id_dub { get; set; }
            public string Personagem_dub { get; set; }
            public string Nome_dub { get; set; }
            public string Temporada_dub { get; set; }
        }
    }