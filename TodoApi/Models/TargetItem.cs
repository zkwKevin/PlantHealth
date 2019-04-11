using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoApi.CustomValidations;
using static TodoApi.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TodoApi.Models
{
    public class TargetItem
    {
        public int Id { get; set;}
        
        [JsonConverter(typeof(StringEnumConverter))]  
        [Required]
        public Kind? Type { get; set;}

        [NameValidation]
        public string Name { get; set;}
        public int HealthState { get; set;}
        public List<TodoLog> Logs{ get; set;}
        public int UserId {get; set;}
        public User User {get; set;}
    }
}