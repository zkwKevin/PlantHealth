

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using WebApi.Helpers;

namespace TodoApi.Service
{
    public class UserManager : IUserManager
    {
        private readonly TodoContext _context;
        public UserManager(TodoContext context)
        {
            _context = context;
        }

       public User Authenticate(string username, string password)
       {

           if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
            
       }

       public User Create(User user, string password)
       {
        
            if(string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required!");
            if(_context.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username"  + user.Username + " is already taken");
            if(_context.Users.Any(x => x.Email == user.Email))
                throw new AppException("Email " + user.Email + " is already taken");
            
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
       }
       private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
       {
            if (password == null) 
                throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
       }

       private static bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PasswordSalt)
       {
           if(password == null)
                throw new ArgumentException("password");
            if(string.IsNullOrEmpty(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string","password");
            if(PasswordHash.Length != 64) 
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (PasswordSalt.Length != 128) 
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(PasswordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if(computedPasswordHash[i] != PasswordHash[i])
                        return false;
                }
            }        
            return true;
       }

       public User GetById(int id)
       {
            return _context.Users.Find(id);
       }

       public void EditProfile( User user){
           
            var oldUser = _context.Users.Find(user.Id);

            if (oldUser == null)
                throw new AppException("User not found");

            if(user.Username!=null)
            {
                if(oldUser.Username != user.Username)
                {
                    if(_context.Users.Any(x => x.Username == user.Username))
                    throw new AppException("Username \"" + user.Username + "\" is already taken");
                }
                oldUser.Username = user.Username;
            }
            
            if(user.Email!=null)
            {
                if(oldUser.Email != user.Email)
                {
                throw new AppException("Email \"" + user.Email + "\" is already taken");
                }
                oldUser.Email = user.Email;
            }  

            oldUser.Birth = user.Birth;
            oldUser.Gender = user.Gender;

            _context.Users.Update(oldUser);
            _context.SaveChanges();
           
       }

       public void UpdatePrivacy( User user, string password)
       {
           var oldUser = _context.Users.Find(user.Id);

           if (oldUser == null)
                throw new AppException("User not found");
            if(!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
                oldUser.PasswordHash = passwordHash;
                oldUser.PasswordSalt = passwordSalt;
            }
            _context.Users.Update(oldUser);
            _context.SaveChanges();
       }

        
    }
}