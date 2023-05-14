using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private ItemService _itemService{ get; set; }

        public ItemController(ItemService itemService)
        {
            this._itemService = itemService;
        }

        [HttpGet("/get-all-items")]
        [AllowAnonymous]
        public ActionResult<List<Item>> GetAll()
        {
            try
            {
                var results = _itemService.GetAll();
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemController => ActionResult<List<Item>> GetAll(): " + e.Message);
                return BadRequest("Error while loading all items: " + e.Message);
            }
        }

        [HttpGet("/get/{itemId}")]
        [AllowAnonymous]
        public ActionResult<Item> GetById(int itemId)
        {
            try
            {
                var item = _itemService.GetById(itemId);
                return Ok(item);
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemController => ActionResult<Item> GetById(int itemId): " + e.Message);
                return BadRequest("Error while loading the requested item: " + e.Message);
            }
        }

        [HttpPost("/add-item")]
        [Authorize]
        public ActionResult Add(AddItemDto payload)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("Admin")) return Unauthorized();
            try
            {
                _itemService.Add(payload);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemController => ActionResult Add(AddItemDto payload): " + e.Message);
                return BadRequest("Error while adding the item: " + e.Message);
            }
        }

        [HttpPatch("/edit-item")]
        [Authorize]
        public ActionResult<bool> GetById([FromBody] EditItemDto payload)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("Admin")) return Unauthorized();
            try
            {
                var result = _itemService.Edit(payload);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemController => ActionResult<bool> GetById([FromBody] EditItemDto payload): " + e.Message);
                return BadRequest("Error while editing item");
            }
        }

        [HttpDelete("/delete-item")]
        [Authorize]
        public ActionResult<bool> Delete(int itemId)
        {
            var user = HttpContext.User;
            if (!user.IsInRole("Admin")) return Unauthorized();
            try
            {
                var result = _itemService.Delete(itemId);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("ItemController => ActionResult<bool> Delete(int itemId): " + e.Message);
                return BadRequest("Error while deleting item");
            }
        }

    }
}
