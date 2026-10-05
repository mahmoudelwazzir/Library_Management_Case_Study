using AutoMapper;
using Library_Management_Case_Study.DTO.CategoryDTO;
using Library_Management_Case_Study.Models;
using Library_Management_Case_Study.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensibility;

namespace Library_Management_Case_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDTO CategoryDTO)
        {
            if (CategoryDTO == null)
                return NotFound();
            var category = _mapper.Map<Category>(CategoryDTO);
            _unitOfWork.Categories.AddItem(category);
            _unitOfWork.save();
            return Created();
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_unitOfWork.Categories.GetAllCategory());
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.Categories.DeleteCategory(id);
            if(category == false)
                return BadRequest();
            _unitOfWork.save();
            return NoContent();
        }
    }

}
