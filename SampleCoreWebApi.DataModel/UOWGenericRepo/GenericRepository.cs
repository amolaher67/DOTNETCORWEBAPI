﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi.DataModel.UOWGenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext Context;

        public GenericRepository(DataContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual T Add(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return t;
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            Context.Set<T>().Add(t);
            await Context.SaveChangesAsync();
            return t;

        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            Context.Set<T>().Remove(entity);
            return await Context.SaveChangesAsync();
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = Context.Set<T>().Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(t);
                Context.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await Context.Set<T>().FindAsync(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(t);
                await Context.SaveChangesAsync();
            }
            return exist;
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        public virtual void Save()
        {

            Context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = Context.Set<T>().Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                Context.Dispose();
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
