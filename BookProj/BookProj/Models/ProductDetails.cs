using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookProj.Models
{
    public class ProductDetails
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public Int64 Price { get; set; }
        public string BookImage { get; set; }

        public List<ProductDetails> productlist { get; set; }
    }
}