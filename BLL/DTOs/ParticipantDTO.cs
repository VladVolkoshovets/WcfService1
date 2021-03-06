﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public virtual RoomDTO RoomDTO { get; set; }
        public virtual ICollection<UserDTO> UserDTO { get; set; }
        public virtual StatusDTO StatusDTO { get; set; }
    }
}
