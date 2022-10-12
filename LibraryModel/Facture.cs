using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Facture
    {
        public int id { get; set; }
        public double facturePrice { get; set; }
        public DateTime factureDate { get; set; }

        public ICollection<DetailsFacture> detailsFactures { get; set; }

    }
}
