using ProductService.Entities;

namespace ProductService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void AddProduct(Product product);
        void Update(Product product); 
    }
}
