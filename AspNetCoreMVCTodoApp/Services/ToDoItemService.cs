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
            
            if(newItem.DueAt < DateTime.Now.Date)
                return false;
                
            _dbContext.Items.Add(newItem);

            var saveResult = await _dbContext.SaveChangesAsync();

            return saveResult==1;
        }

        public async Task<ToDoItem[]> GetIncompleteItemAsync()
        {
           return await _dbContext.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            //throw new NotImplementedException();
            var item = await _dbContext.Items
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _dbContext.SaveChangesAsync();
            return saveResult == 1; //return true if one entity is updated.
        }
    }
}