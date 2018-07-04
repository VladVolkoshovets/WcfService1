using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DataContracts
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public Room Room { get; set; }
        [DataMember]
        public virtual User Sender { get; set; }
        [DataMember]
        public DateTime SendTime { get; set; }
    }
}