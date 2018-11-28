using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : ControllerBase{
        private readonly TodoContext _context;

        public TargetController(TodoContext context){
            _context = context;
        }

        //Get a list of all targets
        [HttpGet]
        public ActionResult<List<TargetItem>> GetAllTargets(){
            return _context.TargetItems.ToList();
        }

        //Add a target
        [HttpPost]
        public IActionResult CreateTarget(TargetItem item){
            _context.TargetItems.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTarget", new { id = item.Id}, item );
        }

        //Get an target by id
        [HttpGet("{id}", Name = "GetTarget")]
        public ActionResult<TargetItem> GetTargetById(long id){
            var item = _context.TargetItems.Find(id);
            if(item == null ){
                return NotFound();
            }
            return item;
        }

        //Delete target
        [HttpDelete("{id}")]
        public IActionResult DeleteTarget(long id){
            var target = _context.TargetItems.Find(id);
            if(target == null){
                return NotFound();
            }
            _context.TargetItems.Remove(target);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}