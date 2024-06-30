using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Api.Catalogs.Domains
{ 
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public string AnonymousName { get; set; }
    }

}
