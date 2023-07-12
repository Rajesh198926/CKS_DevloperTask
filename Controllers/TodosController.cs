using AdminLTE.MVC.Data;
using CKS_DevloperTask.Interfaces;
using CKS_DevloperTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKS_DevloperTask.Controllers
{
    public class TodosController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ITodoList _todoList;
        public TodosController(ITodoList todoList,ApplicationDbContext applicationDbContext)
        {
            _todoList = todoList;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            var model = new ToDoViewModelsList();
            var userid = HttpContext.User.Identity.Name;
           model.List = _applicationDbContext.ToDos.Where(t => t.IsDeleted == false && t.UserId==userid).Select(i => new ToDoViewModelsCreateEdit
            {
                Id = i.Id,
                Priority=i.Priority ,
                TaskName  = i.TaskName,
                Notes=i.Notes,
                DueDate=i.DueDate.Date,
                IsActive = i.IsActive
            }).ToList();
            ViewBag.Notifications = _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.DueDate.Date == DateTime.Now.Date && i.IsRemind == true && i.IsActive == true && i.UserId == userid).Count();
            return View(model);
        }

        public IActionResult Notifications()
        {
            var model = new ToDoViewModelsList();
            var userid = HttpContext.User.Identity.Name;
            model.List = _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.DueDate.Date == DateTime.Now.Date && i.IsRemind == true && i.IsActive == true && i.UserId == userid).Select(i => new ToDoViewModelsCreateEdit
            {
                Id = i.Id,
                Priority = i.Priority,
                TaskName = i.TaskName,
                Notes = i.Notes,
                DueDate = i.DueDate.Date,
                IsActive = i.IsActive
            }).ToList();
            ViewBag.Notifications = _applicationDbContext.ToDos.Where(i => i.IsDeleted == false && i.DueDate.Date == DateTime.Now.Date && i.IsRemind == true && i.IsActive == true && i.UserId == userid).Count();
            return View(model);
        }
        public IActionResult Create()
        {
            var model = new ToDoViewModelsCreateEdit();
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit)
        {

            toDoViewModelsCreateEdit.UserId = HttpContext.User.Identity.Name;
            try
            {
                int result = Convert.ToInt32(_todoList.AddTodo(toDoViewModelsCreateEdit));
                if (result>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Insert failed");
                }
            }
            finally
            {
                
            }          
        }
        public IActionResult Edit(int Id)
        {
            var  model = _applicationDbContext.ToDos.FirstOrDefault(i => i.Id == Id);
                ToDoViewModelsCreateEdit toDoViewModelsCreateEdit  = new ToDoViewModelsCreateEdit();     
                toDoViewModelsCreateEdit.Id = model.Id;
                toDoViewModelsCreateEdit.TaskName = model.TaskName;
                toDoViewModelsCreateEdit.Priority  = model.Priority ;
                toDoViewModelsCreateEdit.Notes  = model.Notes ;
                toDoViewModelsCreateEdit.DueDate  = model.DueDate;
                toDoViewModelsCreateEdit.IsRemind = model.IsRemind;
            return View(toDoViewModelsCreateEdit);
        }

        [HttpPost]
        public IActionResult Edit(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit)
        {

            toDoViewModelsCreateEdit.UserId = HttpContext.User.Identity.Name;
            try
            {
                int result = Convert.ToInt32(_todoList.EditTodo(toDoViewModelsCreateEdit));
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Insert failed");
                }
            }
            finally
            {

            }
        }

        public IActionResult Mark(int Id)
        {
            bool  result = _todoList.StatusTodo(Id);
            if (result==true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
