using System.ComponentModel;

namespace WebApi.Models
{
    public class FooRequest
    {
        public FooEnum Title { get; set; }

        [Description("the foo text")]
        public string FooText { get; set; }
    }
}