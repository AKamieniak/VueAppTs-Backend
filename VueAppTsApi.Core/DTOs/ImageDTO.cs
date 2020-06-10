namespace VueAppTsApi.Core.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public bool IsSaved { get; set; }
    }
}