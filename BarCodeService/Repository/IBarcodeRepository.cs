using BarCodeService.Dtos;

namespace BarCodeService.Repository
{
    public interface IBarcodeRepository
    {
        string AddBarcode(ProductItemDto model);
    }
}
