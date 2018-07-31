#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/14 19:40:48 
 * 当前版本：1.0.0.1 
 *  
 * 描述说明： 
 * 
 * 修改历史： 
 * 
***************************************************************** 
 * Copyright @ ZhouLi 2018 All rights reserved 
 *┌──────────────────────────────────┐
 *│　此技术信息周黎的机密信息，未经本人书面同意禁止向第三方披露．　│
 *│　版权所有：周黎 　　　　　　　　　　　　　　│
 *└──────────────────────────────────┘
*****************************************************************/
#endregion
using System.Data;
using System.Data.SqlClient;

namespace Zhouli.DAL
{

    /// <summary>
    /// Dapper操作数据库上下文类
    /// </summary>
    public class DapperContext
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private readonly string sqlConnection;
        /// <summary>
        /// 数据库类型(1=sqlserver,2=mysql)
        /// </summary>
        private readonly string dataBaseType;
        public DapperContext(string sqlConnection, string dataBaseType)
        {
            this.sqlConnection = sqlConnection;
            this.dataBaseType = dataBaseType;
        }
        private static IDbConnection conn;
        public IDbConnection GetConnection
        {
            get
            {
                IDbConnection conn = null;
                if (dataBaseType == "0")
                    conn = new SqlConnection(sqlConnection);
                else if (dataBaseType == "1")
                    conn = new SqlConnection(sqlConnection);
                conn.Open();
                return conn;
            }
        }

    }
}
