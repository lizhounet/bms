using Zhouli.BLL.Interface;
using Zhouli.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zhouli.BLL.Implements
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class, new()
    {
        private IBaseDAL<T> Dal { get; set; }
        public BaseBLL(IBaseDAL<T> Dal)
        {
            this.Dal = Dal;
        }
        public bool Add(T t)
        {
            
            return Dal.Add(t)>0;
        }
        public bool Delete(T t)
        {
            
            return Dal.Delete(t)>0;
        }
        public bool Update(T t)
        {
            
            return Dal.Update(t)>0;
        }
        public T GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }
    }
}
