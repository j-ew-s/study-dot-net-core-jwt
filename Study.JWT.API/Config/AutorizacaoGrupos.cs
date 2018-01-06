using Microsoft.AspNetCore.Authorization;

namespace Study.JWT.API.Config
{
    public class AutorizacaoGrupos : AuthorizeAttribute
    {
        public AutorizacaoGrupos(params string[] grupos)
        {
            Roles = string.Join(",", grupos);
        }
    }
}
