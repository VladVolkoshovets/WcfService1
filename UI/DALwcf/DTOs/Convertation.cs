using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALwcf.ServiceReference1;

namespace DALwcf.DTOs
{
    class Convertation
    {
        public static System.Windows.Media.Imaging.BitmapImage ConvertToImage(byte[] image)
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
        public static UserDTO ToUserDTO(User userDAL)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = userDAL.Id,
                UserName = userDAL.UserName,
                Icon = ConvertToImage(userDAL.Image)
            };
            return userDTO;
        }
        public static MessageDTO ToMessageDTO(Message messageDAL)
        {
            MessageDTO messageDTO = new MessageDTO()
            {
                ID = messageDAL.ID,
                Text = messageDAL.Text,
                SendTime = messageDAL.SendTime
            };
            return messageDTO;
        }
        public static ParticipantDTO ToParticipantDTO(Participant participantDAL)
        {
            ParticipantDTO participantDTO = new ParticipantDTO()
            {
                Id = participantDAL.Id,
            };
            return participantDTO;
        }
        public static RoomDTO ToRoomDTO(Room room)
        {
            RoomDTO roomDTO = new RoomDTO()
            {
                Id = room.Id,
                IsPrivate = room.IsPrivate,
                Name = room.Name
            };
            return roomDTO;
        }
        public static StatusDTO ToStatusDTO(Status status)
        {
            StatusDTO statusDTO = new StatusDTO()
            {
                Id = status.Id,
                IsAdmin = status.IsAdmin
            };
            return statusDTO;
        }
        public static User ToUserDAL(UserDTO userDTO)
        {
            User userDAL = new User
            { 
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Papassword = userDTO.Papassword
                //Image = userDTO.Image
            };
            return userDAL;
        }
        public static Message ToMessageDAL(MessageDTO messageDTO)
        {
            Message messageDAL = new Message()
            {
                ID = messageDTO.ID,
                Text = messageDTO.Text,
                SendTime = messageDTO.SendTime,
                Room = new Room()
                {
                    Id = messageDTO.RoomDTO.Id
                },
                Sender = new User()
                {
                    Id = messageDTO.Sender.Id
                }
                
            };
            return messageDAL;
        }

        public static Participant ToParticipantDAL(ParticipantDTO participantDTO)
        {
            Participant participantDAL = new Participant()
            {
                Id = participantDTO.Id,
            };
            return participantDAL;
        }
        public static Room ToRoomDAL(RoomDTO roomDTO)
        {
            Room roomDAL = new Room()
            {
                Id = roomDTO.Id,
                IsPrivate = roomDTO.IsPrivate,
                Name = roomDTO.Name
            };
            return roomDAL;
        }
        public static Status ToStatusDAL(StatusDTO statusDTO)
        {
            Status statusDAL = new Status()
            {
                Id = statusDTO.Id,
                IsAdmin = statusDTO.IsAdmin
            };
            return statusDAL;
        }
    }
}
