using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirLineManager.BUS;
namespace AirLineManager.BUS
{
    public class ScheduleBUS
    {
        AirLineEntities context = new AirLineEntities();
        public List<Schedule> getSchedules()
        {
            return context.Schedules.ToList();
        }
        public void setComfirm(int id)
        {
            Schedule schedule =  context.Schedules.Find(id);
            schedule.Confirmed = !schedule.Confirmed;
           
            context.SaveChanges();
        }
        public Schedule getSchedule(int id)
        {
            Schedule schedule = context.Schedules.Find(id);
            return schedule;
        }
    }
}
