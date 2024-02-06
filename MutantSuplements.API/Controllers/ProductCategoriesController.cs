using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutantSuplements.API.DTOs.ProductCategoryDTOs;
using MutantSuplements.API.DTOs.ProductDTOs;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;

namespace MutantSuplements.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository _repository;
        private readonly IMapper _mapper;
        public ProductCategoriesController(IProductCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _repository.GetCategories().ToList();

            if (categories.Count == 0)
            {
                return NotFound("La lista esta vacia");
            }

            var categoryToReturn = _mapper.Map<List<ProductCategoryDTO>>(categories);

            return Ok(categoryToReturn);
        }

        [HttpPost]
        public IActionResult AddProductCategory([FromBody] ProductCategoryAddDTO newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest();
            }

            string name = newCategory.Name;
            if (_repository.ProductCategoryExists(name))
            {
                ; return BadRequest("Error al crear la categoria, ya hay una categoria con el mismo nombre");
            }
            var categoryCreated = _mapper.Map<ProductCategory>(newCategory);

            _repository.AddProductCategory(categoryCreated);
            var saved = _repository.SaveChanges();

            if (saved != true)
            {
                return BadRequest("No se pudo crear el producto");
            }
            return Created("Created", newCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductCategory(int id)
        {
            var category = _repository.ProductCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _repository.DeleteProductCategory(category);
            var saved = _repository.SaveChanges();
            if (saved != true)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
