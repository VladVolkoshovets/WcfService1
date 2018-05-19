using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALwcf.DTOs;
using DALwcf.ServiceReference1;
namespace DALwcf
{
    public class DAL
    {
        private readonly Service1Client _service = new Service1Client();
        public List<UserDTO> GetUsers()
        {
            var UsersWCF = _service.GetUsers().ToList();
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var item in UsersWCF)
            {
                UserDTO userDTO = new UserDTO
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Papassword = item.Papassword,
                    Messages = item.Messages.Select(m => new MessageDTO
                    {
                        ID = m.ID,
                        Text = m.Text,
                        SendTime = m.SendTime,
                    }).ToList(),
                    Status = item.Status,
                    Rooms = item.Rooms.Select(r => new RoomDTO
                    {
                        Id = r.Id,
                        IsPrivate = r.IsPrivate,
                        Name = r.Name
                    }).ToList()
                };
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
    }
}
