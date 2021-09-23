using Microsoft.AspNetCore.Mvc;
using RickAndMorty_WebApi.BD;
using RickAndMorty_WebApi.Models;
using System.Collections;

namespace RickAndMorty_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        // POST
        [HttpPost]
        public long CriarUser([FromBody] User value)
        {
            UserBD userBD = new UserBD();
            return userBD.CadastrarUser(value);
        }

        // GET
        [HttpGet]
        public IEnumerable ListarUser()
        {
            UserBD userBD = new UserBD();
            return userBD.ListarUser();
        }

        // GET id
        [HttpGet("{id}")]
        public User ConsultarUser(int id)
        {
            UserBD userBD = new UserBD();
            return userBD.ConsultarUser(id);
        }
    }
}