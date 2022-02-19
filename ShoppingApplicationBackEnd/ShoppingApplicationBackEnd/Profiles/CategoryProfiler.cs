using AutoMapper;
using ShoppingApplicationBackEnd.DTOS.CategoryDTO;
using ShoppingApplicationBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Profiles
{
    public class CategoryProfiler :Profile
    {
        public CategoryProfiler()
        {
            CreateMap<Category, CategoryGetDTO>();
            CreateMap<Category, CategoryUpdateDTO>();
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
