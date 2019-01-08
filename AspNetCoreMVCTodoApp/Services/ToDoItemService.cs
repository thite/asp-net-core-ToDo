using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AspNetCoreMVCTodoApp.Models;
using AspNetCoreMVCTodoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCTodoApp.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoItemService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> AddItemAsync(ToDoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            
            _dbContext.Items.Add(newItem);

            var saveResult = await _dbContext.SaveChangesAsync();

            return saveResult==1;
        }

        public async Task<ToDoItem[]> GetIncompleteItemAsync()
        {
           return await _dbContext.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }
    }
}