using Microsoft.AspNetCore.Identity;

namespace Blog.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string name, string displayName, string profilePicture)
        {
            Name = name;
            DisplayName = displayName;
            ProfilePicture = profilePicture;
        }

        public ApplicationUser()
        {
        }

        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
