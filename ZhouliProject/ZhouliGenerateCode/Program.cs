using System;
using System.IO;
using System.Linq;

namespace ZhouliGenerateCode
{
    class Program
    {
        static void Main(string[] args)
        {

            //扫描
            Console.WriteLine("正在自动生成BLL,DAL层代码,请稍候......");
            DirectoryInfo directoryInfo = new DirectoryInfo($"{AppContext.BaseDirectory}../../../../Zhouli.DbEntity/Models");
            FileInfo[] modelFileInfos = directoryInfo.GetFiles().Where(t => !t.Name.Equals("ZhouLiContext.cs")).ToArray();
            CreateCode createCode = new CreateCode();
            foreach (var fileInfo in modelFileInfos)
            {
                createCode.CreateDAL(fileInfo.Name.Replace(".cs", ""));
                createCode.CreateBLL(fileInfo.Name.Replace(".cs", ""));
            }
            Console.WriteLine("全部生成成功!");
            Console.ReadKey();
        }
    }
}
