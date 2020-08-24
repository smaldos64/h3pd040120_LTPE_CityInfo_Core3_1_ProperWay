using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using LTPE_CityInfo_Core3_1_ProperWay_Data.Context;
using LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.DataManager
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CityInfoContext RepositoryContext { get; set; }

        public RepositoryBase(CityInfoContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public virtual T FindOne(int id)
        {
            return (this.RepositoryContext.Set<T>().Find(id));
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            //ParameterExpression s = Expression.Parameter(typeof(T));
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        //public virtual List<T> FindByCondition(Expression<Func<T, bool>> expression)
        //{
        //    //ParameterExpression s = Expression.Parameter(typeof(T));
        //    return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToList();
        //}

        public virtual void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.Save();
        }

        public virtual void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.Save();
        }

        public virtual void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.Save();
        }

        public virtual void Save()
        {
            int NumberOfObjectsSaved = -1;
            NumberOfObjectsSaved = this.RepositoryContext.SaveChanges();
        }
    }
}
