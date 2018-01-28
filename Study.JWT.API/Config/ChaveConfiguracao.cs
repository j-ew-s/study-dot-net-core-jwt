using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Study.JWT.API.Config
{
    public interface IChaveConfiguracao
    {
        SecurityKey Key { get; }
        SigningCredentials SigningCredentials { get; }
    }

    public class ChaveConfiguracao : IChaveConfiguracao
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public ChaveConfiguracao()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }

    }
}
