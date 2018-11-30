using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITargetItemManager
    {
        List<TargetItem> GetAllTargets();

        void Create(TargetItem item);
        TargetItem GetById(long id);
        void Delete(TargetItem item);
    }
}