using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Quantity { get; set; }
        public int Price { get; set; }

        public string Description { get; set; } = null!;
        public List<Sale> Sales { get; set; }

    }
}
