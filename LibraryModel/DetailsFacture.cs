using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class DetailsFacture
    {
        public int id { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }

        public int factureId { get; set; }
        public Facture facture { get; set; }

        public int qty { get; set; }
        public double  totalPrice { get; set; }
    }
}
