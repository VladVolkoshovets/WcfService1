using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
    }
}
