

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

       

        
    }
}