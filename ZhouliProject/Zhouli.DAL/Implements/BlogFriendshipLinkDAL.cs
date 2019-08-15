using Zhouli.DAL.Interface;
using Zhouli.DbEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Zhouli.DAL.Implements
{
    public class BlogFriendshipLinkDAL : BaseDAL<BlogFriendshipLink>, IBlogFriendshipLinkDAL
    {
        public BlogFriendshipLinkDAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)
        {
        }
    }
}
