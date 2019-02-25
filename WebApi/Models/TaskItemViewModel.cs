using System;

namespace WebApi.Models

{
    public class TaskItemViewModel
    {
        public int TaskItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}