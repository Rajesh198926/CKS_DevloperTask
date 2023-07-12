using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKS_DevloperTask.Models;
using CKS_DevloperTask.ViewModels;

namespace CKS_DevloperTask.Helpers
{
    public class ApplicationMappingProfiles: Profile
    {
        public ApplicationMappingProfiles()
        {
            CreateMap<ToDoViewModelsCreateEdit,ToDo>();
            CreateMap<ToDoViewModelsList, ToDo>();
        }
    }
}
