using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Models;

namespace TaskBoardBuddy.API.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ITaskRepository _taskRepository;

        //public HomeController(ITaskRepository taskRepository)
        //    => _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));

        //[HttpGet("{filterState?}", Name = "default")]
        //public IActionResult Index(string filterState)
        //{
        //    if (string.IsNullOrEmpty(filterState) || filterState == "ALL")
        //        filterState = string.Empty;

        //    var viewModel = new TaskBoardViewModel()
        //    {
        //        FilterState = filterState,
        //        Tasks = _taskRepository.GetTasksByState(filterState)
        //    };

        //    return View(viewModel);
        //}

        // DEFAULT CODE
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}