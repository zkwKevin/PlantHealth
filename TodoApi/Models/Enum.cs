using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Enum
    {
         public enum Kind 
        { 
            Animal = 0, 
            Plant = 1
        }

        public enum ModeType
        {
            Hour = 0,
            Day = 1,
            Week = 2,
            Month = 3
        }
        
    }
}