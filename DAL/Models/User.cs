using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Papassword { get; set; }
        public int Status { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}
