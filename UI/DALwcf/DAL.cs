using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALwcf.ServiceReference1;
namespace DALwcf
{
    public class DAL
    {
        private readonly Service1Client _service = new Service1Client();
        public void SomeWork()
        {
            _service.SomeWork();
        }
    }
}
