using BarCodeService.DataContext;
using BarCodeService.Dtos;
using BarCodeService.Entities;
using System.Text;

namespace BarCodeService.Repository
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly BarcodeContext _context;

        public BarcodeRepository(BarcodeContext context)
        {
            _context = context;
        }

        public string AddBarcode(ProductItemDto model)
        {

            var hash = model.GetHashCode().ToString();
            var item = _context.Barcodes.FirstOrDefault(b => b.ProductId==model.ProductId&&
            b.Volume==model.Volume);
            if (item == null)
            {
            var data = new Barcode
            {
                Code = hash,
                ProductName = model.ProductName,
                TotalPrice = model.Volume * model.Price,
                Volume = model.Volume,
                ProductId = model.ProductId,
            };
            _context.Barcodes.Add(data);
            _context.SaveChanges();
                return hash;
            }
            return item.Code;
        }
    }
}
