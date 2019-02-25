using System.Collections.Generic;

namespace WebApi.Models
{
    public class HomeViewModel
    {
        public IEnumerable<TaskItemViewModel> TaskItems { get; set; }
        public string FilterState { get; set; }
    }
}