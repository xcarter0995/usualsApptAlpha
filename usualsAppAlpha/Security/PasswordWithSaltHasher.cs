using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsualsAppAlpha.DBClasses;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Security.Cryptography;

namespace UsualsAppAlpha.Security
{
    class PasswordWithSaltHasher
    {
        public userPasswordHashSalt userPasswordHashSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            RandomNumberGenerator rng = new RandomNumberGenerator();
            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordSaltBytes = new List<byte>();
            passwordSaltBytes.AddRange(passwordAsBytes);
            passwordSaltBytes.AddRange(saltBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordSaltBytes.ToArray());
            return new userPasswordHashSalt(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes), "");

        }
    }
}