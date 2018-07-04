using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DataContracts
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Papassword { get; set; }
        [DataMember]
        public byte[] Image { get; set; }
        [DataMember]
        public virtual ICollection<Message> Messages { get; set; }
        [DataMember]
        public virtual ICollection<Participant> Participant { get; set; }
    }
}