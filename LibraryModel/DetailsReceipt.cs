using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class DetailsReceipt
    {
        public int id { get; set; }
        public int productId { get; set; }
        public Product? Product { get; set; }

        public int receiptId { get; set; }
        public Receipt? Receipt { get; set; }

    }
}
