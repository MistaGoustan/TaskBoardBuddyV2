using System;

namespace WebApi.Context
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}