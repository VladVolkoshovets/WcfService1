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
        public byte[] DefoultIcon()
        {
            ImageConverter _imageConverter = new ImageConverter();
            Image image = Image.FromFile(@"D:\icon_user.png");
            return (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
        }
        //public List<UserDTO> GetUsers()
        //{
        //
        //    List<User> usersDAL = _dal.GetUsers();
        //    List<UserDTO> userDTOs = new List<UserDTO>();
        //    
        //    foreach (var item in usersDAL)
        //    {
        //        UserDTO userDTO = new UserDTO
        //        {
        //            Id = item.Id,
        //            UserName = item.UserName,
        //            Papassword = item.Papassword,
        //            Messages = item.Messages.Select(m => new MessageDTO
        //            {
        //                ID = m.ID,
        //                Text = m.Text,
        //                SendTime = m.SendTime,
        //            }).ToList(),
        //            Status = item.Status,
        //            Rooms = item.Rooms.Select(r => new RoomDTO
        //            {
        //                Id = r.Id,
        //                IsPrivate = r.IsPrivate,
        //                Name = r.Name
        //            }).ToList(),
        //            Image = item.Image
        //            
        //        };
        //        if (userDTO.Image == null)
        //        {
        //            userDTO.Image = DefoultIcon();
        //        }
        //        userDTOs.Add(userDTO);
        //    }
        //    return userDTOs;
        //}
        //
        public UserDTO Autorisation(string UserName, string Password)
        {

            User userDAL = _dal.Autorisation(UserName, Password);
            UserDTO userDTO = null;
            if (userDAL != null)
            {
                
                
                userDTO = Convertation.ToUserDTO(userDAL);
                userDTO.ParticipantDTO = new List<ParticipantDTO>();
                foreach (var item in userDAL.Participant)
                {
                    userDTO.ParticipantDTO.Add(Convertation.ToParticipantDTO(item));
                    userDTO.ParticipantDTO.Last().RoomDTO = Convertation.ToRoomDTO(item.Room);
                    userDTO.ParticipantDTO.Last().RoomDTO.Messages = new List<MessageDTO>();
                    foreach (var item2 in item.Room.Messages)
                    {
                        userDTO.ParticipantDTO.Last().RoomDTO.Messages.Add(Convertation.ToMessageDTO(item2));
                        userDTO.ParticipantDTO.Last().RoomDTO.Messages.Last().Sender = Convertation.ToUserDTO(item2.Sender);
                        userDTO.ParticipantDTO.Last().RoomDTO.Messages.Last().Sender.Image = item2.Sender?.Image ?? DefoultIcon();
                    }
                };
                
                // Last
                //userDTO = new UserDTO
                //{
                //    UserName = userDAL.UserName,
                //    Id = userDAL.Id,
                //    ParticipantDTO = userDAL.Participant.Select(p => new ParticipantDTO
                //    {
                //        Id = p.Id,
                //        RoomDTO = new RoomDTO
                //        {
                //            Id = p.Room.Id,
                //            IsPrivate = p.Room.IsPrivate,
                //            Name = p.Room.Name,
                //            Messages = p.Room.Messages.Select(m => new MessageDTO
                //            {
                //                ID = m.ID,
                //                Text = m.Text,
                //                SendTime = m.SendTime,
                //            
                //                Sender = new UserDTO
                //                {
                //                    Id = m.Sender.Id,
                //                    Image = m.Sender?.Image ?? DefoultIcon(),
                //                    UserName = m.Sender.UserName
                //                }
                //            }).ToList()
                //
                //
                //        }
                //
                //    }).ToList(),
                //    Image = userDAL.Image
                //    
                //};
                if (userDTO.Image == null)
                {
                    userDTO.Image = DefoultIcon();
                }
            }
            
            return userDTO;
        }
    }
}
