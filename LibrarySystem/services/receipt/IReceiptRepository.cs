using LibraryModel;

namespace LibraryApi.services.receipt
{
    public interface IReceiptRepository

    {
        Task<Receipt> AddReceipt(Receipt receipt);
        Task<Receipt?> GetReceipt(int receiptId);

        Task<List<Receipt>> GetReceipts();
    }
}
