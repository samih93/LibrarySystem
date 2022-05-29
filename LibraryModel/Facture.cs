using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Facture
    {
        public int Id { get; set; }
        public double FacturePrice { get; set; }
        public DateTime FactureDate { get; set; }

        public ICollection<DetailsFacture> DetailsFactures { get; set; }

    }
}
