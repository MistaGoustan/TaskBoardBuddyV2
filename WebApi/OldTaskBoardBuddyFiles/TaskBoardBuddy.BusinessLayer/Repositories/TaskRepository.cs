using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskBoardBuddy.DataAccess.Context;
using TaskBoardBuddy.Models;

namespace TaskBoardBuddy.BusinessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DbContextOptionsBuilder<TaskDbContext> _optionsBuilder = new DbContextOptionsBuilder<TaskDbContext>();

        public TaskRepository(IConfiguration configuration)
        {
            _optionsBuilder.UseSqlServer(configuration.GetConnectionString("MasterTbbDb"));
        }

        public Task CreateDummyTask()
        {
            return new Task
            {
                Title = "Tasky Template - FROM REPO",
                Description = "The task description goes here. The task description goes here. The task description goes here. The task description goes here.",
                State = TaskStates.Active,
                CreatedDate = DateTime.Now
            };
        }

        public IEnumerable<Task> GetAllTasks()
        {
            using (var context = new TaskDbContext(_optionsBuilder.Options))
            {
                return context.Tasks.ToList();
            }
        }

        public IEnumerable<Task> GetTasksByState(string state)
        {
            using (var context = new TaskDbContext(_optionsBuilder.Options))
            {
                return string.IsNullOrEmpty(state) 
                    ? context.Tasks.ToList() 
                    : context.Tasks.Where(task => task.State == state.ToUpper()).ToList();
            }
        }

        public void Save(Task task)
        {
            using (var context = new TaskDbContext(_optionsBuilder.Options))
            {
                context.Add(task);
                context.SaveChanges();
            }
        }
    }
}