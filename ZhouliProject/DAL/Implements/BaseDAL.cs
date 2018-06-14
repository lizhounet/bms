using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using LambdaToSQL;
using System.Text;

namespace Zhouli.DAL.Implements
{
    public class BaseDAL<T> where T : class, new()
    {

        /// <summary>
        /// 数据库上下文
        /// </summary>
        private DapperContext db;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="db"></param>
        public BaseDAL(DapperContext db)
        {
            this.db = db;
        }
        public int Add(T t)
        {
            StringBuilder builder = new StringBuilder(10);
            var type = t.GetType();
            builder.AppendLine($"INERT INTO {type.FullName} (");
            builder.AppendLine($"{string.Join(",", type.GetProperties().Select(q => q.Name).ToArray())} ) VALUES(");
            builder.AppendLine($" {string.Join("','", type.GetProperties().Select(q => q.GetValue(t, null)).ToArray())} )");
            using (var con = db.GetConnection)
            {
                return con.Execute(builder.ToString(), t);
            }
        }
        public int Delete(T t)
        {
            using (var con = db.GetConnection)
            {
                // con.Insert(t);
                return 1;
            }
        }
        public int Update(T t)
        {
            using (var con = db.GetConnection)
            {
                //con.Update(t);
                return 1;
            }
        }
        public IEnumerable<T> GetModelList(Expression<Func<T, bool>> whereLambda)
        {
            using (var con = db.GetConnection)
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.Add(u => u.Where(whereLambda));
                return con.Query<T>($" SELECT * FROM {typeof(T).FullName} " +
                    $"{lambda.Where() }");
            }
        }
        public T GetModels(Expression<Func<T, bool>> whereLambda)
        {
            using (var con = db.GetConnection)
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.Add(u => u.Where(whereLambda));
                return con.Query<T>($" SELECT * FROM {typeof(T).FullName} " +
                    $"{lambda.Where() }").FirstOrDefault();
            }
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> whereLambda)
        {
            using (var con = db.GetConnection)
            {
                return null;
            }
        }
        //public IQueryable<T> FromSql(String sql, params object[] parameters)
        //{
        //    if (parameters.Length > 0)
        //        return db.Set<T>().FromSql(sql, parameters);
        //    else
        //        return db.Set<T>().FromSql(sql);
        //}
        //public bool SaveChanges()
        //{
        //    return db.SaveChanges() > 0;
        //}
    }
}
