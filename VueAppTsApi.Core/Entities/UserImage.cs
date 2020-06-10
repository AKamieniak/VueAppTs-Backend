using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Core.Entities
{
    public class UserImage : IJoin
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}