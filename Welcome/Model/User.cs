using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string names;
        public string password;
        public UserRolesEnum role;
        public string facultyNumber;
        public string email;
       

        public User(String _names, String _password, UserRolesEnum _role, String _facultyNumber, String _email)
        {
            this.names = _names;
            this.password = _password;
            this.role = _role;
            this.facultyNumber = _facultyNumber;
            this.email = _email; 
        }

        public string Names { 
            get { return names; } 
            set { names = value; } 
        }
        public string encryptedPassword;

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

        public string EncryptPassword(string password)
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

        public string DecryptPassword(string encryptedPassword)
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



