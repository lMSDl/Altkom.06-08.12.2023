using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bogus.Fakers
{
    public class ProductFaker : BaseFaker<Product>
    {
        public ProductFaker()
        {
            RuleFor(x => x.Name, x => x.Commerce.ProductName());
            RuleFor(x => x.Price, x => (float)x.Finance.Amount(0.01m));
            RuleFor(x => x.ExpirationDate, x => x.Date.Future());
            RuleFor(x => x.Priority, x => false);
        }
    }
}
