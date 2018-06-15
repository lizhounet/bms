using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Zhouli.DAL.Implements
{
    public class BaseDAL<T> where T : class, new()
    {

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private Zhouli.DbEntity.Models.ZhouLiContext db;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="db"></param>
        public BaseDAL(Zhouli.DbEntity.Models.ZhouLiContext db)
        {
            this.db = db;
        }
        public void Add(T t)
        {
            db.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            db.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            db.Set<T>().Update(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return db.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return db.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public bool SaveChanges()
        {
            return db.SaveChanges() > 0;
        }
    }
}
