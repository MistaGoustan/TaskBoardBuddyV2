using System.ComponentModel;

namespace WebApi.Models
{
    public class FooRequest
    {
        [Description("the foo text")]
        public string FooText { get; set; }
    }
}