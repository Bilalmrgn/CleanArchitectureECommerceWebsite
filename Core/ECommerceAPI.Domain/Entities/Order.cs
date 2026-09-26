using ECommerceAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }

        //order ve product arasında many to many ilişkisi vardır
        public ICollection<Product> Products { get; set; }

        //order ve customer arasında one to many ilişkisi vardır
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
