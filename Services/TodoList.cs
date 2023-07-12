using AdminLTE.MVC.Data;
using AutoMapper;
using CKS_DevloperTask.Interfaces;
using CKS_DevloperTask.Models;
using CKS_DevloperTask.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
namespace CKS_DevloperTask.Services
{
    public class TodoList : ITodoList
    {
        private readonly ApplicationDbContext _ObjContext;
        private IMapper _imapper;
 //      private readonly IHttpContextAccessor _httpContextAccessor;

        public TodoList(ApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _ObjContext = applicationDbContext;
            _imapper = mapper;
   //         _httpContextAccessor = httpContextAccessor;
        }
        public int AddTodo(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit)
        {
            int result = 0;
            var models = _imapper.Map<ToDoViewModelsCreateEdit, ToDo>(toDoViewModelsCreateEdit);
            
            if (models != null)
            {

                models.CreatedBy = toDoViewModelsCreateEdit.CreatedBy;// _httpContextAccessor.HttpContext.User.Identity.Name;
                models.CreatedDate = DateTime.Now;
                models.IsActive = true;
                models.CreatedBy = "";
                models.IsDeleted = false;
                models.UpdatedBy = "";// _httpContextAccessor.HttpContext.User.Identity.Name;
                models.UpdatedOn = DateTime.Now;
               
                    _ObjContext.ToDos.Add(models);
                     _ObjContext.SaveChanges();
                return result = 1;
            }
            else
            {
                return result;

            }
        }

        public int EditTodo(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit)
        {
            int result = 0;
            var models = _imapper.Map<ToDoViewModelsCreateEdit, ToDo>(toDoViewModelsCreateEdit);

            if (models != null)
            {

                models.CreatedDate = DateTime.Now;
                models.IsActive = true;
                models.CreatedBy = "";
                models.IsDeleted = false;
                models.UpdatedOn = DateTime.Now;
                _ObjContext.ToDos.Update(models);
                _ObjContext.SaveChanges();
                return result = 1;
            }
            else
            {
                return result;

            }
        }

        public int  RemoveTodo(int Id)
        {
            return Id;
        }

        public bool  StatusTodo(int Id)
        {
            ToDo ObjProducts = _ObjContext.ToDos.FirstOrDefault(i => i.Id == Id) ?? (ToDo)null;

            if (ObjProducts != null)
            {
                if (ObjProducts.IsActive == true)
                {
                    ObjProducts.IsActive = false;
                }
                else
                {
                    ObjProducts.IsActive = true;
                }
                _ObjContext.ToDos.Update(ObjProducts);
                _ObjContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
