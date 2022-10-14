using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Product
    {
        public int id { get; set; }
        public string? name { get; set; }
        public double price { get; set; }
        [NotMapped]
        public double qty { get; set; }

        public int categoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<DetailsReceipt>? Detailsreceipts { get; set; }


    }
}
