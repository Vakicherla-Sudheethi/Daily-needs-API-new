using System;
using System.Collections.Generic;
using System.Linq;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;

namespace DailyNeeds1.Repo
{
    public class LoginImpl : IRepo<LoginDTO>
    {
        private DailyNeedsDbContext context;

        public LoginImpl(DailyNeedsDbContext ctx)
        {
            context = ctx;
        }

        public bool Add(LoginDTO item)
        {
            try
            {
                Login login = new Login
                {
                    Username = item.Username,
                    Password = item.Password,
                    UserID = item.UserID,
                    // Other relevant fields for Login
                };

                context.logins.Add(login);
                //context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception/log if necessary
                return false;
            }
        }

        public bool Delete(int loginId)
        {
            try
            {
                var login = context.logins.Find(loginId);
                if (login != null)
                {
                    context.logins.Remove(login);
                    //context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle exception/log if necessary
                return false;
            }
        }

        public List<LoginDTO> GetAll()
        {
            var logins = context.logins
                .Select(l => new LoginDTO
                {
                    LoginId = l.LoginId,
                    Username = l.Username,
                    Password = l.Password,
                    UserID = l.UserID,
                    // Other mapped fields
                })
                .ToList();

            return logins;
        }

        public bool Update(LoginDTO item)
        {
            try
            {
                var login = context.logins.Find(item.LoginId);
                if (login != null)
                {
                    login.Username = item.Username;
                    login.Password = item.Password;
                    login.UserID = item.UserID;
                    // Update other relevant fields
                    //context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }
    }
}
