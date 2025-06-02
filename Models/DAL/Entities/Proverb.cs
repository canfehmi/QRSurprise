namespace QRSurprise.Models.DAL.Entities
{
    public class Proverb
    {
        public int Id { get; set; }
        public string FullProverb { get; set; } = string.Empty;
        public string WhoSay { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
