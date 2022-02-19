using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApplicationBackEnd.DTOS.CategoryDTO;
using ShoppingApplicationBackEnd.Models;
using ShoppingApplicationBackEnd.Repository;
using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(AuthenticationSchemes = System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler)]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork categoryRepository , IMapper mapper)
        {
            this.unitOfWork = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(mapper.Map<IEnumerable<CategoryGetDTO>>( this.unitOfWork.CategoryRepository.GetAll()));
        }
        [HttpPost]
        public IActionResult PostCategory(CategoryCreateDTO categoryCreateDTO)
        {
           var category = mapper.Map<Category>(categoryCreateDTO);
            unitOfWork.CategoryRepository.Add(category);
            unitOfWork.Complate();
            var cateogryDto = mapper.Map<CategoryGetDTO>(category);
            return CreatedAtAction(nameof(GetByID), new { Id = category.CategoryID }, cateogryDto);

        }
        [HttpGet("{id?}")]
        public IActionResult GetByID(int ?ID)
        {
           if(ID == null)
            {
                return BadRequest("ID is not specified");
            }
            var category = this.unitOfWork.CategoryRepository.GetByID(ID.Value);
            if(category == null)
            {
                return NotFound("The Category is not found");
            }
            return Ok(mapper.Map<CategoryGetDTO>(category));

        }
        [HttpPut("{id?}")]
        public IActionResult PutCategory(int? ID, CategoryUpdateDTO category)
        {
            if(ID == null)
            {
                return BadRequest();
            }
            var updateCategory = this.unitOfWork.CategoryRepository.GetByID(ID.Value);

            if(updateCategory == null)
            {
                return NotFound();
            }
            mapper.Map(updateCategory, category);
            unitOfWork.CategoryRepository.Edit(updateCategory);
            unitOfWork.Complate();
           
            
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int? ID)
        {
            if(ID == null)
            {
                return BadRequest();
            }
            var deleteCategory = this.unitOfWork.CategoryRepository.GetByID(ID.Value);
            unitOfWork.CategoryRepository.Delete(deleteCategory);
            return NoContent();

        }




    }
}
