using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DALwcf.DTOs;
using DALwcf.ServiceReference1;


namespace DALwcf
{
    
    //[CallbackBehavior (UseSynchronizationContext = false)]
    public class DAL : IDAL, ServiceReference1.IServiceCallback
    {

        public static ObservableCollection<MessageDTO> Messages;
        
        public static int i = 1;
        public static UserDTO CourentUser { get; set; }
        private readonly InstanceContext instanceContext;
        private readonly ServiceClient _service;

        public DAL()
        {
            instanceContext = new InstanceContext(this);
            _service = new ServiceReference1.ServiceClient(instanceContext);
            Messages = new ObservableCollection<MessageDTO>();


        }

        //private readonly ServiceReference1.Service1Client _service = new ServiceReference1.Service1Client();

        public void FakeWork()
        {
            _service.SomeWork();

        }

        public void Autorisation(string UserName, string Password)
        {
            
            _service.Autorisation(UserName, Password);

        }
        public void SendMessage(MessageDTO messageDTO)
        {
            Message message = Convertation.ToMessageDAL(messageDTO);
            message.Sender = Convertation.ToUserDAL(messageDTO.Sender);
            _service.SendMesage(message);
        }
        public bool AddUser(UserDTO user)
        {
            return _service.AddUser(Convertation.ToUserDAL(user));
        }

        public void ReceiveMessage(Message message)
        {
            if (CourentUser.ParticipantDTO.Select(p => p.RoomDTO.Id == message.Room.Id).Any()) // переробить умову
            {

                i ++;
                MessageDTO messageDTO = Convertation.ToMessageDTO(message);
                messageDTO.Sender = Convertation.ToUserDTO(message.Sender);
                Messages.Add(messageDTO);
                //Messages.RemoveAt(0);
            }
            else i = 50;
        }

        public void ReceiveUser(User userDAL)
        {
            if (userDAL != null)
            {    
                CourentUser = Convertation.ToUserDTO(userDAL);
                CourentUser.ParticipantDTO = new List<ParticipantDTO>();
                foreach (var item in userDAL.Participant)
                {
                    CourentUser.ParticipantDTO.Add(Convertation.ToParticipantDTO(item));
                    CourentUser.ParticipantDTO.Last().RoomDTO = Convertation.ToRoomDTO(item.Room);
                    CourentUser.ParticipantDTO.Last().RoomDTO.Messages = new List<MessageDTO>();
                    foreach (var item2 in item.Room.Messages)
                    {
                        CourentUser.ParticipantDTO.Last().RoomDTO.Messages.Add(Convertation.ToMessageDTO(item2));
                        CourentUser.ParticipantDTO.Last().RoomDTO.Messages.Last().Sender = Convertation.ToUserDTO(item2.Sender);
                    }
                };
            }
            else
            {
                CourentUser = null;
            }
        }

    }
}
