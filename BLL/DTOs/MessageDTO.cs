using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MessageDTO
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public RoomDTO RoomDTO { get; set; }
        public  UserDTO Sender { get; set; }
        public DateTime SendTime { get; set; }
    }
}
