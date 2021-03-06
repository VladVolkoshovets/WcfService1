﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Papassword { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
        public virtual ICollection<ParticipantDTO> ParticipantDTO { get; set; }
    }
}
