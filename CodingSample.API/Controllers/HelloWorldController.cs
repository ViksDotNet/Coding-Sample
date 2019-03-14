using CodingSample.API.Models;
using System.Web.Http;

namespace CodingSample.API.Controllers
{
    public class HelloWorldController : ApiController
    {

        public IHttpActionResult Get()
        {
            
            OutputModel model = new OutputModel
            {
                OutputData = "Hello World"
            };
            return Ok(model);

        }

    }
}
