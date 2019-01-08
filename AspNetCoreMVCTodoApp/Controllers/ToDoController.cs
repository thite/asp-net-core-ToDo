using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspNetCoreMVCTodoApp.Services;


namespace AspNetCoreMVCTodoApp.Controllers
{
    public class ToDoController:Controller
    {
        private readonly IToDoItemService _toDoItemService;
        public ToDoController(IToDoItemService toDoItems)
        {
            _toDoItemService = toDoItems;
        }
        public async Task<IActionResult> Index()
        {
            //Get to-do items from database
            var items = await _toDoItemService.GetIncompleteItemAsync();

            //put items in model
            var model = new Models.ToDoViewModel(){
                Items = items
            };

            //render view using model
            return View(model);
        }

        public async Task<IActionResult> AddItem(Models.ToDoItem newItem)
        {
            if(!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            var success = await _toDoItemService.AddItemAsync(newItem);
            if(!success)
            {
                return BadRequest("Could not add item");
            }

            return RedirectToAction("Index");
        }
    }

}