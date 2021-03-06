using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TodoApi.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public int TimesForMode { get; set;}
        public int Time { get; set;}
        
        [JsonConverter(typeof(StringEnumConverter))]  
        public ModeType? Mode { get; set;}
        public string ModeValue { get; set;}
        public virtual List<TodoLog> Logs { get; set;}

        public bool IsBuildIn { get; set;}

        public Kind? Type { get; set;}
    }
}