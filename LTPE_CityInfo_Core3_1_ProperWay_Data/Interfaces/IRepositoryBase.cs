using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LTPE_CityInfo_Core3_1_ProperWay_Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        T FindOne(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //List<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

        // LTPE funktionalitet adderet herunder !!!
        void EnableLazyLoading();

        void DisableLazyLoading();
    }
}
