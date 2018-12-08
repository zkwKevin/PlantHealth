using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITargetItemManager
    {
        List<TargetItem> GetAllTargetItems();

        void CreateTargetItem(TargetItem item);
        TargetItem GetTargetItemById(long id);
        void DeleteTargetItem(TargetItem item);

    }
}