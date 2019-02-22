using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface IUserManager
    {
        // User Authenticate(string username, string password);
        User Create(User user, string password);
    }
}