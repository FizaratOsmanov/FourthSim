﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sim.DAL.Contexts;
using Sim.DAL.Models;
using Sim.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sim.DAL.Repositories.Implementations
{
    public class Repository<T>:IRepository<T> where T : BaseEntity, new ()
    {
        readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public Task<T> GetByConditionAsync(Expression<Func<T, bool>> condition)
        {
            return Table.FirstOrDefaultAsync(condition);
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await Table.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }


    }
}
