using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoApi.CustomValidations;

namespace TodoApi.Models
{
    public class TargetItem
    {
        public long Id { get; set;}
        public enum Kind 
        { 
            Animal = 0, 
            Plant = 1
        }

        [Required]
        public Kind? Type { get; set;}

        [NameValidation]
        public string Name { get; set;}
        public int HealthState { get; set;}
        public List<TodoLog> Logs{ get; set;}
    }
}