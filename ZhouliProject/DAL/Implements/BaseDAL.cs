using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Entity.Models;

namespace DAL.Implements
{
    public class BaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private GRWEBSITEContext _GRWEBSITEContext;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="GRWEBSITEContext"></param>
        public BaseDAL(GRWEBSITEContext GRWEBSITEContext)
        {
            this._GRWEBSITEContext = GRWEBSITEContext;
        }
        public void Add(T t)
        {
            _GRWEBSITEContext.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            _GRWEBSITEContext.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            _GRWEBSITEContext.Set<T>().Attach(t);
            _GRWEBSITEContext.Entry<T>(t).State = EntityState.Modified;
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return _GRWEBSITEContext.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return _GRWEBSITEContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _GRWEBSITEContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public bool SaveChanges()
        {
            return _GRWEBSITEContext.SaveChanges() > 0;
        }
    }
}
