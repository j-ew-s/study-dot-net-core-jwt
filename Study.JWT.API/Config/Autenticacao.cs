using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Study.JWT.API.Entidades;

namespace Study.JWT.API.Config
{
    public class Autenticacao : IAutenticacao
    {
        private readonly ITokenConfiguration _tokenConfiguration;
        private readonly IChaveConfiguracao _chaveConfiguracao;

        public Autenticacao(IChaveConfiguracao chaveConfiguracao,
            ITokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration ?? throw new ArgumentNullException(nameof(tokenConfiguration));
            _chaveConfiguracao = chaveConfiguracao ?? throw new ArgumentNullException(nameof(chaveConfiguracao));
        }

        public ObjetoResposta ConstroiJwt(Usuario usuario)
        {
            var dataCriacao = DateTime.UtcNow;
            var dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Grupo)
            };

            var token = new JwtSecurityToken(
                _tokenConfiguration.Issuer,
                _tokenConfiguration.Audience,
                claims,
                dataCriacao,
                dataExpiracao,
                _chaveConfiguracao.SigningCredentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ObjetoResposta
            {
                Usuario = usuario,
                Token = jwt
            };
        }
    }
}
