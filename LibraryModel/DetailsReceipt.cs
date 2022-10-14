using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class DetailsReceipt
    {
      
        public int productId { get; set; }
        public Product? Product { get; set; }


        public double qty { get; set; }
        public int receiptId { get; set; }
        public Receipt? Receipt { get; set; }

    }
}
