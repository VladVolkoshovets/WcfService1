﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseDAL : IDAL
    { 
        private readonly MessengerModel _ctx = new MessengerModel();

        public void SomeWork()
        {
            _ctx.Messages.First();
        }
        public List<User> GetUsers()
        {
            return _ctx.Users.ToList();
        }
        public User Autorisation(string UserName, string Password)
        {
            User user = _ctx.Users.FirstOrDefault(u => u.UserName == UserName && u.Papassword == Password); 
            return user;
        }
        public bool AddUser(User user)
        {
           
            if (_ctx.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName)) != null)
            {
                return false;
            }
            else
            {
                _ctx.Users.Add(user);
                _ctx.SaveChanges();
                return true;
            }
          
        }
        public void SendMesage(Message message)
        {
            message.Room = _ctx.Rooms.FirstOrDefault(r => r.Id == message.Room.Id);
            message.Sender = _ctx.Users.FirstOrDefault(u => u.Id == message.Sender.Id);
            _ctx.Messages.Add(message);
            _ctx.SaveChanges();
        }
    }
}
