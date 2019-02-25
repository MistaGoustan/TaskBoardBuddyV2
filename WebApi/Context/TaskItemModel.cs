using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Context
{
    public class TaskItemModel
    {
        [Key]
        public int TaskItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}