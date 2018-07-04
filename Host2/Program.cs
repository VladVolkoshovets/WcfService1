using BLL;
using DAL;
using DAL.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfService1;

namespace Host2
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IService1>().To<Service1>();
            kernel.Bind<IDAL>().To<DatabaseDAL>();
            kernel.Bind<IBLL>().To<BLL.BLL>();
            kernel.Bind<DbContext>().To<MessengerModel>();
            using (ServiceHost host = new ServiceHost
                (typeof(WcfService1.Service1)))
            {
                host.Open();
                Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
