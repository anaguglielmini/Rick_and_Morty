using Microsoft.AspNetCore.Mvc;
using RickAndMorty_WebApi.BD;
using RickAndMorty_WebApi.Models;
using System.Collections;

namespace RickAndMorty_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        // POST
        [HttpPost]
        public long AdicionarPesquisa([FromBody] Pesquisa value)
        {
            PesquisaBD pesqBD = new PesquisaBD();
            return pesqBD.AdicionarPesquisa(value);
        }

        // GET
        [HttpGet]
        public IEnumerable ListarPesquisa()
        {
            PesquisaBD pesqBD = new PesquisaBD();
            return pesqBD.ListarPesquisa();
        }

        // GET id
        [HttpGet("{id}")]
        public Pesquisa ConsultarPesquisa(int id)
        {
            PesquisaBD pesqBD = new PesquisaBD();
            return pesqBD.ConsultarPesquisa(id);
        }
    }
}
