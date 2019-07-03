using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public interface ITargetItemManager
    {
        List<TargetItem> GetAllTargetItems();
        List<TargetItem> GetTargetListByUserId(int userId);

        TargetItem CreateTargetItem(TargetItem item);
        TargetItem GetTargetItemById(int id);
        void DeleteTargetItem(TargetItem item);

    }
}