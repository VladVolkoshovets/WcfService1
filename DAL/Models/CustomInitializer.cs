using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DAL.Models
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<MessengerModel>
    {
        protected override void Seed(MessengerModel context)
        {
            MemoryStream ms = new MemoryStream();
            User vlad = new User
            {
                UserName = "Vlad",
                Papassword = "10",
            };
            User dima = new User
            {
                UserName = "Dima",
                Papassword = "11",
            };
            User stas = new User
            {
                UserName = "Stas",
                Papassword = "11",
            };
            User tolik = new User
            {
                UserName = "Tolik",
                Papassword = "12",
            };
            Room generalRoom = new Room()
            {
                Name = "General",
                IsPrivate = false
            };
            Message message = new Message()
            {
                Sender = vlad,
                Text = "Hello World",
                SendTime = DateTime.Today,
                room = generalRoom
            };
            Message message2 = new Message()
            {
                Sender = stas,
                Text = "Ok!",
                SendTime = DateTime.Today,
                room = generalRoom
            };
            List<User> users = new List<User>() { vlad, dima, stas, tolik };
            context.Users.AddRange(users);
            context.Rooms.Add(generalRoom);
            context.Messages.Add(message);
            context.Messages.Add(message2);

            context.SaveChanges();
        }
    }
}
