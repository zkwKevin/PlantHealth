using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TodoApi.CustomValidations;
using static TodoApi.Models.Enum;

namespace TodoApi.Models
{
    public class TargetItem
    {
        public long Id { get; set;}

        [Required]
        public Kind? Type { get; set;}

        [NameValidation]
        public string Name { get; set;}
        public int HealthState { get; set;}
        public List<TodoLog> Logs{ get; set;}
    }
}