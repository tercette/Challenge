namespace ChallengeAPI.Application.Models
{
    public class Jwt
    {
        public string Secret { get; set; }
        public int Expires { get; set; }
    }
}
