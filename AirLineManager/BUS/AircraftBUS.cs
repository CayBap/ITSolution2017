using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AirLineManager.BUS
{
    public class AircraftBUS
    {
        AirLineEntities context = new AirLineEntities();
        public Aircraft getAircraft(int id)
        {
            Aircraft aircraft = context.Aircrafts.Where(airc => airc.ID == id).FirstOrDefault();
            return aircraft;
        }
    }
}
