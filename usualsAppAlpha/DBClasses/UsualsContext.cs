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
using MongoDB.Driver;
using UsualsAppAlpha.Security;

namespace UsualsAppAlpha.DBClasses
{
    class UsualsContext
    {
        public const string CONNECTION_STRING_NAME = "";
        public const string DATABASENAME = "USUALSAPP";
        public const string USER_COLLECTION_NAME = "users";


        //PUT THESE IN IOC CONTANINERS LATER
        private static readonly IMongoClient _Client;
        private static readonly IMongoDatabase _database;
        private static users _loggedInUser;


        static UsualsContext()
        {
            var connectionString = CONNECTION_STRING_NAME;
            _Client = new MongoClient(connectionString);
            _database = _Client.GetDatabase(DATABASENAME);
        }

        public void LoginContext(string email, string password, string salt)
        {
            UsualsContext usualsContext = new UsualsContext();
            //set the users login information back to nothing AKA logout
            if (email == "" && password == "" & salt == "")
            {
                _loggedInUser = new users();
            }
            else
            {
                //login user
                string Hash = HashAfterSalt.ComputeSha256Hash(salt + password);
                _loggedInUser = usualsContext.Users.Find(x => x.UserEmail == email && x.UserPassword.Hash == Hash).SingleOrDefault();
            }
        }

        public IMongoClient Client
        {
            get { return _Client; }
        }

        public IMongoDatabase Database
        {
            get { return _database; }
        }

        public IMongoCollection<users> Users
        {
            get { return _database.GetCollection<users>(USER_COLLECTION_NAME); }
        }


        public users LoggedInUser
        {
            get { return _loggedInUser; }
        }



    }
}