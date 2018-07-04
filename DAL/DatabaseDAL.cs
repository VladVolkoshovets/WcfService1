using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseDAL : IDAL
    {
        private readonly DbContext _ctx;
        public DatabaseDAL(DbContext dbContext)
        {
            _ctx = dbContext;
        }

        public void SomeWork()
        {
            _ctx.Set<Message>().First();
        }
        public List<User> GetUsers()
        {
            return _ctx.Set<User>().ToList();
        }
        public User Autorisation(string UserName, string Password)
        {
            User user = _ctx.Set<User>().FirstOrDefault(u => u.UserName == UserName && u.Papassword == Password); 
            return user;
        }
        public bool AddUser(User user)
        {
           
            if (_ctx.Set<User>().FirstOrDefault(u => u.UserName.Equals(user.UserName)) != null)
            {
                return false;
            }
            else
            {
                _ctx.Set<User>().Add(user);
                _ctx.SaveChanges();
                return true;
            }
          
        }
        public void SendMesage(Message message)
        {
            message.Room = _ctx.Set<Room>().FirstOrDefault(r => r.Id == message.Room.Id);
            message.Sender = _ctx.Set<User>().FirstOrDefault(u => u.Id == message.Sender.Id);
            _ctx.Set<Message>().Add(message);
            _ctx.SaveChanges();
        }
    }
}
