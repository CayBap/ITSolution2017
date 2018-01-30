using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManager.BUS
{
    public class RouterBUS
    {
        private AirLineEntities context = new AirLineEntities();
        public List<Route> getRouters()
        {
            return context.Routes.ToList();
        }
        public int getRouterID(int idTo,int idFrom)
        {
            Route router = context.Routes.Where(rout => rout.ArrivalAirportID == idTo && rout.DepartureAirportID == idFrom).FirstOrDefault();
            return router.ID;
        }
    }
}
