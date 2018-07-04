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

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class Service1 : IService1
    {
        private BLL.IBLL _bll;

        public Service1()
        {

        }
        public Service1(IBLL bLL)
        {
            _bll = bLL;
        }

        public void SomeWork()
        {
            _bll.SomeWork();
        }
            public User[] GetUsers()
            {
            //List<UserDTO> usersBLL = _bll.GetUsers();
            //List<User> usersBuff = new List<User>();
            //foreach (var item in usersBLL)
            //{
            //    User userDC = new User
            //    {
            //        Id = item.Id,
            //        UserName = item.UserName,
            //        Messages = item.Messages.Select(m => new Message
            //        {
            //            ID = m.ID,
            //            Text = m.Text,
            //            SendTime = m.SendTime,
            //        }).ToList(),
            //        Status = item.Status,
            //        Rooms = item.Rooms.Select(r => new Room
            //        {
            //            Id = r.Id,
            //            IsPrivate = r.IsPrivate,
            //            Name = r.Name
            //        }).ToList(),
            //        Image = item.Image
            //    };
            //    usersBuff.Add(userDC);
            //}
            //return usersBuff.ToArray();
            return null;
            }

        public void Autorisation(string UserName, string Password)
        {

            UserDTO userDTO = _bll.Autorisation(UserName, Password);

            User userDC = null;
            if (userDTO != null)
            {
                userDC = new User();
                userDC = DataContracts.Convertation.ToUserDC(userDTO);
                userDC.Participant = new List<Participant>();
                foreach (var item in userDTO.ParticipantDTO)
                {
                    userDC.Participant.Add(DataContracts.Convertation.ToParticipantDC(item));
                    userDC.Participant.Last().Room = DataContracts.Convertation.ToRoomDC(item.RoomDTO);
                    userDC.Participant.Last().Room.Messages = new List<Message>();
                    foreach (var item2 in item.RoomDTO.Messages)
                    {
                        userDC.Participant.Last().Room.Messages.Add(DataContracts.Convertation.ToMessageDC(item2));
                        userDC.Participant.Last().Room.Messages.Last().Sender = DataContracts.Convertation.ToUserDC(item2.Sender);
                        userDC.Participant.Last().Room.Messages.Last().Sender.Image = item2.Sender.Image;
                    }
                };
            }
            OperationContext.Current.GetCallbackChannel<IServiceCallback>().ReceiveUser(userDC);
        }
        public void SendMesage(Message message)
        {
            MessageDTO messageDTO = new MessageDTO();
            messageDTO = DataContracts.Convertation.ToMessageDTO(message);
            messageDTO.RoomDTO = new RoomDTO()
            {
                Id = message.Room.Id
            };
            messageDTO.Sender = new UserDTO()
            {
                Id = message.Sender.Id
            };
           
            _bll.SendMesage(messageDTO);
            OperationContext.Current.GetCallbackChannel<IServiceCallback>().ReceiveMessage(message);
        }
        public bool AddUser(User user)
        {
            return _bll.AddUser(DataContracts.Convertation.ToUserDTO(user));
        }
       // public User Autorisation(string UserName, string Password)
       // {
       //     UserDTO userDTO = _bll.Autorisation(UserName, Password);
       //     User userDC = null;
       //     if (userDTO != null)
       //     {
       //         userDC = new User
       //         {
       //             UserName = userDTO.UserName,
       //             Id = userDTO.Id,
       //             Status = userDTO.Status,
       //             Rooms = userDTO.Rooms.Select(r => new Room
       //             {
       //                 Id = r.Id,
       //                 IsPrivate = r.IsPrivate,
       //                 Name = r.Name,
       //                 Messages = r.Messages.Select(m => new Message
       //                 {
       //                     ID = m.ID,
       //                     Text = m.Text,
       //                     SendTime = m.SendTime,
       //                     Sender = new User
       //                     {
       //                         Id = m.Sender.Id,
       //                         Image = m.Sender.Image,
       //                         UserName = m.Sender.UserName
       //                     },
       //                 }).ToList(),
       //             }).ToList(),
       //             Image = userDTO.Image
       //             
       //         };
       //     }
       //     return userDC;
       // }
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
    //public class Service2 : IService2
    //{
    //    private BLL.BLL _bll = new BLL.BLL();
    //
    //    public void SendMesage(Message message)
    //    {
    //        MessageDTO messageDTO = new MessageDTO();
    //        messageDTO = DataContracts.Convertation.ToMessageDTO(message);
    //        messageDTO.RoomDTO = new RoomDTO()
    //        {
    //            Id = message.Room.Id
    //        };
    //        messageDTO.Sender = new UserDTO()
    //        {
    //            Id = message.Sender.Id
    //        };
    //
    //        _bll.SendMesage(messageDTO);
    //        OperationContext.Current.GetCallbackChannel<IServiceCallback>().Receive(message);
    //    }
    //}
}
