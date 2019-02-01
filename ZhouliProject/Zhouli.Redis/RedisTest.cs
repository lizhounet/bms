using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Zhouli.Redis
{
    public class RedisTest
    {
        public void test()
        {
            ////初始化 RedisHelper
            RedisHelper.Initialization(new CSRedis.CSRedisClient("127.0.0.1:6379,password=123,defaultDatabase=1,poolsize=50,ssl=false,writeBuffer=10240"));
            RedisHelper.Set("phonekc", 1);//设置库存
            RedisHelper.Set("phoneren", 0);//初始化参加活动的人数
            int phonekc = RedisHelper.Get<int>("phonekc");//获取库存
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 10000; i++)
            {
                tasks.Add(Task.Factory.StartNew((p) =>
                {
                    var count = RedisHelper.IncrBy("phoneren");

                    if (count <= phonekc)
                    {
                        Console.WriteLine($"恭喜您{p}抢到Iphone");
                        //抢到的用户
                        RedisHelper.RPush("1111", p);
                    }
                }, i));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"抢到Iphone共计{RedisHelper.LLen("1111") }人");
            Console.ReadKey();
        }
    }
}
