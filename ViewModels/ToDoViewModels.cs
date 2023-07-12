using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CKS_DevloperTask.ViewModels
{
    public class ToDoViewModelsList
    {
      public List<ToDoViewModelsCreateEdit> List { get; set; }
        public int Id { get; set; }
        public string Priority { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public bool IsRemind { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ToDoViewModelsCreateEdit
    {

        public int Id { get; set; }
        public string Priority { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string Notes { get; set; }
        public bool IsRemind { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
