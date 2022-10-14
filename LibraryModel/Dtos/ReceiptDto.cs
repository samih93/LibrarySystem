using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Dtos
{
    public class ReceiptDto
    {
        public int id { get; set; }
        public double receiptPrice { get; set; }
        public DateTime receiptDate { get; set; }
    }
}
