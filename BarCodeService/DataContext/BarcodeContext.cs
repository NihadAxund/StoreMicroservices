using BarCodeService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BarCodeService.DataContext
{
    public class BarcodeContext:DbContext
    {
        public BarcodeContext(DbContextOptions<BarcodeContext>
            options)
            :base(options)
        {

        }
        public DbSet<Barcode> Barcodes { get; set; }
    }
}
