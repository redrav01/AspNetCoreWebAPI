using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;
using SampleAPI.Services;

namespace SampleAPI.Controllers
{
    [Route("CM/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryServices _services;

        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult<string> Index()
        {
            return "CM Service is running now";
        }

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);

            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }


        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems.Count() == 0)
            {
                return NotFound();
            }

            return inventoryItems;
        }

        // GET api/values
        [HttpGet]
        [Route("Get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("Add")]
        public ActionResult<string> Add()
        {
            return "this is Add method";
        }

        [Route("Substract")]
        public ActionResult<string> Substract()
        {
            return "this is Subtract method";
        }

        [Route("Multiply")]
        public ActionResult<string> Multiply()
        {
            return "this is Multiply method";
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
    

