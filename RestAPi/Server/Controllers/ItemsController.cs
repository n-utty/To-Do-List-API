using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPi.Server.Models;
using RestAPi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPi.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _item;
        public ItemsController(IItemRepository item)
        {
            _item = item;

        }

        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            try
            {
                return Ok(await _item.GetItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");

            }


        }
        [HttpGet("{id:Int}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            try
            {
                var task = await _item.GetItem(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");

            }

        }
        [HttpPost]
        public async Task<ActionResult<Item>> AddItem(Item item)
        {
            try
            {
                if (item == null) {
                    return BadRequest();
                }
                //var valTask = _item.GetItem(item.ItemId);
                var task = await _item.AddItem(item);

                return CreatedAtAction(nameof(GetItem), new { id = task.ItemId }, task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating To Do Item");

            }
        }

        [HttpDelete("{id:Int}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            try
            {
                var taskToDel = await _item.GetItem(id);



                if (taskToDel == null)
                {
                    return NotFound("Task is not Found");
                }

                await _item.DeleteItem(id);
                return Ok($"Deleted Item with Id {id}");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Item");

            }

        }


        [HttpPut ("{id:Int}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, Item item)
        {
            try
            {
                if (id != item.ItemId)
                {
                    return BadRequest("Id mismatch");
                }
                var updTask = await _item.GetItem(item.ItemId);
                if (updTask == null){
                    return NotFound();
                }
                //updTask.Status = item.Status;
                //updTask.Priority = item.Priority;
                //updTask.Task = item.Task;
                return await _item.UpdateItem(item);

                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating To Do Item");

            }
        }







    }
}
