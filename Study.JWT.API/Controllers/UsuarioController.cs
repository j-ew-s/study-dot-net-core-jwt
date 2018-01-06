using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Study.JWT.API.Config;
using Study.JWT.API.Entidades;

namespace Study.JWT.API.Controllers
{

    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
            
        }
        // GET: api/Usuario
        [HttpGet("Administrador")]
        public ObjetoResposta GetAdmin([FromServices]ChaveConfiguracao chaveConfig,
            [FromServices]TokenConfiguracao tokenConfigurations)
        {
            var usuario = new Usuario()
            {
                Id = 1,
                Nome = "Gabriel",
                Email = "email1@outlook.com",
                Grupo = "Administrador",
                Senha = "123"
            };

            
            return new Autenticacao().ConstroiJwt(usuario, chaveConfig, tokenConfigurations);
        }

        // GET: api/Usuario
        [HttpGet("RH")]
        public ObjetoResposta GetRh([FromServices]ChaveConfiguracao chaveConfig,
            [FromServices]TokenConfiguracao tokenConfigurations)
        {
            var usuario = new Usuario()
            {
                Id = 2,
                Nome = "Gabriel 2",
                Email = "email2@outlook.com",
                Grupo = "RH",
                Senha = "123"
            };

            return new Autenticacao().ConstroiJwt(usuario, chaveConfig, tokenConfigurations);

        }

        // GET: api/Usuario
        [HttpGet("Desenvolvedor")]
        public ObjetoResposta GetDev([FromServices]ChaveConfiguracao chaveConfig,
            [FromServices]TokenConfiguracao tokenConfigurations)
        {
            var usuario = new Usuario()
            {
                Id = 3,
                Nome = "Gabriel 3",
                Email = "email3@new.com",
                Grupo = "Desenvolvedor",
                Senha = "123"
            };

            return new Autenticacao().ConstroiJwt(usuario, chaveConfig, tokenConfigurations);

        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Usuario
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
