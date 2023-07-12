using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKS_DevloperTask.ViewModels;
namespace CKS_DevloperTask.Interfaces
{
  public interface ITodoList
    {
        public int AddTodo(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit);
        public int EditTodo(ToDoViewModelsCreateEdit toDoViewModelsCreateEdit);
        public int RemoveTodo(int Id);
        public bool StatusTodo(int Id);
    }
}
