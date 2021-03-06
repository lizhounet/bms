﻿using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SqlClient;

namespace Zhouli.BLL.Implements
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        protected IBaseDAL<T> Dal { get; set; }
        public BaseBLL(IBaseDAL<T> Dal)
        {
            this.Dal = Dal;
        }
        public bool Add(T t)
        {
            Dal.Add(t);
            return Dal.SaveChanges();
        }
        public bool AddRange(IEnumerable<T> t)
        {
            Dal.AddRange(t);
            return Dal.SaveChanges();
        }
        public bool Delete(T t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }
        public bool Delete(IEnumerable<T> t)
        {
            Dal.Delete(t);
            return Dal.SaveChanges();
        }
        public bool Delete(Expression<Func<T, bool>> whereLambda)
        {
            Dal.Delete(whereLambda);
            return Dal.SaveChanges();
        }
        public bool Update(T t)
        {
            Dal.Update(t);
            return Dal.SaveChanges();
        }
       // BLL层此方法屏蔽掉,避免BLL层写sql
        //public int ExecuteSql(string sql, SqlParameter parameter = null)
        //{
        //    return Dal.ExecuteSql(sql, parameter);
        //}
        public int GetCount(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetCount(whereLambda);
        }
        public List<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModels(whereLambda).ToList();
        }

        public List<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> orderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, orderByLambda, whereLambda).ToList();
        }

       
        //BLL层此方法屏蔽掉,避免BLL层写sql
        //public IEnumerable<T> SqlQuery(string sql)
        //{
        //    return Dal.SqlQuery<T>(sql);
        //}
    }
}
