﻿using System;
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
        public System.Windows.Media.Imaging.BitmapImage ConvertToImage(byte[] image)
        {
            System.Windows.Media.Imaging.BitmapImage GetImage = new System.Windows.Media.Imaging.BitmapImage();
            using (var ms = new System.IO.MemoryStream(image))
            {
                GetImage.BeginInit();
                GetImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                GetImage.StreamSource = ms;
                GetImage.EndInit();
            }

            return GetImage;
        }
        
        public void FakeWork()
        {
            _service.SomeWork();
        }

        //public List<UserDTO> GetUsers()
        //{
        //    var UsersWCF = _service.GetUsers().ToList();
        //    List<UserDTO> userDTOs = new List<UserDTO>();
        //    foreach (var item in UsersWCF)
        //    {
        //        UserDTO userDTO = new UserDTO
        //        {
        //            Id = item.Id,
        //            UserName = item.UserName,
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
        //            Icon = ConvertToImage(item.Image)
        //
        //        };
        //        userDTOs.Add(userDTO);
        //    }
        //
        //    return userDTOs;
        //}
        public UserDTO Autorisation(string UserName, string Password)
        {
            User userDAL = _service.Autorisation(UserName, Password);
            UserDTO userDTO = null;
            if (userDAL != null)
            {
                userDTO = new UserDTO
                {
                    UserName = userDAL.UserName,
                    Id = userDAL.Id,
                    ParticipantDTO = userDAL.Participant.Select(p => new ParticipantDTO
                    {
                        Id = p.Id,
                        RoomsDTO = new RoomDTO
                        {
                            Id = p.Rooms.Id,
                            IsPrivate = p.Rooms.IsPrivate,
                            Name = p.Rooms.Name,
                            Messages = p.Rooms.Messages.Select(m => new MessageDTO
                            {
                                ID = m.ID,
                                Text = m.Text,
                                SendTime = m.SendTime,

                                Sender = new UserDTO
                                {
                                    Id = m.Sender.Id,
                                    Icon = ConvertToImage(m.Sender.Image),
                                    UserName = m.Sender.UserName
                                }
                            }).ToList()


                        }
                                   


                    }).ToList(),
                    Icon = ConvertToImage(userDAL.Image)
                };

            }
            return userDTO;
        }
    }
}
