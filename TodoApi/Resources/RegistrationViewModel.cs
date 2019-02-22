using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TodoApi.Models.Enum;

namespace TodoApi.Models
{
    public class RegistrationViewModel
    {
        public long Id { get; set;}
        public string Name { get; set;}
        public string Email {get; set;}
        public string Password { get; set; }
    }
}