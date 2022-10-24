using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class PrinterModel
    {
        public int id { get; set; }
        public string modelName { get; set; }
        public bool isprintReceipt { get; set; }
        public string pageSize { get; set; }
    }
}
