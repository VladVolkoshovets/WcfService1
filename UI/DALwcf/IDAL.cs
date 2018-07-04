using DALwcf.DTOs;
using DALwcf.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALwcf
{
    interface IDAL
    {
        void FakeWork();
        void Autorisation(string UserName, string Password);
        bool AddUser(UserDTO user);
        void SendMessage(MessageDTO message);
    }
}
