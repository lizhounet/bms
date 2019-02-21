

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    /// <summary>
    /// 每日一句实体
    /// </summary>
    public class MryjModel
    {
        public int ResultCode { get; set; }
        public string ErrCode { get; set; }
        public Body Body { get; set; }
    }

    public class Body
    {
        public int id { get; set; }
        public string vol { get; set; }
        public string img_url { get; set; }
        public string img_author { get; set; }
        public string img_kind { get; set; }
        public string date { get; set; }
        public string url { get; set; }
        public string word { get; set; }
        public string word_from { get; set; }
        public int word_id { get; set; }
    }
}
