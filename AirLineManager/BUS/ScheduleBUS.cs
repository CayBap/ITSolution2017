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
        public void updateSchedule(Schedule schedule)
        {
            Schedule sch = context.Schedules.Find(schedule.ID);
            sch = schedule;
            context.SaveChanges();
        }
        public void EditSchedule(DateTime Date,TimeSpan Time,int flightNumber,int idAircraft,bool comfirm, int ecomnomyPrice)
        {
            Schedule schedule = context.Schedules.Where(sche => sche.Date == Date && sche.Time == Time && sche.FlightNumber == flightNumber.ToString() && sche.AircraftID == idAircraft&&sche.EconomyPrice==ecomnomyPrice).FirstOrDefault();
            schedule.Confirmed = comfirm;
            context.SaveChanges();
        }
        public void AddSchedule( DateTime Date, TimeSpan Time, int flightNumber, int idAircraft, bool comfirm, int ecomnomyPrice,int idRouter)
        {
            Schedule schedule = new Schedule()
            {
                Date = Date,
                Time = Time,
                FlightNumber = flightNumber.ToString(),
                AircraftID = idAircraft,
                Confirmed = comfirm,
                EconomyPrice = ecomnomyPrice,
                RouteID = idRouter
            };
            context.Schedules.Add(schedule);
            context.SaveChanges();
        }
        public Schedule getScheduleOneinAll(DateTime Date, TimeSpan Time, int flightNumber, int idAircraft, bool comfirm, int ecomnomyPrice, int idRouter)
        {
            Schedule schedule = context.Schedules.Where(sche => sche.Date == Date && sche.Time == Time && sche.FlightNumber == flightNumber.ToString() && sche.AircraftID == idAircraft && sche.EconomyPrice == ecomnomyPrice).FirstOrDefault();
            return schedule;
        }
    }
}
