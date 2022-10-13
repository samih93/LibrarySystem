using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Receipt
    {
        public int id { get; set; }
        public double receiptPrice { get; set; }
        public DateTime receiptDate { get; set; }

        public ICollection<DetailsReceipt>? Detailsreceipts { get; set; }

    }
}
