using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ccAppCore
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController<ValuesController>
    {
       // private ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            //_logger = logger;

        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
          

           // return "test";
           
            // Logger.LogInformation("This is from base controller test logging And nothing!!!!");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
