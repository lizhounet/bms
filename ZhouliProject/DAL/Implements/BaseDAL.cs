using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zhouli.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Zhouli.Entity.Models;

namespace Zhouli.DAL.Implements
{
    public class BaseDAL<T> where T : class, new()
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        private ZhouLiContext _ZhouLiContext;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="ZhouLiContext"></param>
        public BaseDAL(ZhouLiContext ZhouLiContext)
        {
            this._ZhouLiContext = ZhouLiContext;
        }
        public void Add(T t)
        {
            _ZhouLiContext.Set<T>().Add(t);
        }
        public void Delete(T t)
        {
            _ZhouLiContext.Set<T>().Remove(t);
        }

        public void Update(T t)
        {
            _ZhouLiContext.Set<T>().Attach(t);
            _ZhouLiContext.Entry<T>(t).State = EntityState.Modified;
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return _ZhouLiContext.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return _ZhouLiContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _ZhouLiContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public bool SaveChanges()
        {
            return _ZhouLiContext.SaveChanges() > 0;
        }
    }
}
