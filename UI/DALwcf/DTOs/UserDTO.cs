using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DALwcf.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Papassword { get; set; }
        public int Status { get; set; }
        public BitmapImage Icon { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
        public virtual ICollection<RoomDTO> Rooms { get; set; }
    }
}
