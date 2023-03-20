using EticaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public string Descripton { get; set; }
        public string Adress { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }

    }
}
