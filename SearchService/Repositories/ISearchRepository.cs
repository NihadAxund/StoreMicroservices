using SearchService.Entities;

namespace SearchService.Repositories
{
    public interface ISearchRepository
    {
        Barcode Get(string code);
    }
}
