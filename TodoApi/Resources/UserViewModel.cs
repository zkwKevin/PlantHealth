using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TodoApi.Models.Enum;

namespace TodoApi.Models
{
    public class UserViewModel
    {
        public long Id { get; set;}
        public string Username { get; set;}
        public string Email {get; set;}
        public string Password { get; set; }
    }
}