using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineManager.BUS
{
    public class OfficeBUS
    {
        AirLineEntities context = new AirLineEntities();
        public List<Office> getOffices()
        {
            List<Office> offices = null;
            try
            {
                offices = context.Offices.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return offices;
        }
    }
}
