

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class UserManager : IUserManager
    {
        private readonly TodoContext _context;
        public UserManager(TodoContext context)
        {
            _context = context;
        }

    //    public User Authenticate(string username, string password)
    //    {
    //        var user = _context.Users.SingleOrDefault(x => x.Name == username && x.Password == password);
           
    //        if (user == null)
    //           return null;

    //        return user;
    //    }

       public User Create(User user, string password)
       {
            if(string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("Password is required!");
            if(_context.Users.Any(x => x.Name == user.Name))
                throw new ApplicationException("Username \"" + user.Name + "\" is already taken");
            if(_context.Users.Any(x => x.Email == user.Email))
                throw new ApplicationException("Email \"" + user.Email + "\" is already taken");
            
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

        
    }
}