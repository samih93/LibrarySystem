using LibraryApi.Models;
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.services.printer
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly LibraryDbContext _appDbContext;

        public PrinterRepository(LibraryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<PrinterModel> addPrinter(PrinterModel printerModel)
        {
            _appDbContext.Printer.Add(printerModel);
            await _appDbContext.SaveChangesAsync();
            return printerModel;
        }

        public async Task<PrinterModel> GetCurrentPrinter()
        {
            return await _appDbContext.Printer.FirstAsync();
        }

        public async Task<PrinterModel> UpdatePrinter(PrinterModel printerModel)
        {
            _appDbContext.Entry(printerModel).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return printerModel;
        }
    }
}
