using System.Collections.Generic;

namespace VueAppTsApi.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string DefaultLanguage { get; set; }

        public ICollection<ImageDTO> SavedImages { get; set; }
    }
}