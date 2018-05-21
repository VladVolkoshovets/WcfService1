using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                    }).ToList(),
                    Image = item.Image
                    
                };
                if (userDTO.Image == null)
                {
                    ImageConverter _imageConverter = new ImageConverter();
                    Image image = Image.FromFile(@"D:\icon_user.png");


                    userDTO.Image = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));

                }
                userDTOs.Add(userDTO);
            }
            return userDTOs;
        }
        public UserDTO Autorisation(string UserName, string Password)
        {
            User userDAL = _dal.Autorisation(UserName, Password);
            UserDTO userDTO = null;
            if (userDAL != null)
            {
                userDTO = new UserDTO
                {
                    UserName = userDAL.UserName,
                    Id = userDAL.Id,
                    Messages = userDAL.Messages.Select(m => new MessageDTO
                    {
                        ID = m.ID,
                        Text = m.Text,
                        SendTime = m.SendTime,
                    }).ToList(),
                    Status = userDAL.Status,
                    Rooms = userDAL.Rooms.Select(r => new RoomDTO
                    {
                        Id = r.Id,
                        IsPrivate = r.IsPrivate,
                        Name = r.Name
                    }).ToList(),
                    
                    Image = userDAL.Image
                    
                };
                
            }
            if (userDTO.Image == null)
            {
                ImageConverter _imageConverter = new ImageConverter();
                Image image = Image.FromFile(@"D:\icon_user.png");
                

                userDTO.Image = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
                
            }
            return userDTO;
        }
    }
}
