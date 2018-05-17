using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<MessengerModel>
    {
        protected override void Seed(MessengerModel context)
        {
            Message message = new Message()
            {
                Sender = new User
                {
                    UserName = "Vlad",
                    Papassword = "12",
                },
                Text = "Hello World",
                
            };
            context.Messages.Add(message);

            context.SaveChanges();
        }
    }
}
