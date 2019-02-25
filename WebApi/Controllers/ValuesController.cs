using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// comment description for endpoint
        /// </summary>
        /// <param name="fooRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public FooResponse GetFoo([FromBody]FooRequest fooRequest)
        {
            return new FooResponse { Id = 1, FooText = "Foooooo" };
        }
    }
}
