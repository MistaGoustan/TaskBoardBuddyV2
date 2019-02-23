using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskBoardBuddy.BusinessLayer.Repositories;
using TaskBoardBuddy.Models;

namespace TaskBoardBuddy.API.Controllers
{
    public class TaskBoardController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskBoardController(ITaskRepository taskRepository)
            => _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));

        [HttpGet]
        public IActionResult Index(string state)
        {
            return View(_taskRepository.GetTasksByState(state));
        }

        [HttpPost]
        public void SaveTask(Task task)
        {
            _taskRepository.Save(task);
        }

        [HttpGet]
        public IEnumerable<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
    }
}