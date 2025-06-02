namespace QRSurprise.Models.DAL.Entities
{
    public class Sound
    {
        public int Id { get; set; }
        public string SoundUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
