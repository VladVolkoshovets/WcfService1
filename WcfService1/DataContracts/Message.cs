using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DataContracts
{
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime SendTime { get; set; }
    }
}