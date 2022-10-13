using System;
using System.Collections.Generic;
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
        public double qty { get; set; }

        public int categoryId { get; set; }
        public Category? Category { get; set; }

    }
}
