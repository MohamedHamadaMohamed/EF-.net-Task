using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Models
{
    internal class Sale
    {
        public int SaleId { get; set; }

        public int Product_Id { get; set; }
        public int Customer_Id { get; set; }
        public int Store_Id { get; set; }

        public Product Product  { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }

        public DateOnly Date { get; set; }

    }
}
