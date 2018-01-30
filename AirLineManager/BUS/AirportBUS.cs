using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManager.BUS
{
    public class AirportBUS
    {
        AirLineEntities context = new AirLineEntities();
        public List<Airport> getAirports()
        {
            return context.Airports.ToList();
        }
        public int getID(string IATACode)
        {
            Airport airport = context.Airports.Where(air => air.IATACode == IATACode).FirstOrDefault();
            return airport.ID;
        }
    }
}
