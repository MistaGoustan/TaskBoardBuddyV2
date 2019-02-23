using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WebApi.Models
{
    [DataContract]
    public class FooResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public FooEnum Title { get; set; }

        [DataMember(Name = "FooText")]
        [Description("some text")]
        public string FooText { get; set; }

        [Description("Not a data member. This must be hidden in data contract")]
        public string InternalNeedsOnly => "For internal needs only. Should not be exposed in Swagger UI anywhere";
    }
}