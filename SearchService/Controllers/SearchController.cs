using Microsoft.AspNetCore.Mvc;
using SearchService.Dtos;
using SearchService.Repositories;
using SearchService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IProductService _productService;
        public SearchController(ISearchRepository searchRepository, IProductService productService)
        {
            _searchRepository = searchRepository;
            _productService = productService;
        }

        // GET api/<SearchController>/5
        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var item = _searchRepository.Get(code);
                var dto = new BarcodeDto
                {
                    Code = item.Code,
                    ProductName = item.ProductName,
                    TotalPrice = item.TotalPrice,
                    Volume = item.Volume,
                    Id = item.Id
                };
                if (item == null)
                {
                    return BadRequest();
                }

                var productId=item.ProductId;
                var result = await _productService.GetProductImagePathAsync(productId);

                dto.ImageUrl = result;

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
