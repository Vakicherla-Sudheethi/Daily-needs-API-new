using System;
using System.Collections.Generic;
using System.Linq;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;

namespace DailyNeeds1.Repo
{
    public class UserImpl : IRepo<UserDTO>
    {
        private readonly DailyNeedsDbContext _context;

        public UserImpl(DailyNeedsDbContext context)
        {
            _context = context;
        }

        public bool Add(UserDTO item)
        {
            try
            {
                User user = new User
                {
                    Username = item.Username,
                    Email = item.Email,
                    Password = item.Password,
                    RoleID = item.RoleID
                };

                _context.users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return false;
            }
        }

        public User ValidteUser(string Username, string password)
        {
            User user = _context.users.SingleOrDefault(u => u.Username == Username && u.Password == password);
            return user;
        }

        public bool Delete(int userId)
        {
            try
            {
                var user = _context.users.Find(userId);
                if (user != null)
                {
                    _context.users.Remove(user);
                    // _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<UserDTO> GetAll()
        {
            var users = _context.users
                .Select(u => new UserDTO
                {
                    UserID = u.UserID,
                    Username = u.Username,
                    Email = u.Email,
                    Password = u.Password,
                    RoleID = u.RoleID
                })
                .ToList();

            return users;
        }

        public bool Update(UserDTO item)
        {
            try
            {
                var user = _context.users.Find(item.UserID);
                if (user != null)
                {
                    user.Username = item.Username;
                    user.Email = item.Email;
                    user.Password = item.Password;
                    user.RoleID = item.RoleID;
                    // _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //added newly-----
        public UserDTO GetById(int userId)
        {
            var user = _context.users.Find(userId);

            if (user != null)
            {
                var userDTO = new UserDTO
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    RoleID = user.RoleID
                };

                return userDTO;
            }

            return null;
        }
    }
}
