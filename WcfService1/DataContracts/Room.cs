using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DataContracts
{
    public class Room
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}