using Microsoft.AspNetCore.Identity;

namespace TSMS.Web.V1
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
