using DAO;
using DTO;

namespace BUS
{
    public class UserBUS
    {
        public static LoggedUser CheckLogin(string username, string password)
        {
            return UserDAO.CheckLogin(username, password);
        }
    }
}