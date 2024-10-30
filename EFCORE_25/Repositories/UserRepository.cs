using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCORE_25.Data;
using EFCORE_25.Repositories;


namespace EFCORE_25.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EFCORE_25.Data.AppContext _context;

        public UserRepository(EFCORE_25.Data.AppContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUserName(int id, string newName)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.Name = newName;
                _context.SaveChanges();
            }
        }
    }
}