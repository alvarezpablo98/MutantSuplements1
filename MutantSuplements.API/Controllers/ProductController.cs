using System.Xml.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutantSuplements.API.DTOs.ProductDTOs;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;

namespace MutantSuplements.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAll()
        {
            List<Product> products = _repository.GetAllProducts().ToList();
            var productsDto = _mapper.Map<List<ProductDTO>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductToCreateDTO newProduct)
        {
            if(newProduct == null)
            {
                return BadRequest();
            }
            string name = newProduct.Name;
            if (_repository.ProductExists(name))
            {
;               return BadRequest("Error al crear el producto, ya hay un producto con el mismo nombre");
            }

            var productCreated = _mapper.Map<Product>(newProduct);
            _repository.AddProduct(productCreated);
            var saved = _repository.SaveChanges();

            if(saved != true)
            {
                return BadRequest("No se pudo crear el producto");
            }

            var productCreatedDto = _mapper.Map<ProductToCreateDTO>(productCreated);
            //return CreatedAtRoute("GetById", new { productId = productCreated.Id }, _mapper.Map<ProductToCreateDTO>(productCreated));
            return Created("Created", productCreatedDto);
        }

    }
}
