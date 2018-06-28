using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Convertation
    {
        public static UserDTO ToUserDTO(User userDAL)
        {
            UserDTO userDTO = new UserDTO
            {
                Id = userDAL.Id,
                UserName = userDAL.UserName,
                Image = userDAL.Image
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

        
    }
}
