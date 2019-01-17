using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekGruppProjekt.Models.LoanCatalog
{
    public class LoanDetailModel
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public LibraryData.Models.Member Member { get; set; }
        public DateTime Checkout { get; set; }
    }
}
