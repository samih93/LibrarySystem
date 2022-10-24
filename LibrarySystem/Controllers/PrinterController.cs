using LibraryApi.services.printer;
using LibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository rinterRepository)
        {
            _printerRepository = rinterRepository;
        }
        // POST: api/Printer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<PrinterModel> AddPrinter(PrinterModel printerModel)
        {
            var oldprintModel = await _printerRepository.GetCurrentPrinter();
            if (oldprintModel == null)
            {
                oldprintModel =  await _printerRepository.addPrinter(printerModel);

            }
            return oldprintModel;

        }

        [HttpPut]
        // put: api/Printer
        public async Task<PrinterModel> UpdatePrinter(PrinterModel printerModel)
        {

            return await _printerRepository.UpdatePrinter(printerModel);

        }
        [HttpGet]
        // put: api/Printer
        public async Task<PrinterModel> GetCurrentPrinter()
        {

            return await _printerRepository.GetCurrentPrinter();

        }


    }
}
