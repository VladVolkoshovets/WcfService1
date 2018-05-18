using DAL.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class WCFdal
    {
        private readonly Service1Client _sevice = new Service1Client();
        public void SomeWork()
        {
            _sevice.SomeWork();
        }
    }
}
