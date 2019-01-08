using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMVCTodoApp.Models
{
    public class ToDoViewModel
    {
        public ToDoItem[] Items {get; set;}
    }

}