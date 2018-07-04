using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DataContracts
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public virtual ICollection<Participant> Participant { get; set; }
    }
}