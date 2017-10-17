using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Cotacao.Model
{
    public class Assinatura
    {
        public SecurityKey Chave { get; }
        public SigningCredentials CredenciasDaAssinatura { get; }

        public Assinatura()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Chave = new RsaSecurityKey(provider.ExportParameters(true));
            }

            CredenciasDaAssinatura = new SigningCredentials(
                Chave, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}