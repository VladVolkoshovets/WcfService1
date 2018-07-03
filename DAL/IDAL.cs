using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDAL
    {
        void SomeWork();
        List<User> GetUsers();
        User Autorisation(string UserName, string Password);
        bool AddUser(User user);
        void SendMesage(Message message);
    }
}
