using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class DetailsFacture
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int FactureId { get; set; }
        public Facture Facture { get; set; }

        public int Qty { get; set; }
        public double  TotalPrice { get; set; }
    }
}
