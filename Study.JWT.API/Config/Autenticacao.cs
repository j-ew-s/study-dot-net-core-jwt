using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Study.JWT.API.Entidades;

namespace Study.JWT.API.Config
{
    public class Autenticacao
    {
        public ObjetoResposta ConstroiJwt(Usuario usuario,
            [FromServices]ChaveConfiguracao chaveConfig,
            [FromServices]TokenConfiguracao tokenConfig)
        {

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfig.Seconds);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Grupo)
            };

            var token = new JwtSecurityToken(
                issuer: tokenConfig.Issuer,
                audience: tokenConfig.Audience,
                claims: claims,
                notBefore: dataCriacao,
                expires: dataExpiracao,
                signingCredentials: chaveConfig.SigningCredentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var result = new ObjetoResposta()
            {
                Usuario = usuario,
                Token = jwt
            };

            return result;

        }
    }
}
