using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Dtos;
using ProductService.Entities;
using ProductService.Repository;
using ProductService.Services;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper, IProductService productService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDto> Get()
        {
            var result = _productRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(result);
            return dtos;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDto Get(int id)
        {
            var item = _productRepository.GetById(id);
            var dto=_mapper.Map<ProductDto>(item);
            return dto;
        }

        [HttpGet("GetImage/{id}")]
        public IActionResult GetImage(int id)
        {
            var result=_productService.GetProductImage(id);
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ProductDto Post([FromBody] ProductDto value)
        {
            var item = _mapper.Map<Product>(value);
            _productRepository.AddProduct(item);
            var dto = _mapper.Map<ProductDto>(item);
            return dto;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ProductDto Put(int id, [FromBody] ProductDto value)
        {
            var item = _mapper.Map<Product>(value);
            _productRepository.Update(item);
            var dto = _mapper.Map<ProductDto>(item);
            return dto;
        }

    }
}
