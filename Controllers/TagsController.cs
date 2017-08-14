using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bpt.api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bpt.api.Controllersbasa
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {

        private readonly BptContext _context;

        public TagsController(BptContext context)
        {
            this._context = context;
        }

        // GET: api/tags
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            var tags = this._context.Tag.ToList();
            return tags;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
