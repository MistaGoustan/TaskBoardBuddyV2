using System;

namespace TaskBoardBuddy.Models
{
    // Todo move these constants
    public static class TaskStates
    {
        public const string Active = "ACTIVE";
        public const string Completed = "COMPLETED";
    }

    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}