using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCTodoApp.Models
{
    public class ToDoItem
    {
        public Guid Id {get;set;}

        [Required]
        public string Title {get; set;}
        public bool IsDone {get;set;}

        public DateTimeOffset? DueAt {get;set;}
    }

}