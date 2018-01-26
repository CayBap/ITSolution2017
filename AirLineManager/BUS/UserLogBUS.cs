using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AirLineManager.BUS
{
    public class UserLogBUS
    {
        AirLineEntities context = new AirLineEntities();
        public List<Log> getLogs(User user)
        {
             List<Log> logs = null;
              logs = context.Logs.Where(u=> u.IDUser == user.ID).ToList();
             return logs;
        }
        public void setLogUser(Log log)
        {
            
            context.Logs.Add(log);
            context.SaveChanges();
        }
        public int countLogAll()
        {
            return context.Logs.Count();
        }
        public List<Log> getUserLog(User user)
        {
            List<Log> log = context.Logs.Where(l => l.IDUser == user.ID).ToList();
            return log;
        }
        public void updateLog(Log log)
        {
            Log logLast = context.Logs.Find(log.ID);
            logLast.ID = log.ID;
            logLast.IDUser = log.IDUser;
            logLast.LoginTime = log.LoginTime;
            logLast.LogOutTime = log.LogOutTime;
            context.SaveChanges();
        }
    }
}
