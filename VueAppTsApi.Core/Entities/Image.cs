using System.Collections.Generic;

namespace VueAppTsApi.Core.Entities
{
    public class Image : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }

        public virtual ICollection<UserImage> UserImages { get; protected set; }
    }
}