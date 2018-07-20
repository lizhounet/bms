#region 版权声明
/**************************************************************** 
 * 作    者：周黎 
 * CLR 版本：4.0.30319.42000 
 * 创建时间：2018/6/19 20:58:41 
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
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Zhouli.DbEntity.Models;

namespace Zhouli.BLL
{

    /// <summary>
    /// model转换dto配置
    /// </summary>
    public class ZhouliMapper
    {
        /// <summary>
        /// 配置DTO映射关系
        /// </summary>
        public static void Initialize()
        {
            //利用反射动态映射
            Mapper.Initialize(MappingAutoMapper);
        }
        private static void MappingAutoMapper(IMapperConfigurationExpression cfg)
        {
            string[] assemblyNames = { "Zhouli.BLL", "Zhouli.DbEntity" };
            //先找出Model所有实体类
            List<Type> modelTypes = Assembly.Load("Zhouli.DbEntity").GetTypes().Where(t=>t.Namespace.Equals("Zhouli.DbEntity.Models")).ToList();
            //model对应的Dto实体(注意:这里我做了命名约定,所有对应实体的Dto对象都以Dto结尾)
            List<Type> modelDtoTypes = Assembly.Load("Zhouli.BLL").GetTypes().Where(t => t.Name.EndsWith("Dto")).ToList();
            foreach (var dtoType in modelDtoTypes)
            {
                var modelType = modelTypes.Where(t => t.Name.StartsWith(dtoType.Name.Replace("Dto", ""))).First();
                cfg.CreateMap(dtoType, modelType);
                cfg.CreateMap(modelType, dtoType);
            }
        }
    }
}
