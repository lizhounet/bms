using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Zhouli.BLL.Interface
{
    public interface IBaseBLL<T> where T : class, new()
    {
        bool Add(T t);
        bool AddRange(IEnumerable<T> t);
        bool Delete(T t);
        bool Update(T t);
        int ExecuteSql(string sql, SqlParameter parameter);
        IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda);

    }
}
