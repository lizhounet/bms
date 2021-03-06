# 权限管理系统(正在持续开发后续功能)

#### 项目介绍
该系统是作者在学习.net core 途中练手做的项目,并想集成个人网站的后台管理
基于.net core sdk 2.1实现的权限管理平台


作者QQ:1021907330   
         
模块功能：用户列表、用户组列表、角色管理、菜单管理、权限管理、日志管理、集成七牛云存储       


初步权限管理基本实现

体验地址:http://demo.zhouli.info/
账号:test 密码:123456
操作步骤:                    
    1.添加用户(为用户选择用户组:可不选)                                                                                            
    2.添加角色,为角色赋予相应的权限                                                    
    3.为角色分配用户,用户组          
#### 软件架构

系统采用.net core 2.1 进行开发            
    1. 开发框架采用三层架构进行搭建(DAL,BLL,UI),采用.net core 自带的依赖注入框架进行类的耦合分离 
                 
    2. 数据库采用EF Core,Dapper(这里为什么用了两个ORM我解释一下,因为我喜欢ORM强大的映射功能,同时喜欢写原生的Sql,又想用EF强大的数据库管理,比如根据数据库自动生成实体类 这点Dapper做不到)     
       
    3. 服务层使用与UI层采用DTO进行传输,采用AutoMapper做实体与DTO互换   
             
    4. 系统日志采用Log4net 进行记录         
   
    5. 前端主要采用layui,Jquery                 
            
        
#### 开发阶段

后台管理系统开发日志

2018.05.26         
   1.项目框架初步搭建(.net core+ef core +sqlserver +三层架构设计模式)      
  
2018.06.03        
   1.后台主页集成(主要采用layui)        
   2.后台登录页面集成        
   3.require.js 使用            
   4.扩展.net core session 方法      
          
2018.06.04            
   1.增加依赖注入提供类(就不需要控制器需要多少个类就注入多少个实例,直接从提供类获取即可)        

2018.06.08    
   1.实现自动配置依赖注入    

2018.06.10        
   1.增加初始化权限管理关系表结构类    
   2.表结构字段一些更新    

2018.06.19                    
   1..netcore中AutoMapper的使用  
         
2018.06.21                            
   1.导航菜单根据用户权限动态加载展示            
   2..net core 缓存中间件以及gzip压缩中间件使用      
      
2018.06.24            
   1.用户增删改查                
   1.用户组增删改查       
     
2018.07.08        
   1.系统架构数据库访问层加入Dapper ORM框架(工作比较忙,更新比较慢)            
   2..net core 中Log4net的使用            
   3..net core mvc 全局异常过滤器使用       
     
2018.07.17            
   1.角色增删查改            
   2.实现AutoMapper自动映射实体与Dto转换关系      
   
2018.07.27                
   1.菜单管理增删改查            

2018.07.30                    
   1.角色的菜单权限分配                
   2.用户的角色分配管理 

2019.01.03                    
   1.项目目录名称修改               
   2.增加支持mysql数据库         
                              
