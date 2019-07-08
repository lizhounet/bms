using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Zhouli.DAL.Implements
{
    public class BaseDAL<T> where T : class, new()
    {

        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected readonly IConfiguration _configuration;
        protected readonly DbEntity.Models.ZhouLiContext _db;
        /// <summary>
        /// 构造函数依赖注入
        /// </summary>
        /// <param name="_db"></param>
        public BaseDAL(DbEntity.Models.ZhouLiContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        private IDbConnection conn;
        protected IDbConnection Connection
        {
            get
            {
                if (_configuration.GetConnectionString("dataBaseType") == "1")
                    conn = new SqlConnection(_configuration.GetConnectionString("MssqlConnection"));
                else if (_configuration.GetConnectionString("dataBaseType") == "2")
                    conn = new MySqlConnection(_configuration.GetConnectionString("MysqlConnection"));
                conn.Open();
                return conn;
            }
        }
        public void Add(T t)
        {
            _db.Set<T>().Add(t);
        }
        public void AddRange(IEnumerable<T> t)
        {
            _db.AddRange(t);
        }
        public void Delete(T t)
        {
            _db.Set<T>().Remove(t);
        }
        public void Delete(IEnumerable<T> t)
        {
            _db.Set<T>().RemoveRange(t);
        }
        public int GetCount(Expression<Func<T, bool>> WhereLambda)
        {
            return _db.Set<T>().Count(WhereLambda);
        }
        public void Update(T t)
        {
            //var newt = _db.Set<T>().First();
            //foreach (var item in newt.GetType().GetProperties())
            //{
            //    //传进来的属性值
            //    var pvalue = t.GetType().GetProperty(item.Name).GetValue(t, null);
            //    //属性类型的默认值
            //    var obj = t.GetType().GetProperty(item.Name).PropertyType.IsValueType ? Activator.CreateInstance(t.GetType().GetProperty(item.Name).PropertyType) : null;
            //    if (pvalue != obj)
            //        item.SetValue(newt, pvalue);
            //}
            _db.Set<T>().Update(t);
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Where(whereLambda);
        }
        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //是否升序
            if (isAsc)
            {
                return _db.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return _db.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }
        public int ExecuteSql(string sql, SqlParameter parameter = null)
        {
            if (parameter == null)
                return _db.Database.ExecuteSqlCommand(sql);
            else
                return _db.Database.ExecuteSqlCommand(sql, parameter);
        }
        public IEnumerable<TR> SqlQuery<TR>(string sql)
        {
            using (var conn = Connection)
            {
                return conn.Query<TR>(sql);
            }

        }
        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
