using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DatabaseBLL
    {
        private readonly DatabaseDAL _dal = new DatabaseDAL();
        public void SomeWork()
        {
            _dal.SomeWork();
        }
    }
}
