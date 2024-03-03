using Brooder.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Brooder.DataAccess
{
    public class UserDAO
    {
        private readonly ApplicationDbContext _context;

        public UserDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetUserByID(string userID)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userID);
        }

        // Remove GetUserByUsernameAndPassword and use Identity's SignInManager

        public async Task<bool> SaveUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
