using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspNetCoreMVCTodoApp.Models;

namespace AspNetCoreMVCTodoApp.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemAsync();

        Task<bool> AddItemAsync(Models.ToDoItem newItem);
    }
}