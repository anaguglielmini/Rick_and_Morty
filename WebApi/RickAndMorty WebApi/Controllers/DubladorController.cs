using Microsoft.AspNetCore.Mvc;
using RickAndMorty_WebApi.BD;
using RickAndMorty_WebApi.Models;
using System.Collections;

namespace RickAndMorty_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DubladorController : ControllerBase
    {
        // GET
        [HttpGet]
        public IEnumerable ListarUser()
        {
            DubladorBD dubBD = new DubladorBD();
            return dubBD.ListarDublador();
        }

        // GET id
        [HttpGet("{id}")]
        public Dublador ConsultarUser(int id)
        {
            DubladorBD dubBD = new DubladorBD();
            return dubBD.ConsultarDublador(id);
        }
    }
}