using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                return View(new HomeViewModel { TaskItems = context.TaskItems.ToList() });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Route("")]
        //[Route("api/Home")]
        //[Route("api/Home/Index")]
        //public IActionResult Index()
        //{
        //    using (var context = new TaskItemDbContext(_optionsBuilder.Options))
        //    {
        //        return View(new HomeViewModel { TaskItems = context.TaskItems.ToList() });
        //    }
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //[Route("[action]")]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //[HttpPost]
        //[Route("[action]")]
        //public void SaveNewTaskItem(TaskItem taskItem)
        //{
        //    using (var context = new TaskItemDbContext(_optionsBuilder.Options))
        //    {
        //        context.Add(taskItem);
        //        context.SaveChanges();

        //        return View(new HomeViewModel { TaskItems = context.TaskItems.ToList() });
        //    }
        //}
    }
}