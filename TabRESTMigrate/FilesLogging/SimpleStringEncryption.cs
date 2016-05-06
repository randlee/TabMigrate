using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TabRESTMigrate.FilesLogging
{
    public class SimpleStringEncryption
    {
        private readonly Random _random;
        private readonly byte[] _key;
        private readonly RijndaelManaged _rijndael;
        private readonly UTF8Encoding _encoder;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleStringEncryption"/> class.
        /// Based on the System.Security.CryptographyRijndaelManaged algorithm
        /// Every string is encrypted w/ both a random key (which is encrypted within the result) and a key based on context.
        /// Context should be selected based on either user name, computer name, install key...
        /// Context must be the same to decrypt the encrypted data
        /// </summary>
        /// <param name="context">The context used for key generation. Context must be the same to decrypt the encrypted data</param>
        public SimpleStringEncryption(string context)
        {
            _random = new Random((int)DateTime.UtcNow.Ticks);
            _rijndael = new RijndaelManaged();
            _encoder = new UTF8Encoding();
            _key = new byte[32];
            if (string.IsNullOrEmpty(context))
            {   // if context is not specified, use application Guid instead
                var appGuid = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).Cast<GuidAttribute>().FirstOrDefault();
                context = appGuid?.Value.Remove('-') ?? "a21dbec0776443319944bcbed7cebfa6";
            }

            // Random base64 seed
            var base64Bytes = Convert.FromBase64String("MDY3QTIyMDIxNDI4NkYwMDAwMDYyQTMyN0UyODAwMDANCjBBMTQyODZGMDAwMDA2MkE4RTAyMkQwOTdFMjgwMDAwDQowQTEwMDAyQjEwMDMyQzBEMDM4RTJDMDkwMjAzMjgyRA0KMDAwMDBBMTAwMDAyNzNGRDAxMDAwNjdBMjIwMjE0MjgNCjcyMDAwMDA2MkEzMjdFExNDI4NzIwMDAwDQoNjJBOEUwMjJEMDk3RTI4MDAwMDBBMMEExMDgzCyMDAwMDAwMUIzMDA0MDANCjQ1MDAwMDAwMDEwMDAwMTExNDBBMDMyODQ2MDYwMDA2DQoyQzI0MDMyzZGQjYwMDAwMDYwNw0KMTQ2RjQ3MDYwMDA2MjZERTE5MEFERTE2MDcyQzA2EFEQzAwMDM2RkI2MDAwMDA2REUwMzBBDQpERTAwMDYwMjA0MDUyODEwMDAwMDYyQTAwMDAwMA0KMDEyODAwMDAwMDAwMTcwMDBBMjEwMDAzMUIwMDAwMDENCj");

            // offset number unique to context
            byte offset = (byte)(((context.Length + context[context.Length/2]) ^ 0x77) & 0x7F);
            // Scramble hard-coded seed w/ context
            var contextUnique = Xor(base64Bytes, _encoder.GetBytes(context));
            // Copy 256-bit key from context specific offset
            Array.Copy(contextUnique, offset, _key,0, 32);
        }

        public string Encrypt(string unencrypted)
        {
            var vector = new byte[16];
            _random.NextBytes(vector);
            var cryptogram = vector.Concat(Encrypt(_encoder.GetBytes(unencrypted), vector));
            return Convert.ToBase64String(cryptogram.ToArray());
        }

        public string Decrypt(string encrypted)
        {
            var cryptogram = Convert.FromBase64String(encrypted);
            if (cryptogram.Length < 17)
            {
                throw new ArgumentException("Invalid encrypted string", nameof(encrypted));
            }

            var vector = cryptogram.Take(16).ToArray();
            var buffer = cryptogram.Skip(16).ToArray();
            return _encoder.GetString(Decrypt(buffer, vector));
        }

        private byte[] Encrypt(byte[] buffer, byte[] vector)
        {
            var encryptor = _rijndael.CreateEncryptor(_key, vector);
            return Transform(buffer, encryptor);
        }

        private byte[] Decrypt(byte[] buffer, byte[] vector)
        {
            var decryptor = _rijndael.CreateDecryptor(_key, vector);
            return Transform(buffer, decryptor);
        }

        private byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }

        private byte[] Xor(byte[] buffer1, byte[] buffer2)
        {
            var len1 = buffer1.Length;
            var len2 = buffer2.Length;
            int len = Math.Max(len1, len2);
            var result = new byte[len];
            for(int i=0;i<len;i++)
            {
                result[i] = (byte)(buffer1[i%len1] ^ buffer2[i%len2]);
            }
            return result;
        }
    }
}