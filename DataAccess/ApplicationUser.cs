using Microsoft.AspNetCore.Identity;

namespace Kotabko.DataAccess;

public class ApplicationUser : IdentityUser
{

    public string Image { get; set; }
    public string City { get; set; }
    public string governorate { get; set; }
}
