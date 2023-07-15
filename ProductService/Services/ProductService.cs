using ProductService.Repository;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public string GetProductImage(int productId)
        {
            return _repository.GetById(productId).ImageUrl;
        }
    }
}
