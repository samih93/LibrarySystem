﻿using LibraryApi.Models;
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

        public Task<Receipt> GetReceipt(int receiptId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Receipt>> GetReceipts()
        {
            return await _appDbContext.Receipts.Include(r=>r.Detailsreceipts).ToListAsync();
        }
    }
}