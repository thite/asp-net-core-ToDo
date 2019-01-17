using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspNetCoreMVCTodoApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace AspNetCoreMVCTodoApp.Controllers
{
    [Authorize]
    public class ToDoController:Controller
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly UserManager<IdentityUser> _userManager;

        public ToDoController(IToDoItemService toDoItems, UserManager<IdentityUser> userManager)
        {
            _toDoItemService = toDoItems;
            _userManager = userManager;
            
        }
         
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) { return Challenge(); }

            //Get to-do items from database for current logged in user
            var items = await _toDoItemService.GetIncompleteItemAsync(currentUser);
            //var items = await _toDoItemService.GetIncompleteItemAsync();

            //put items in model
            var model = new Models.ToDoViewModel()
            {
                Items = items
            };

            //render view using model
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(Models.ToDoItem newItem)
        {
            if(!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) { return Challenge(); }

            var success = await _toDoItemService.AddItemAsync(newItem,currentUser);

            if (!success)
            {
                return BadRequest("Could not add item");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if(id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) { return Challenge(); }

            var successful = await _toDoItemService.MarkDoneAsync(id,currentUser);

            if(!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Test()
        {
            throw new InvalidOperationException("This operation is invalid!");
        }
    }

}