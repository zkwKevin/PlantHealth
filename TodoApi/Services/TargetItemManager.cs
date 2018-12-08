

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

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

        public void CreateTargetItem(TargetItem item)
        {
            _context.TargetItems.Add(item);
            _context.SaveChanges(); 
        }


        public TargetItem GetTargetItemById(long id){
            var item = _context.TargetItems.Find(id);
            return item;
        }

         public void DeleteTargetItem(TargetItem item){
            _context.TargetItems.Remove(item);
            _context.SaveChanges();    
        }
    }
}