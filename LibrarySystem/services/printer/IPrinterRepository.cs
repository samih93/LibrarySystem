using LibraryModel;

namespace LibraryApi.services.printer
{
    public interface IPrinterRepository
    {
        Task<PrinterModel> addPrinter(PrinterModel printerModel);
        Task<PrinterModel> UpdatePrinter(PrinterModel Category);
        Task<PrinterModel> GetCurrentPrinter();

    }
}
