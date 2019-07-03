using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;
using TodoApi.Service;
using WebApi.Helpers;
using TodoApi.Resources;

namespace TodoApi.Controllers{
    [Route("api/targetItems")]
    [ApiController]
    public class TargetController : ControllerBase{
        private readonly ITargetItemManager _targetItemManager;
        private readonly ITodoLogManager _todoLogManager;
        private readonly IMapper _mapper;

        public TargetController(ITargetItemManager targetitemManager, IMapper mapper,ITodoLogManager todoLogManager){
            _targetItemManager = targetitemManager;
            _todoLogManager = todoLogManager;
            _mapper = mapper;
        }

        // //Get a list of all targets
        // [HttpGet]
        // public ActionResult<List<TargetItem>> GetTargets(){
        //     var targetItems = _manager.GetAllTargetItems();
        //     var targetItemResources = _mapper.Map<List<TargetItem>>(targetItems);
        //     return Ok(targetItemResources);
        // }

        //Get a list of all targets by userid
        [HttpGet("{id}")]
        public ActionResult<List<TargetItem>> GetTargetListByUserId([FromRoute] int id){
            
                var targetItems = _targetItemManager.GetTargetListByUserId(id);
                var targetItemResources = _mapper.Map<List<TargetItem>>(targetItems);
                return Ok(targetItemResources);
            
        }
        

        //Add a target
        [HttpPost]
        public IActionResult CreateTarget([FromBody]TargetItemResource itemModel){
            var item = _mapper.Map<TargetItem>(itemModel);
            try
            {
                _targetItemManager.CreateTargetItem(item);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        // //Get an target by id
        // [HttpGet("{id}", Name = "GetTarget")]
        // public ActionResult<TargetItem> GetTargetById(int id){
        //     var item = _manager.GetTargetItemById(id);
        //     if(item == null ){
        //         return NotFound();
        //     }
        //     var itemResource = _mapper.Map<TargetItem>(item);
        //     return itemResource;
        // }

        // //Delete target
        // [HttpDelete("{id}")]
        // public IActionResult DeleteTarget(int id){
        //     var item = _manager.GetTargetItemById(id);
        //     if(item == null ){
        //         return NotFound();
        //     }
        //     _manager.DeleteTargetItem(item);
        //     return NoContent();
        // }

    }
}