using Study.JWT.API.Entidades;

namespace Study.JWT.API.Config
{
    public interface IAutenticacao
    {
        ObjetoResposta ConstroiJwt(Usuario usuario);
    }
}
