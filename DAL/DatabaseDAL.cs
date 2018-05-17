using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseDAL
    { 
        private readonly MessengerModel _ctx = new MessengerModel();

        public void SomeWork()
        {
            _ctx.Messages.First();
        }
    }
}
