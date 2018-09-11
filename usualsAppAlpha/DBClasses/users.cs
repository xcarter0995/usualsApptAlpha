using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MongoDB.Bson;

namespace UsualsAppAlpha.DBClasses
{
    public class userPasswordHashSalt
    {
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Digest { get; set; }

        public userPasswordHashSalt(string salt, string hash, string digest)
        {
            Salt = salt;
            Hash = hash;
            Digest = digest;
        }

    }

    public class orders
    {
        public string OrderItem { get; set; } = string.Empty;
        public string[] OrderAddOns { get; set; }
        public decimal ItemPrice { get; set; }

    }

    public class userUsuals
    {
        public ObjectId Id { get; set; } = new ObjectId();
        public string OrderId { get; set; } = string.Empty;
        public string UsualName { get; set; } = string.Empty;
        public string CompanyID { get; set; } = string.Empty;
        public List<orders> userUsualOrders { get; set; } = new List<orders>();

    }


    public class users
    {
        public ObjectId Id { get; set; }
        public string UserEmail { get; set; }
        public userPasswordHashSalt UserPassword { get; set; }
        public string UserFirstName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;
        public DateTime UserDOB { get; set; } = DateTime.Now;
        public DateTime UserCreatedUtc { get; set; } = DateTime.UtcNow;
        public string UserPhoneNumber { get; set; } = string.Empty;
        public List<userUsuals> userUsuals { get; set; } = new List<userUsuals>();

    }
}