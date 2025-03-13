using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books_Management_System.Data
{
	public class AuthDbContext : IdentityDbContext<IdentityUser>
	{
        public AuthDbContext(DbContextOptions options) :base(options)
        {
            
        }
    }
}
