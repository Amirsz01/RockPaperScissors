using System;
using System.Security.Cryptography;

namespace game
{
    public class HMACGenerator
    {
        public byte[] GetRandomBytes(int size)
        {
            var random = RandomNumberGenerator.Create();
            Byte []data = new byte[size];
            random.GetBytes(data);
            return data;
        }
        public byte[] GetKey()
        {
            return this.GetRandomBytes(16);
        }
        public void GetHMAC(byte[] key, byte[] message)
        {
            byte[] hashmessage = new HMACSHA256(key).ComputeHash(message);
            Console.WriteLine("HMAC: {0}", Convert.ToHexString(hashmessage));
        }
    }
}