using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DataContracts
{
    [DataContract]
    public class Participant
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public virtual Room Room { get; set; }
        [DataMember]
        public virtual ICollection<User> Users { get; set; }
        [DataMember]
        public virtual Status Status { get; set; }
    }
}