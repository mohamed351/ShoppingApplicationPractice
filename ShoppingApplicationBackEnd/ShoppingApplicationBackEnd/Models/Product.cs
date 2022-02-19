using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Models
{
    public class Product
    {

        public int ProductID { get; set; }

        public string ProductName { get; set; }


        public decimal PurchasingPrice { get; set; }

        public decimal SellingPrice { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        public string ImageURL { get; set; }

        public Category Category  { get; set; }
    }
}
