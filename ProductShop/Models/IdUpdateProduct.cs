using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductShop.Models
{
    public static class IdUpdateProduct
    {
        public static int UpdateId(IEnumerable<Product> products)
        {
            var last = products.LastOrDefault();
            return last != null ? last.ProductId + 1 : 1;
        }

    }
}