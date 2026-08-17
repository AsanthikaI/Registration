using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    internal class User
    {
        public string FullName { get; }
        public string Email { get; }
        public string Password { get; } // plain text only for teaching purposes


        public User(string fullName, string email, string password)
        {
            FullName = fullName?.Trim();
            Email = email?.Trim();
            Password = password;
        }

        /*
      Append this user's details to a CSV like text file.
      Returns false if validation fails; throws on I/O errors.
      */
        public bool Register(string filePath)
        {
            // minimal validation
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password))
                
                return false;

            // ensure folder exists
            var dir = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // write the line using StreamWriter (append mode)
            using (var sw = new StreamWriter(filePath, append: true))
            {
                string line = $"{FullName},{Email},{Password}";
                sw.WriteLine(line);
            }

            return true;
        }


        
    }
}