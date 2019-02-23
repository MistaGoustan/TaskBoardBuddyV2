using System.Collections.Generic;
using TaskBoardBuddy.Models;

namespace TaskBoardBuddy.BusinessLayer.Repositories
{
    public interface ITaskRepository
    {
        Task CreateDummyTask();
        IEnumerable<Task> GetAllTasks();
        IEnumerable<Task> GetTasksByState(string state);
        void Save(Task task);
    }
}