using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALwcf.DTOs
{
    public class ParticipantDTO
    {
        public int Id { get; set; }
        public virtual ICollection<RoomDTO> RoomsDTO { get; set; }
        public virtual ICollection<UserDTO> UserDTO { get; set; }
        public virtual StatusDTO StatusDTO { get; set; }
    }
}
