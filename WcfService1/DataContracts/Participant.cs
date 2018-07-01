using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DataContracts
{
    public class Participant
    {
        public int Id { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual Status Status { get; set; }
    }
}