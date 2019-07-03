

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace TodoApi.Service
{
    public class TargetItemManager : ITargetItemManager
    {
        private readonly TodoContext _context;
        public TargetItemManager(TodoContext context){
            _context = context;
        }

        public List<TargetItem> GetAllTargetItems()
        {
            return  _context.TargetItems.ToList();     
        }

         public List<TargetItem> GetTargetListByUserId(int userId)
        {
            var targetItems = _context.TargetItems.Where(t => t.UserId == userId)
                                                .Include(t => t.Logs)
                                                .ThenInclude(t => t.TodoItem)
                                                .ToList();
            
            return targetItems;
               
        }

        public TargetItem CreateTargetItem(TargetItem item)
        {
            if(_context.TargetItems.Any(x => x.Type == item.Type && x.Name == item.Name))
                throw new AppException(item.Name + " is already taken");
            if(item.Name == null)
                throw new AppException("Please fill in the blanks");
            _context.TargetItems.Add(item);
            _context.SaveChanges();

            return item;
        }

        public TargetItem GetTargetItemById(int id){
            var item = _context.TargetItems.Find(id);
            return item;
        }

         public void DeleteTargetItem(TargetItem item){
            _context.TargetItems.Remove(item);
            _context.SaveChanges();    
        }
    }
}