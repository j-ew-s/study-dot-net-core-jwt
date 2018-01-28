namespace Study.JWT.API.Config
{
    public interface ITokenConfiguration
    {
        string Audience { get; }
        string Issuer { get; }
        int Seconds { get; }
    }

    public class TokenConfiguration : ITokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
