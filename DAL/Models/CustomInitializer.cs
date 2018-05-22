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
            User milky = new User
            {
                UserName = "Milky",
                Papassword = "niga",
            };
            User deShawn = new User
            {
                UserName = "DeShawn",
                Papassword = "niga",
            };

            List<User> users = new List<User>() { vlad, dima, stas, tolik, milky, deShawn };
            Room generalRoom = new Room()
            {
                Name = "General",
                IsPrivate = false,
                Users = users
            };
            Room testRoom = new Room()
            {
                Name = "TestRoom",
                IsPrivate = false,
                Users = new List<User> { vlad, tolik, dima, milky }
            };
            Room testDialog = new Room()
            {
                Name = "testDialog",
                IsPrivate = false,
                Users = new List<User> { deShawn, milky }
            };
            Message message = new Message()
            {
                Sender = vlad,
                Text = "Hello World",
                SendTime = DateTime.Today,
                room = generalRoom
            };
            Message message1 = new Message()
            {
                Sender = stas,
                Text = "Ok!",
                SendTime = DateTime.Today,
                room = generalRoom
            };
            Message message2 = new Message()
            {
                Sender = vlad,
                Text = "Hello guys!!",
                SendTime = DateTime.Today,
                room = testRoom
            };
            Message message3 = new Message()
            {
                Sender = stas,
                Text = "Hi man!",
                SendTime = DateTime.Today,
                room = testRoom
            };
            Message message4 = new Message()
            {
                Sender = dima,
                Text = "How are u?",
                SendTime = DateTime.Today,
                room = testRoom
            };
            Message message5 = new Message()
            {
                Sender = tolik,
                Text = "Pretty good!!",
                SendTime = DateTime.Today,
                room = testRoom
            };
            Message message6 = new Message()
            {
                Sender = milky,
                Text = "I think i saw u diging apples..",
                SendTime = DateTime.Today,
                room = testDialog
            };
            Message message7 = new Message()
            {
                Sender = deShawn,
                Text = "Ye niga! It was tomorrow!",
                SendTime = DateTime.Today,
                room = testDialog
            };
            Message message8 = new Message()
            {
                Sender = milky,
                Text = "Ok! I'll be back yesterday",
                SendTime = DateTime.Today,
                room = testDialog
            };
            Message message9 = new Message()
            {
                Sender = milky,
                Text = "Test<",
                SendTime = DateTime.Today,
                room = generalRoom
            };
            List<Room> rooms = new List<Room>() { generalRoom, testDialog, testRoom };
            List<Message> messages = new List<Message> { message, message1, message2, message3, message4, message5, message6, message7};
            context.Users.AddRange(users);
            context.Rooms.AddRange(rooms);            
            context.Messages.AddRange(messages);
            context.SaveChanges();
            context.Messages.Add(message8);
            context.Messages.Add(message9);
            context.SaveChanges();
        }
    }
}
