﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
    }
}
