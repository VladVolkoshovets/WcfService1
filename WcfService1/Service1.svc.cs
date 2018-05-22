using BLL;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.DataContracts;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private DatabaseBLL _bll = new DatabaseBLL();
        public void SomeWork()
        {
            _bll.SomeWork();
        }
        public User[] GetUsers()
        {
            List<UserDTO> usersBLL = _bll.GetUsers();
            List<User> usersBuff = new List<User>();
            foreach (var item in usersBLL)
            {
                User userDC = new User
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Messages = item.Messages.Select(m => new Message
                    {
                        ID = m.ID,
                        Text = m.Text,
                        SendTime = m.SendTime,
                    }).ToList(),
                    Status = item.Status,
                    Rooms = item.Rooms.Select(r => new Room
                    {
                        Id = r.Id,
                        IsPrivate = r.IsPrivate,
                        Name = r.Name
                    }).ToList(),
                    Image = item.Image
                };
                usersBuff.Add(userDC);
            }
            return usersBuff.ToArray();
        }
        public User Autorisation(string UserName, string Password)
        {
            UserDTO userDTO = _bll.Autorisation(UserName, Password);
            User userDC = null;
            if (userDTO != null)
            {
                userDC = new User
                {
                    UserName = userDTO.UserName,
                    Id = userDTO.Id,
                    Messages = userDTO.Messages.Select(m => new Message
                    {
                        ID = m.ID,
                        Text = m.Text,
                        SendTime = m.SendTime,
                    }).ToList(),
                    Status = userDTO.Status,
                    Rooms = userDTO.Rooms.Select(r => new Room
                    {
                        Id = r.Id,
                        IsPrivate = r.IsPrivate,
                        Name = r.Name,
                        Messages = r.Messages.Select(m => new Message
                        {
                            ID = m.ID,
                            Text = m.Text,
                            SendTime = m.SendTime,
                        }).ToList(),
                    }).ToList(),
                    Image = userDTO.Image
                    
                };
            }
            return userDC;
        }
        public string GetData(int value)
        {
            
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
