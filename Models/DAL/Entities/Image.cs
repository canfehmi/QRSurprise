namespace QRSurprise.Models.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
