using EticaretAPI.Domain.Entities;
using EticaretAPI.Domain.Entities.Common;
using EticaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser,AppRole, string>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker : Entitiyler üzerinde yapılan değişiklerin yada yeni eklemelerde verinin yakalanmasını sağlar Örn: veri eklerken createddate time ını otomatık olarak ekler..

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                 _ = item.State switch
                {
                    EntityState.Added=>item.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified=>item.Entity.UpdatedDate=DateTime.Now
                };

            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
