using System.Collections.Generic;
using WebApi.Context;

namespace WebApi.Models
{
    public class HomeViewModel
    {
        public IEnumerable<TaskItem> TaskItems { get; set; }
        public TaskItemFilterStates FilterState { get; set; }
    }
}