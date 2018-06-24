using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALwcf.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<ParticipantDTO> ParticipantDTO { get; set; }
    }
}
