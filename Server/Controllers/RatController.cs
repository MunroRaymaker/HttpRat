using System.Collections.Generic;
using System.Web.Http;

namespace Server.Controllers
{
    [RoutePrefix("api/rat")]
    public class RatController : ApiController
    {
        [HttpGet]
        [Route("")]
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET api/values/x        
        public string Get(string id)
        {
            return "false";
        }

        [HttpGet]
        [Route("Create/{hash}/{host}/{ip}/{os}")]
        public string Create(string hash, string host, string ip, string os)
        {
            return "1";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
