using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManager.BUS
{

    public class UserBUS
    {
        AirLineEntities context = new AirLineEntities();
        public User getUser(string Email)
        {
            User user = null;
            try
            {
                user = context.Users.Where(u => u.Email == Email ).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
        public List<User> getUsers(int IDOffice)
        {
            List<User> users = null;
            if (IDOffice == 0)
            {
                try
                {
                    users = context.Users.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    users = context.Users.Where(u => u.OfficeID == IDOffice).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return users;
        }
        public void addUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public int countUser()
        {
            int count = 0;
            count = context.Users.Count();
            return count;
        }
        public void editUser(User user, int id)
        {


            User userLast = context.Users.Find(id);
            userLast.LastName = user.LastName;
            userLast.FirstName = user.FirstName;
            userLast.Email = user.Email;
            userLast.OfficeID = user.OfficeID;
            userLast.RoleID = user.RoleID;
            // Console.Write(userLast);
            context.SaveChanges();
        }
        public void changeLog(int id)
        {
            User user = context.Users.Find(id);
            user.Active = !user.Active;
            context.SaveChanges();
        }
    }
}
