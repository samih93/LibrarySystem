using LibraryApi.Models;
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.services.detailsreceipt
{
    public class DetailsReceiptRepository : IDetailsReceiptRepository
    {
        private readonly LibraryDbContext _appDbContext;

        public DetailsReceiptRepository(LibraryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddDetailsReceipt(List<DetailsReceipt> detailsReceipts)
        {
            foreach (var item in detailsReceipts)
            {
                _appDbContext.DetailsReceipts.AddRange(new DetailsReceipt { 
                    productId = item.productId,
                    qty = item.qty,
                    price = item.price,
                    receiptId = item.receiptId
                });
            }
           await  _appDbContext.SaveChangesAsync();
        }

        public async Task<List<DetailsReceipt>> GetDetailsReceiptByReceiptId(int receiptId)
        {
            return await _appDbContext.DetailsReceipts.Where(dr => dr.receiptId == receiptId).Include(dr=>dr.Product).ToListAsync();
        }

        public async Task refundItems(List<DetailsReceipt> detailsReceipts)
        {
            double refundprice = 0;
                foreach (var item in detailsReceipts)
                {
                    _appDbContext.DetailsReceipts.Remove(item);
                refundprice += item.Product!.price * item.qty;
                }

            Receipt? receipt = _appDbContext.Receipts.Find(detailsReceipts[0].receiptId);
            receipt.receiptPrice -= refundprice; 

            _appDbContext.Entry(receipt).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

        }
    }
}
