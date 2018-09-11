using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UsualsAppAlpha.Security
{
    class RandomNumberGenerator
    {
        public string GenerateRandomCryKey(int KeyLength)
        {
            return Convert.ToBase64String(GenerateRandomCryptographicBytes(KeyLength));
        }

        public byte[] GenerateRandomCryptographicBytes(int KeyLength)
        {
            RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[KeyLength];
            rNGCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }

    }
}