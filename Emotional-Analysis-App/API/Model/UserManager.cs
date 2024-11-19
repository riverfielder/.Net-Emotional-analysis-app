using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class UserManager
    {
        private readonly EmotionDbContext _dbContext;

        public UserManager(EmotionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User RegisterUser(string username, string password, string repeatpassword)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (existingUser != null) throw new Exception("User already exists");
            if (password != repeatpassword) throw new Exception("Wrong repeated password. Please try again.");

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password) // 实现一个哈希方法
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User LoginUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null || !VerifyPassword(password, user.PasswordHash)) // 实现一个密码验证方法
            {
                throw new Exception("Invalid username or password");
            }
            return user;
        }

        private string HashPassword(string password)
        {
            // 这里实现密码哈希逻辑
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password)); 
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            // 这里实现密码验证逻辑
            return HashPassword(password) == storedHash;
        }
    }
}
