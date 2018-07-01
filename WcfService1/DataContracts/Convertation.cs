using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DataContracts
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
        public static User ToUserDC(UserDTO userDTO)
        {
            User userDC = new User
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Image = userDTO.Image
            };
            return userDC;
        }
        public static Message ToMessageDC(MessageDTO messageDTO)
        {
            Message messageDC = new Message()
            {
                ID = messageDTO.ID,
                Text = messageDTO.Text,
                SendTime = messageDTO.SendTime
            };
            return messageDC;
        }
        public static Participant ToParticipantDC(ParticipantDTO participantDTO)
        {
            Participant participantDC = new Participant()
            {
                Id = participantDTO.Id,
            };
            return participantDC;
        }
        public static Room ToRoomDC(RoomDTO roomDTO)
        {
            Room roomDC = new Room()
            {
                Id = roomDTO.Id,
                IsPrivate = roomDTO.IsPrivate,
                Name = roomDTO.Name
            };
            return roomDC;
        }
        public static Status ToStatusDC(StatusDTO statusDTO)
        {
            Status statusDC = new Status()
            {
                Id = statusDTO.Id,
                IsAdmin = statusDTO.IsAdmin
            };
            return statusDC;
        }


    }
}