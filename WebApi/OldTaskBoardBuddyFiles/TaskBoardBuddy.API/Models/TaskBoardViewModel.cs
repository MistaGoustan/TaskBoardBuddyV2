using System.Collections.Generic;
using TaskBoardBuddy.Models;

namespace TaskBoardBuddy.API.Models
{
    public class TaskBoardViewModel
    {
        public string FilterState { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}