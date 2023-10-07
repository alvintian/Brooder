using CookAlongAcademy.DataAccess;
using CookAlongAcademy.Models;

namespace CookAlongAcademy.Services
{
    public class AuthenticationService
    {
        private UserDAO userDAO;

        public AuthenticationService()
        {
            this.userDAO = new UserDAO();
        }

        public User Authenticate(string username, string password)
        {
            // Implement authentication logic here
            return userDAO.GetUserByUsernameAndPassword(username, password);
        }

        public bool Register(User user)
        {
            // Implement user registration logic here
            return userDAO.SaveUser(user);
        }
    }

}
