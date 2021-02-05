namespace InformationSystemServer.Services.Helpers
{
    public class TokenConfiguration
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Expires { get; set; }
    }
}
