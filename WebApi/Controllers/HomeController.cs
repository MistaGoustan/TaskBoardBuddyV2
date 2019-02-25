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

        public IActionResult Index()
        {
            using (var context = new TaskItemDbContext(_optionsBuilder.Options))
            {
                var taskItems = new List<TaskItemViewModel>();

                foreach (var item in context.TaskItems.ToList())
                {
                    taskItems.Add(new TaskItemViewModel
                    {
                        TaskItemId = item.TaskItemId,
                        Title = item.Title,
                        Description = item.Description,
                        State = item.State,
                        CreatedDate = item.CreatedDate
                    });
                }

                return View(new HomeViewModel { TaskItems = taskItems });
            }
        }

        [HttpPost]
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

                return RedirectToAction("Index"); // TODO
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}