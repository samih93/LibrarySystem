using LibraryModel;

namespace LibraryApi.services.detailsreceipt
{
    public interface IDetailsReceiptRepository
    {
        Task<List<DetailsReceipt>> GetDetailsReceiptByReceiptId(int receiptId);

        Task AddDetailsReceipt(List<DetailsReceipt> detailsReceipts);

    }
}
