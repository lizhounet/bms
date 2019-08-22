using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zhouli.Common.Expansion;

namespace ZhouliGenerateCode
{
    public class CreateCode
    {
        private static List<string> listBLLClass;
        private static List<string> listDALClass;
        private static string strPathDAL = $"{AppContext.BaseDirectory}../../../../Zhouli.DAL/";
        private static string strPathBLL = $"{AppContext.BaseDirectory}../../../../Zhouli.BLL/";
        /// <summary>
        /// 首次读取BLL，DAL下已经生成的类
        /// </summary>
        static CreateCode()
        {
            DirectoryInfo directoryInfoDAL = new DirectoryInfo($"{strPathDAL}Interface");
            listDALClass = directoryInfoDAL.GetFiles().Select(t => t.Name).ToList();
            DirectoryInfo directoryInfoBLL = new DirectoryInfo($"{strPathBLL}Interface");
            listBLLClass = directoryInfoBLL.GetFiles().Select(t => t.Name).ToList();
        }
        /// <summary>
        /// 创建BLL层代码
        /// </summary>
        /// <param name="ModelName"></param>
        public void CreateBLL(string ModelName)
        {
            if (!(listBLLClass.Count(t => t.Contains(ModelName)) > 0))
            {
                #region 生成Interface
                StringBuilder strBLLInterface = new StringBuilder();
                using (FileStream fileStream = new FileStream($"{strPathBLL}Interface/I{ModelName}BLL.cs", FileMode.CreateNew, FileAccess.Write))
                {
                    strBLLInterface.AppendLine("using System;");
                    strBLLInterface.AppendLine("using System.Collections.Generic;");
                    strBLLInterface.AppendLine("using System.Text;");
                    strBLLInterface.AppendLine("using Zhouli.DbEntity.Models;");
                    strBLLInterface.AppendLine("");
                    strBLLInterface.AppendLine("namespace Zhouli.BLL.Interface");
                    strBLLInterface.AppendLine("{");
                    strBLLInterface.AppendLine($"   public interface I{ModelName}BLL : IBaseBLL<{ModelName}>");
                    strBLLInterface.AppendLine("    {}");
                    strBLLInterface.AppendLine("}");
                    byte[] buffer = Encoding.Default.GetBytes(strBLLInterface.ToString());
                    fileStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine($"I{ModelName}BLL.cs 生成成功!");
                }
                #endregion
                #region 生成Implements
                StringBuilder strBLLImplements = new StringBuilder();
                using (FileStream fileStream = new FileStream($"{strPathBLL}Implements/{ModelName}BLL.cs", FileMode.Create, FileAccess.Write))
                {
                    string strModelNameFirstCharLower = ModelName.FirstCharToLower();
                    strBLLImplements.AppendLine("using System;");
                    strBLLImplements.AppendLine("using System.Collections.Generic;");
                    strBLLImplements.AppendLine("using System.Text;");
                    strBLLImplements.AppendLine("using Zhouli.BLL.Interface;");
                    strBLLImplements.AppendLine("using Zhouli.DAL.Interface;");
                    strBLLImplements.AppendLine("using Zhouli.DbEntity.Models;");
                    strBLLImplements.AppendLine("");
                    strBLLImplements.AppendLine("namespace Zhouli.BLL.Implements");
                    strBLLImplements.AppendLine("{");
                    strBLLImplements.AppendLine($"   public class {ModelName}BLL : BaseBLL<{ModelName}>, I{ModelName}BLL");
                    strBLLImplements.AppendLine("    {");
                    strBLLImplements.AppendLine($"        private readonly I{ModelName}DAL _{strModelNameFirstCharLower};");
                    strBLLImplements.AppendLine("        /// <summary>");
                    strBLLImplements.AppendLine($"        /// 用于实例化父级，{strModelNameFirstCharLower}");
                    strBLLImplements.AppendLine($"        /// <param name=\"{strModelNameFirstCharLower}\"></param>");
                    strBLLImplements.AppendLine($"        public {ModelName}BLL(I{ModelName}DAL {strModelNameFirstCharLower}) : base({strModelNameFirstCharLower})");
                    strBLLImplements.AppendLine("        {");
                    strBLLImplements.AppendLine($"            this._{strModelNameFirstCharLower} = {strModelNameFirstCharLower};");
                    strBLLImplements.AppendLine("        }");
                    strBLLImplements.AppendLine("    }");
                    strBLLImplements.AppendLine("}");
                    byte[] buffer = Encoding.Default.GetBytes(strBLLImplements.ToString());
                    fileStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine($"{ModelName}BLL.cs 生成成功!");
                }
                #endregion
            }

        }
        /// <summary>
        /// 创建DAL层代码
        /// </summary>
        /// <param name="ModelName"></param>
        public void CreateDAL(string ModelName)
        {
            if (!(listDALClass.Count(t => t.Contains(ModelName)) > 0))
            {
                #region 生成Interface
                StringBuilder strDALInterface = new StringBuilder();
                using (FileStream fileStream = new FileStream($"{strPathDAL}Interface/I{ModelName}DAL.cs", FileMode.CreateNew, FileAccess.Write))
                {
                    strDALInterface.AppendLine("using System;");
                    strDALInterface.AppendLine("using System.Collections.Generic;");
                    strDALInterface.AppendLine("using System.Text;");
                    strDALInterface.AppendLine("using Zhouli.DbEntity.Models;");
                    strDALInterface.AppendLine("");
                    strDALInterface.AppendLine("namespace Zhouli.DAL.Interface");
                    strDALInterface.AppendLine("{");
                    strDALInterface.AppendLine($"   public interface I{ModelName}DAL : IBaseDAL<{ModelName}>");
                    strDALInterface.AppendLine("    {}");
                    strDALInterface.AppendLine("}");
                    byte[] buffer = Encoding.Default.GetBytes(strDALInterface.ToString());
                    fileStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine($"I{ModelName}DAL.cs 生成成功!");
                }
                #endregion
                #region 生成Implements
                StringBuilder strDALImplements = new StringBuilder();
                using (FileStream fileStream = new FileStream($"{strPathDAL}Implements/{ModelName}DAL.cs", FileMode.Create, FileAccess.Write))
                {
                    string strModelNameFirstCharLower = ModelName.FirstCharToLower();
                    strDALImplements.AppendLine("using System;");
                    strDALImplements.AppendLine("using System.Collections.Generic;");
                    strDALImplements.AppendLine("using System.Text;");
                    strDALImplements.AppendLine("using System.Data;");
                    strDALImplements.AppendLine("using Zhouli.DAL.Interface;");
                    strDALImplements.AppendLine("using Zhouli.DbEntity.Models;");
                    strDALImplements.AppendLine("");
                    strDALImplements.AppendLine("namespace Zhouli.DAL.Implements");
                    strDALImplements.AppendLine("{");
                    strDALImplements.AppendLine($"   public class {ModelName}DAL : BaseDAL<{ModelName}>, I{ModelName}DAL");
                    strDALImplements.AppendLine("    {");
                    strDALImplements.AppendLine($"        public {ModelName}DAL(ZhouLiContext db, IDbConnection dbConnection) : base(db, dbConnection)");
                    strDALImplements.AppendLine("        {");
                    strDALImplements.AppendLine("        }");
                    strDALImplements.AppendLine("    }");
                    strDALImplements.AppendLine("}");
                    byte[] buffer = Encoding.Default.GetBytes(strDALImplements.ToString());
                    fileStream.Write(buffer, 0, buffer.Length);
                    Console.WriteLine($"{ModelName}DAL.cs 生成成功!");
                }
                #endregion
            }
        }
    }
}
