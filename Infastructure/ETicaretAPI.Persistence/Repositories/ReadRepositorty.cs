﻿using EticaretAPI.Domain.Entities.Common;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepositorty<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepositorty(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)

        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return query;
        }


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)

        {
            var query = Table.Where(method);
         
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)

        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);

        }



        public async Task<T> GetByIdAsync(string id, bool tracking = true)

        {
            var query=Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
        }

      
    }
}