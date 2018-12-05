--创建数据库
CREATE DATABASE  ZhouLi; -- --个人网站
USE ZhouLi;
 -- --用户表 
 CREATE TABLE Sys_User(
 UserId CHAR(40)  NOT NULL PRIMARY KEY ,-- --主键 用户id
 UserName NVARCHAR(20) NOT NULL UNIQUE,-- --用户帐号
 UserNikeName NVARCHAR(20),-- --用户昵称
 UserPwd NVARCHAR(50)  NOT NULL,-- --用户密码
 UserSex INT DEFAULT 1 NULL,-- --用户性别 1男 2女
 UserBirthday DATE  NULL,-- --用户出生年月日
 UserEmail VARCHAR(50)  NULL,-- --用户邮箱
 UserQq VARCHAR(15)  NULL,-- --用户QQ
 UserWx VARCHAR(50)  NULL,-- --用户微信
 UserAvatar VARCHAR(150)  NULL,-- --用户头像
 UserPhone VARCHAR(11) NULL,-- --用户手机
 UserGroupId CHAR(40) NULL,-- --所属用户组
 UserStatus INT  DEFAULT 1 NOT NULL,-- --用户状态(与Dict_UserStatus的id关联)
 CreateUserId CHAR(40) ,-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME   NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 )
 -- --角色表
 CREATE TABLE Sys_Role(
 RoleId CHAR(40) PRIMARY KEY NOT NULL ,-- --主键 角色Id
 RoleName NVARCHAR(50) NOT NULL,-- --角色名
 CreateUserId CHAR(40),-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME   NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 )

 --权限表
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 AuthorityType INT NOT NULL,--权限类型
 CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(VARCHAR, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,--1 未删除 2 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )
  --权限类型表
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId INT identity(1,1) PRIMARY KEY NOT NULL ,--主键Id
 AuthorityTypeName NVARCHAR(20) NOT NULL,--权限类型名称
 )
 --用户角色关联表
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 UserId uniqueidentifier NOT NULL,--用户id
 RoleId uniqueidentifier NOT NULL--角色id
 )
  --角色权限关联表
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 RoleId uniqueidentifier NOT NULL,--角色id
 AuthorityId uniqueidentifier NOT NULL--权限id
 )
 --用户组表
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 UserGroupName NVARCHAR(50) NOT NULL, --用户组名称
  ParentUserGroupId uniqueidentifier NULL,--父用户组id
  CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(VARCHAR, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,--1 未删除 2 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )
 ----用户与用户组关联表
 -- CREATE TABLE Sys_UuRelated(
 --UuRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 --UserId uniqueidentifier NOT NULL, --用户id
 --UserGroupId uniqueidentifier NOT NULL,--用户组id
 --)
 --菜单表
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 MenuName NVARCHAR(50) NOT NULL,--菜单名称
 MenuIcon NVARCHAR(10) NULL,--菜单图标(只支持layui图标)
 MenuUrl VARCHAR(80) NULL,--菜单url
 MenuSort INT NOT NULL,--菜单排序号
 ParentMenuId uniqueidentifier DEFAULT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)   NULL,--父菜单id
 CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(VARCHAR, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,--1 未删除 2 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )

 --权限菜单关联表
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 AuthorityId uniqueidentifier NOT NULL,--权限id
 MenuId uniqueidentifier NOT NULL--菜单id
 )
 --用户组与角色关联表
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
 UserGroupId uniqueidentifier NOT NULL,--用户组id
 RoleId uniqueidentifier NOT NULL--角色id
 )

--博客文章表
CREATE TABLE Blog_Article(
Article_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--主键
Article_Title NVARCHAR(50) NOT NULL,--博客文章标题
Article_Body NTEXT NOT NULL,--博客文章内容
Article_Body_Markdown NTEXT  NULL,--博客文章内容,
Article_SortValue INT DEFAULT 0 NOT NULL,--排序值,
Article_CreateTime DATETIME  DEFAULT CONVERT(VARCHAR, getdate(), 120 ) NOT NULL,--创建时间
Article_UserId UNIQUEIDENTIFIER  NOT NULL,--发布用户id
Article_UserNikeName UNIQUEIDENTIFIER  NOT NULL,--发布用户昵称
Article_Note NVARCHAR(2048) NULL--备注
)
--博客标签表
CREATE TABLE Blog_Lable(
Lable_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,--博客标签编号(主键)
Lable_Name NVARCHAR(20) NOT NULL UNIQUE,--博客标签名称
Lable_SortValue INT DEFAULT 0 NOT NULL,--排序值,
Lable_ClickNum BIGINT DEFAULT 0 NOT NULL,--博客标签点击量
Lable_CreateTime DATETIME  DEFAULT CONVERT(VARCHAR, getdate(), 120 ) NOT NULL,--创建时间
Lable_Note NVARCHAR(2048) NULL--备注
)
--标签关联表
CREATE TABLE Blog_Related(
Related_Article_Id INT  NOT NULL,--博客文章Id
Related_Lable_Id INT NOT NULL--博客标签编号
)
--博客文章-查看信息表
CREATE TABLE Blog_ArticleSeeInfo
(
ArticleSeeInfo_ArticleId INT PRIMARY KEY NOT NULL ,--博客文章Id
ArticleSeeInfo_ArticleBrowsingNum INT DEFAULT 0 NOT NULL,--博客文章浏览量
ArticleSeeInfo_ArticleLikeNum INT DEFAULT 0 NOT NULL,--博客文章点赞量
ArticleSeeInfo_ArticleCommentNum INT DEFAULT 0 NOT NULL--博客文章评论量
)
--博客 友情链接表
CREATE TABLE Blog_FriendshipLink
(
FriendshipLink_Id INT PRIMARY KEY NOT NULL ,--自增id
FriendshipLink_Name NVARCHAR(40) NOT NULL,--站点名称
FriendshipLink_Url INT DEFAULT 0 NOT NULL,--站点Url
FriendshipLink_Email INT DEFAULT 0 NOT NULL,--站长邮箱
FriendshipLink_SortValue INT DEFAULT 0 NOT NULL,--排序值,
FriendshipLink_Sfsh INT DEFAULT 0 NOT NULL--是否审核(1-已审核 0-未审核)
)
--博客 首页导航图表
CREATE TABLE Blog_NavigationImg
(
NavigationImg_Id INT PRIMARY KEY NOT NULL ,--自增id(主键)
NavigationImg_Url VARCHAR(200) NOT NULL,--图片Url
NavigationImg_SortValue INT DEFAULT 0 NOT NULL,--排序值,
NavigationImg_Describe INT DEFAULT '0' NOT NULL--描述
)