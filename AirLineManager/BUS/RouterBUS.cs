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
    }
}
