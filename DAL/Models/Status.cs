using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Status
    {
        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Participant> Participant { get; set; }

    }
}
