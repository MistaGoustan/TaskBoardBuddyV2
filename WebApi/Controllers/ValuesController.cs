using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// comment description for endpoint
        /// </summary>
        /// <param name="fooRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/values/FooValue")]
        public FooResponse GetFoo([FromBody]FooRequest fooRequest)
        {
            return new FooResponse { Id = 1, FooText = "Foooooo" };
        }
    }
}
