using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCORE_25.Data;

namespace EFCORE_25.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void DeleteUser(int id);
        void UpdateUserName(int id, string newName);
    }
}
