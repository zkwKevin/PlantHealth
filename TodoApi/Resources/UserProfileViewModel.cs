using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TodoApi.Models.Enum;

namespace TodoApi.Models
{
    public class UserProfileViewModel
    {
        public long Id { get; set;}
        public string Username { get; set;}
        public string Email {get; set;}
        public string Birth { get; set;}
        public Gender Gender { get; set;}
    }
}