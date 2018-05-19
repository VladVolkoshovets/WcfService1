using BLL.DTOs;
using DAL;
using DAL.Models;
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
        public List<UserDTO> GetUsers()
        {
            List<User> usersDAL = _dal.GetUsers();
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var item in usersDAL)
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
