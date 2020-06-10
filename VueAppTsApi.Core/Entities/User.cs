using System.Collections.Generic;
using System.Linq;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.Commands.User;
using VueAppTsApi.Core.Helpers;

namespace VueAppTsApi.Core.Entities
{
    public class User : EntityBase
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
        public string DefaultLanguage { get; private set; }

        public virtual ICollection<UserImage> SavedImages { get; protected set; }

        public User()
        {
            SavedImages = new List<UserImage>();
        }

        #region Methods

        public static User Build(CreateUserCommand command)
        {
            var entity = new User
                             {
                                 Username = command.Username,
                                 Email = command.Email,
                                 PasswordHash = PasswordHelper.HashPassword(command.Password),
                                 IsActive = true,
                                 DefaultLanguage = string.IsNullOrEmpty(command.DefaultLanguage) ? "en" : command.DefaultLanguage,
                             };

            return entity;
        }

        public void Update(UpdateUserCommand command)
        {
            if (!string.IsNullOrEmpty(command.Email))
            {
                Email = command.Email;
            }

            if (!string.IsNullOrEmpty(command.Username))
            {
                Username = command.Username;
            }
        }

        public void UpdateSettings(UpdateUserSettingsCommand command)
        {
            if (!string.IsNullOrEmpty(command.DefaultLanguage))
            {
                DefaultLanguage = command.DefaultLanguage;
            }
        }

        public void SaveImage(SaveImageCommand command)
        {
            var image = SavedImages.FirstOrDefault(x => x.ImageId.Equals(command.ImageId));

            if (image == null)
            {
                SavedImages.Add(new UserImage { ImageId = command.ImageId });
            }
            else
            {
                SavedImages.Remove(image);
            }
        }

        #endregion
    }
}