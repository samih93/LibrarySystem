using AutoMapper;
using LibraryApi.Models;
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.services.receipt
{
    public class ReceiptRepository : IReceiptRepository
    {

        private readonly LibraryDbContext _appDbContext;

        public ReceiptRepository(LibraryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Receipt> AddReceipt(Receipt receipt)
        {
            _appDbContext.Receipts.Add(receipt);
            await _appDbContext.SaveChangesAsync();
            return receipt;

        }

        public async Task<double> GetDailyInCome(DateTime date)
        {
            return await _appDbContext.Receipts.Where(r => r.receiptDate.Year == date.Year && r.receiptDate.Month == date.Month && r.receiptDate.Day == date.Day).SumAsync(r => r.receiptPrice);

        }

        public async Task<Receipt?> GetReceipt(int receiptId)
        {
            Receipt? receipt =await _appDbContext.Receipts.FirstOrDefaultAsync(r => r.id == receiptId);
          
            return receipt;
        }

        public async Task<List<Receipt>> GetReceipts()
        {
            return await _appDbContext.Receipts.Include(r=>r.Detailsreceipts).ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptsByDat(DateTime date)
        {
            return await _appDbContext.Receipts.Where(r => r.receiptDate.Year == date.Year  && r.receiptDate.Month ==date.Month && r.receiptDate.Day ==date.Day).ToListAsync();
        }
    }
}
