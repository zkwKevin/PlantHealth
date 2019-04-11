using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static TodoApi.Models.Enum;

namespace TodoApi.Models
{
    public class User
    {
        public int Id { get; set;}
        public string Name { get; set;}
        
        [JsonConverter(typeof(StringEnumConverter))] 
        public Gender Gender { get; set;}
        public string Birth { get; set;}
        public string Email {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<TargetItem> TargetItems{ get; set;}
    }
}