﻿
using FilesManager.EF;
using FilesManager.Helpers;
using FilesManager.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilesManager.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
       
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
          
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id) => _context.Set<T>().Find(id); // Arrow Function

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> criteria) => _context.Set<T>().SingleOrDefault(criteria);
        public T Find(Expression<Func<T, bool>> criteria, Expression<Func<T, bool>> criteria2, string[] includes = null)
        {
            return _context.Set<T>().Where(criteria2).SingleOrDefault(criteria);
        }

          
        public T FindNoTraking(Expression<Func<T, bool>> criteria, string[] includes = null) => _context.Set<T>().AsNoTracking().SingleOrDefault(criteria);
        public T FindNoTraking(Expression<Func<T, bool>> criteria, Expression<Func<T, bool>> criteria2, string[] includes = null) => _context.Set<T>().Where(criteria).Where(criteria2).AsNoTracking().FirstOrDefault();
        public T FindNoTraking(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null) => _context.Set<T>().Where(criteria).OrderBy(orderBy).AsNoTracking().FirstOrDefault();

        public T FindNoTraking(Expression<Func<T, bool>> criteria, Expression<Func<T, bool>> criteria2,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending, string[] includes = null) => _context.Set<T>().Where(criteria).Where(criteria2).OrderBy(orderBy).AsNoTracking().FirstOrDefault();

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(criteria);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria) => await _context.Set<T>().SingleOrDefaultAsync(criteria);
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria) => _context.Set<T>().Where(criteria).ToList();
        
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);
           
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if(orderBy != null)
            {
                if(orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria) => await _context.Set<T>().Where(criteria).ToListAsync();
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public T Add(T entity)
        {
            //entity
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
            //entity.Property(propertyName).CurrentValue = someValue;
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            //_context.Set<T>().AsNoTracking().ExecuteUpdate(entity);
            _context.Update(entity);
            return entity;
        }
        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            return entities;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }

        public async Task<IEnumerable<T>> GetChildsAsync(Expression<Func<T, bool>> include , Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>()
                      .Include(include)
                      .Where(criteria).ToListAsync();
        }
        public bool isExist(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Any(criteria);
        }

        public bool isExist(Expression<Func<T, bool>> criteria, Expression<Func<T, bool>> criteria2)
        {
            return _context.Set<T>().Where(criteria2).Any(criteria);
        }

      


        /*
public async Task<string> ChildCoa(string HeadName, string HeadCode, string coa)
{
   if (HeadCode == "0") { coa += "<li class=\"jstree-open \">" + HeadName + ""; }
   else { coa += "<li><a href='javascript:' onclick=\"loadCoaData('" + HeadCode + "')\">" + HeadName + "</a>  "; }

   //if (HeadCode == 0 ) coa += "<li class=\"jstree-open \">" + HeadName + "";
   List<AccCoa> selected = await _context.AccCoa.Where(x => x.PHeadCode == HeadCode).ToListAsync();
   if (selected.Count > 0)
   {
       coa += "<ul>";
       foreach (var item in selected)
       {
          // coa += "<li><a href='javascript:' onclick=\"loadCoaData('" + item.HeadCode + "')\">" + item.HeadName + "</a></li>  ";
           await ChildCoa(item.HeadName, item.HeadCode, coa);
       }
       coa += "</ul>";
   }

   return coa;
}
*/
    }
}