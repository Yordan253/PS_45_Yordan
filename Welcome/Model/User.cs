using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    internal class User
    {
        private string names;
        private string password;
        private UserRolesEnum role;
        private string facultyNumber;
        private string email;
       

        public User(String _names, String _password, UserRolesEnum _role, string facultyNumber, string email)
        {
            this.names = _names;
            this.password = _password;
            this.role = _role;
            this.facultyNumber = facultyNumber;
            this.email = email; 
        }

        public string Names { 
            get { return names; } 
            set { names = value; } 
        }
        private string encryptedPassword;

        public string Password
        {
            get
            {
                return DecryptPassword(encryptedPassword);
            }
            set
            {
                encryptedPassword = EncryptPassword(value);
            }
        }

        private string EncryptPassword(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("yourEncryptionKey123"); // Use a secure key
                aesAlg.IV = new byte[16]; // Use a secure IV

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] encryptedBytes = null;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        private string DecryptPassword(string encryptedPassword)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("yourEncryptionKey123"); // Use the same key as used for encryption
                aesAlg.IV = new byte[16]; // Use the same IV as used for encryption

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                string decryptedPassword = null;

                byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedPassword = srDecrypt.ReadToEnd();
                        }
                    }
                }
                return decryptedPassword;
            }
        }
        public UserRolesEnum Role {
            get { return role; }
            set {role = value; } 
        }
        public string FacultyNumber
        {
            get { return facultyNumber; }
            set { facultyNumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}



