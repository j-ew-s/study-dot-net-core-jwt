using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Study.JWT.API.Config
{
    public class ChaveConfiguracao
    {
        public SecurityKey Key { get; set; }
        public SigningCredentials SigningCredentials { get; set; }

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
