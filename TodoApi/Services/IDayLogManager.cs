using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface IDayLogManager
    {
         void CreateFirstDayLog(int todoLogId);

    }
}