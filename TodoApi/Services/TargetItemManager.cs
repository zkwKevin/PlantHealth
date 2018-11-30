

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

        public List<TargetItem> GetAllTargets()
        {
            return  _context.TargetItems.ToList();     
        }

        public void Create(TargetItem item)
        {
            _context.TargetItems.Add(item);
            _context.SaveChanges(); 
        }

        public TargetItem GetById(long id){
            var item = _context.TargetItems.Find(id);
            return item;
        }

         public void Delete(TargetItem item){
            _context.TargetItems.Remove(item);
            _context.SaveChanges();    
        }

    }
}