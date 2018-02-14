using System;
using Microsoft.AspNetCore.Mvc;
using Study.JWT.API.Config;
using Study.JWT.API.Entidades;

namespace Study.JWT.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IAutenticacao _autenticacao;

        public UsuarioController(IAutenticacao autenticacao)
        {
            _autenticacao = autenticacao ?? throw new ArgumentNullException(nameof(autenticacao));
        }

        // GET: api/Usuario
        [HttpGet("Administrador")]
        public ObjetoResposta GetAdmin()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Gabriel",
                Email = "email1@outlook.com",
                Grupo = "Administrador",
                Senha = "123"
            };

            
            return _autenticacao.ConstroiJwt(usuario);
        }

        // GET: api/Usuario
        [HttpGet("RH")]
        public ObjetoResposta GetRh()
        {
            var usuario = new Usuario
            {
                Id = 2,
                Nome = "Gabriel 2",
                Email = "email2@outlook.com",
                Grupo = "RH",
                Senha = "123"
            };

            return _autenticacao.ConstroiJwt(usuario);

        }

        // GET: api/Usuario
        [HttpGet("Desenvolvedor")]
        public ObjetoResposta GetDev()
        {
            var usuario = new Usuario
            {
                Id = 3,
                Nome = "Gabriel 3",
                Email = "email3@new.com",
                Grupo = "Desenvolvedor",
                Senha = "123"
            };

            return _autenticacao.ConstroiJwt(usuario);

        }

        // GET: api/Usuario/5
        [HttpGet("{id:int}", Name = "Get")]
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
