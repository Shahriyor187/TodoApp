using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using TodoApp.Models;
using TodoApp.Models.Dtos;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;

        public HomeController(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public IActionResult Index()
        {
            var todos = appDbContext.Todos.Find(v => true).ToList();
            return View(todos);
        }
        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index1(AddTodoDto todoDto)
        {
            appDbContext.Todos.InsertOne((Todo)todoDto);

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public async  Task<IActionResult> Index2(string id)
        {
            var res = await appDbContext.Todos.Find(t => t.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
            var todo = (TodoDto)res;

            return View(todo);
        }

        [HttpPost]
        public IActionResult Index2(TodoDto todoDto)
        {
            var todo = new Todo
            {
                Id = new MongoDB.Bson.ObjectId(todoDto.Id),
                Title = todoDto.Title
            };

            appDbContext.Todos.ReplaceOne(t => t.Id == todo.Id, todo);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var k = ObjectId.Parse(id);
            var t = await appDbContext.Todos.FindOneAndDeleteAsync(t => t.Id == k);
            if(t != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}