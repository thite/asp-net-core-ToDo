using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreMVCTodoApp.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMVCTodoApp.Services
{
    public class FakeToDoItemService : IToDoItemService
    {
        public Task<bool> AddItemAsync(ToDoItem newItem)
       {
            throw new Exception();
       }

        public Task<bool> AddItemAsync(ToDoItem newItem, IdentityUser currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem[]> GetIncompleteItemAsync()
        {
            var item1 = new ToDoItem{
                Title = "Learn ASPnet Core 2.0",
                DueAt = DateTimeOffset.Now.AddMinutes(305)
            };

            var item2 = new ToDoItem{
                Title = "Microservice Architercture - Beginner's Guide",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult(new[] {item1,item2});
        }

        public Task GetIncompleteItemAsync(IdentityUser currentUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkDoneAsync(Guid id, IdentityUser currentUser)
        {
            throw new NotImplementedException();
        }

        Task<bool> IToDoItemService.AddItemAsync(ToDoItem newItem)
        {
            throw new NotImplementedException();
        }

        Task<ToDoItem[]> IToDoItemService.GetIncompleteItemAsync()
        {
            throw new NotImplementedException();
        }

        Task<ToDoItem[]> IToDoItemService.GetIncompleteItemAsync(IdentityUser currentUser)
        {
            throw new NotImplementedException();
        }

        Task<bool> IToDoItemService.MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}