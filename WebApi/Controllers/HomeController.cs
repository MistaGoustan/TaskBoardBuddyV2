using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApi.Context;
using WebApi.Models;

namespace TaskBoardBuddy.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptionsBuilder<TaskItemDbContext> _optionsBuilder = new DbContextOptionsBuilder<TaskItemDbContext>();

        public HomeController(IConfiguration configuration)
            => _optionsBuilder.UseSqlServer(configuration.GetConnectionString("TaskBoardBuddyDb"));

        [HttpGet("")]
        [HttpGet("{filterState}")]
        public IActionResult Index(string filterState)
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                filterState = filterState != null 
                    ? filterState.ToUpper()
                    : string.Empty;

                var taskItems = context.TaskItems.ToList();
                var taskItemViewModels = new List<TaskItemViewModel>();

                if (filterState == "ACTIVE" || filterState == "COMPLETED")
                    taskItems = taskItems.Where(item => item.State == filterState).ToList();
                else
                    filterState = "ALL";

                foreach (var item in taskItems)
                {
                    taskItemViewModels.Add(new TaskItemViewModel
                    {
                        TaskItemId = item.TaskItemId,
                        Title = item.Title,
                        Description = item.Description,
                        State = item.State,
                        CreatedDate = item.CreatedDate
                    });
                }

                return View(new HomeViewModel { TaskItems = taskItemViewModels, FilterState = filterState });
            }
        }

        [HttpGet("[action]/{taskItemId}")]
        public IActionResult ChangeState(string taskItemId)
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                if (int.TryParse(taskItemId, out int id))
                {
                    var taskItem = context.TaskItems.Single(item => item.TaskItemId == id);
                    
                    taskItem.State = taskItem.State == "ACTIVE" ? "COMPLETED" : "ACTIVE";
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost("[action]")]
        public IActionResult Save(TaskItemViewModel viewModel)
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                var taskItem = new TaskItemModel
                {
                    TaskItemId = 0,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    State = "ACTIVE",
                    CreatedDate = DateTime.Now
                };

                context.Add(taskItem);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet("[action]/{taskItemId}")]
        public IActionResult Delete(string taskItemId)
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                if (int.TryParse(taskItemId, out int id))
                {
                    context.TaskItems.Remove(context.TaskItems.Single(item => item.TaskItemId == id));
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Deletes all completed tasks
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteAll()
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                foreach (var item in context.TaskItems)
                {
                    if (item.State == "COMPLETED")
                        context.Remove(item);
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}