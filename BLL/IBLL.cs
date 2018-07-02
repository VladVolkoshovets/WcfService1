using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IBLL
    {
        void SomeWork();
        byte[] DefoultIcon();
        UserDTO Autorisation(string UserName, string Password);
    }
}
