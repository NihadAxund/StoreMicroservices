using SearchService.DataContext;
using SearchService.Entities;

namespace SearchService.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly BarcodeContext _context;

        public SearchRepository(BarcodeContext context)
        {
            _context = context;
        }

        public Barcode Get(string code)
        {
            var item=_context.Barcodes.SingleOrDefault(b => b.Code == code);
            return item;
        }
    }
}
