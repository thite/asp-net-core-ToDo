using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspNetCoreMVCTodoApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMVCTodoApp.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemAsync();

        Task<bool> AddItemAsync(Models.ToDoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
        Task<ToDoItem[]> GetIncompleteItemAsync(IdentityUser currentUser);
        Task<bool> AddItemAsync(ToDoItem newItem, IdentityUser currentUser);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser);
    }
}