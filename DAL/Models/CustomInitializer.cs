using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace DAL.Models
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<MessengerModel>
    {
        private  Bitmap MakeSquarePhoto(Bitmap bmp)
        {
            int size;
            int t = 0, l = 0;
            if (bmp.Height > bmp.Width)
            {
                t = (bmp.Height - bmp.Width) / 2;
                size = bmp.Width;
            }
            else
            {
                l = (bmp.Width - bmp.Height) / 2;
                size = bmp.Height;
            }
            Bitmap res = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(res);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);

            g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
            return res;
            
            
        }
        byte[] GetBytesIcon(string path)
        {
            Bitmap bitmap = MakeSquarePhoto(new Bitmap(path));

            ImageConverter _imageConverter = new ImageConverter();

            return (byte[])_imageConverter.ConvertTo(bitmap, typeof(byte[]));
        }
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
                Image = GetBytesIcon(@"D:\NigasIcon2.jpg")
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
                Room = generalRoom
            };
            Message message1 = new Message()
            {
                Sender = stas,
                Text = "Ok!",
                SendTime = DateTime.Today,
                Room = generalRoom
            };
            Message message2 = new Message()
            {
                Sender = vlad,
                Text = "Hello guys!!",
                SendTime = DateTime.Today,
                Room = testRoom
            };
            Message message3 = new Message()
            {
                Sender = stas,
                Text = "Hi man!",
                SendTime = DateTime.Today,
                Room = testRoom
            };
            Message message4 = new Message()
            {
                Sender = dima,
                Text = "How are u?",
                SendTime = DateTime.Today,
                Room = testRoom
            };
            Message message5 = new Message()
            {
                Sender = tolik,
                Text = "Pretty good!!",
                SendTime = DateTime.Today,
                Room = testRoom
            };
            Message message6 = new Message()
            {
                Sender = milky,
                Text = "I think i saw u diging apples..",
                SendTime = DateTime.Today,
                Room = testDialog
            };
            Message message7 = new Message()
            {
                Sender = deShawn,
                Text = "Ye niga! It was tomorrow!",
                SendTime = DateTime.Today,
                Room = testDialog
            };
            Message message8 = new Message()
            {
                Sender = milky,
                Text = "Ok! I'll be back yesterday",
                SendTime = DateTime.Today,
                Room = testDialog
            };
            Message message9 = new Message()
            {
                Sender = milky,
                Text = "Test<",
                SendTime = DateTime.Today,
                Room = generalRoom
            };
            List<Room> rooms = new List<Room>() { generalRoom, testDialog, testRoom };
            List<Message> messages = new List<Message> { message, message1, message2, message3, message4, message5, message6, message7};
            context.Users.AddRange(users);
            context.Rooms.AddRange(rooms);            
            context.Messages.AddRange(messages);
            context.SaveChanges();
            context.SaveChanges();
            context.SaveChanges();
            context.SaveChanges();
            context.Messages.Add(message8);
            context.Messages.Add(message9);
            context.SaveChanges();
        }
    }
}
