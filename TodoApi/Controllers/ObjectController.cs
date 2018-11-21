using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase{
        private readonly TodoContext _context;

        public ObjectController(TodoContext context){
            _context = context;
        }

        //Get all Objects
        [HttpGet]
        public ActionResult<List<ObjectItem>> GetAllObejcts(){
            return _context.ObjectItems.ToList();
        }

        //Create Object
        [HttpPost]
        public IActionResult CreateObject(ObjectItem item){
            _context.ObjectItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetObject", new { id = item.Id}, item );
        }

        //Get object by id
        [HttpGet("{id}", Name = "GetObject")]
        public ActionResult<ObjectItem> GetObjectById(long id){
            var item = _context.ObjectItems.Find(id);
            if(item == null ){
                return NotFound();
            }
            return item;
        }
    }
}