using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
using Zhouli.Enum;

namespace Zhouli.DBFactory
{
    public class DBConnectionFactory
    {
        /// <summary>
        /// 创建Connection
        /// </summary>
        /// <param name="strConnection">连接字符串</param>
        /// <param name="dataProvider">数据库类型</param>
        /// <returns></returns>
        public static IDbConnection CreateConnection(string strConnection, DataBaseType dataProvider)
        {
            IDbConnection iDbConnection = null;
            switch (dataProvider)
            {
                case DataBaseType.Oracle:
                    break;
                case DataBaseType.SqlServer:
                    iDbConnection = new SqlConnection(strConnection);
                    break;
                case DataBaseType.MySql:
                    iDbConnection = new MySqlConnection(strConnection);
                    break;
                default:
                    break;
            }
            iDbConnection.Open();
            return iDbConnection;
        }
    }
}
