-- 创建数据库
CREATE DATABASE  ZhouLi; -- --个人网站
USE ZhouLi;
-- ------------------------------------------------------------创建系统需要的表
 -- --用户表 
 CREATE TABLE Sys_User(
 UserId VARCHAR(36)  PRIMARY KEY NOT NULL ,-- --主键 用户id
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
 UserGroupId  VARCHAR(36) NULL,-- --所属用户组
 UserStatus INT  DEFAULT 1 NOT NULL,-- --用户状态(与Dict_UserStatus的id关联)
 CreateUserId  VARCHAR(36) NULL,-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME   NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 );
 -- --角色表
 CREATE TABLE Sys_Role(
 RoleId  VARCHAR(36) PRIMARY KEY NOT NULL  ,-- --主键 角色Id
 RoleName NVARCHAR(50) NOT NULL,-- --角色名
 CreateUserId  VARCHAR(36) NULL,-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME   NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 );

 -- --权限表
 CREATE TABLE Sys_Authority(
 AuthorityId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --主键
 AuthorityType INT NOT NULL,-- --权限类型
 CreateUserId  VARCHAR(36) NULL,-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 );
  -- --权限类型表
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId  VARCHAR(36)  PRIMARY KEY NOT NULL ,-- --主键Id
 AuthorityTypeName NVARCHAR(20) NOT NULL-- --权限类型名称
 );
 -- --用户角色关联表
 CREATE TABLE Sys_UrRelated(
 UrRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --主键
 UserId  VARCHAR(36) NOT NULL,-- --用户id
 RoleId  VARCHAR(36) NOT NULL-- --角色id
 );
  -- --角色权限关联表
 CREATE TABLE Sys_RaRelated(
 RaRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --主键
 RoleId  VARCHAR(36) NOT NULL,-- --角色id
 AuthorityId  VARCHAR(36) NOT NULL-- --权限id
 );
 -- --用户组表
 CREATE TABLE Sys_UserGroup(
 UserGroupId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --主键
 UserGroupName NVARCHAR(50) NOT NULL, -- --用户组名称
 ParentUserGroupId  VARCHAR(36) NULL,-- --父用户组id
 CreateUserId  VARCHAR(36) NULL,-- --创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  NOT NULL,-- --创建时间
 EditTime DATETIME  NULL ,-- --修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- --删除时间
 Note NVARCHAR(2048) NULL-- --备注
 );
--  ----用户与用户组关联表
--  -- CREATE TABLE Sys_UuRelated(
--  --UuRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--主键
--  --UserId uniqueidentifier NOT NULL, --用户id
--  --UserGroupId uniqueidentifier NOT NULL,--用户组id
--  --)
 -- --菜单表
 CREATE TABLE Sys_Menu(
 MenuId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- 主键
 MenuName NVARCHAR(50) NOT NULL,-- 菜单名称
 MenuIcon NVARCHAR(50) NULL,-- 菜单图标(只支持layui图标)
 MenuUrl VARCHAR(80) NULL,-- 菜单url
 MenuSort INT NOT NULL,-- 菜单排序号
 ParentMenuId  VARCHAR(36)   NULL,-- 父菜单id
 CreateUserId  VARCHAR(36) NULL,-- 创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  NOT NULL,-- 创建时间
 EditTime DATETIME  NULL ,-- 修改时间
 DeleteSign INT DEFAULT 1 NOT NULL,-- 1 未删除 2 已删除
 DeleteTime DATETIME NULL,-- 删除时间
 Note NVARCHAR(2048) NULL-- 备注
 );

 -- 权限菜单关联表
 CREATE TABLE Sys_AmRelated(
 AmRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- 主键
 AuthorityId  VARCHAR(36) NOT NULL,-- 权限id
 MenuId  VARCHAR(36) NOT NULL-- 菜单id
 );
 -- 用户组与角色关联表
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- 主键
 UserGroupId  VARCHAR(36) NOT NULL,-- 用户组id
 RoleId  VARCHAR(36) NOT NULL-- 角色id
 );
-- -------------------------------------------------------------------- 创建博客需要的表
-- 博客文章表
CREATE TABLE Blog_Article(
Article_Id INT auto_increment PRIMARY KEY NOT NULL,-- 主键
Article_Title NVARCHAR(50) NOT NULL,-- 博客文章标题
Article_Body TEXT NOT NULL,-- 博客文章内容
Article_Body_Markdown TEXT  NULL,-- 博客文章内容,
Article_SortValue INT DEFAULT 0 NOT NULL,-- 排序值,
CreateUserId  VARCHAR(36) NULL,-- 创建者ID(对应Sys_Users表UserId字段)
CreateTime DATETIME  NOT NULL,-- 创建时间
EditTime DATETIME  NULL ,-- 修改时间
DeleteSign INT DEFAULT 1 NOT NULL,-- 1 未删除 2 已删除
DeleteTime DATETIME NULL,-- 删除时间
Note NVARCHAR(2048) NULL-- 备注
);
-- 博客标签表
CREATE TABLE Blog_Lable(
Lable_Id INT auto_increment PRIMARY KEY NOT NULL,-- 博客标签编号(主键)
Lable_Name NVARCHAR(20) NOT NULL UNIQUE,-- 博客标签名称
Lable_SortValue INT DEFAULT 0 NOT NULL,-- 排序值,
Lable_ClickNum BIGINT DEFAULT 0 NOT NULL,-- 博客标签点击量
CreateUserId  VARCHAR(36) NULL,-- 创建者ID(对应Sys_Users表UserId字段)
CreateTime DATETIME  NOT NULL,-- 创建时间
EditTime DATETIME  NULL ,-- 修改时间
DeleteSign INT DEFAULT 1 NOT NULL,-- 1 未删除 2 已删除
DeleteTime DATETIME NULL,-- 删除时间
Note NVARCHAR(2048) NULL-- 备注
);
-- 标签关联表
CREATE TABLE Blog_Related(
Blog_RelatedId INT auto_increment PRIMARY KEY NOT NULL,
Related_Article_Id INT  NOT NULL,-- 博客文章Id
Related_Lable_Id INT NOT NULL-- 博客标签编号
);
-- 博客文章-查看信息表
CREATE TABLE Blog_ArticleSeeInfo
(
ArticleSeeInfo_ArticleId INT auto_increment PRIMARY KEY NOT NULL ,-- 博客文章Id
ArticleSeeInfo_ArticleBrowsingNum INT DEFAULT 0 NOT NULL,-- 博客文章浏览量
ArticleSeeInfo_ArticleLikeNum INT DEFAULT 0 NOT NULL,-- 博客文章点赞量
ArticleSeeInfo_ArticleCommentNum INT DEFAULT 0 NOT NULL-- 博客文章评论量
);
-- 博客 友情链接表
CREATE TABLE Blog_FriendshipLink
(
FriendshipLink_Id INT auto_increment PRIMARY KEY NOT NULL ,-- 自增id
FriendshipLink_Name NVARCHAR(40) NOT NULL,-- 站点名称
FriendshipLink_Url VARCHAR(40)  NOT NULL,-- 站点Url
FriendshipLink_Email VARCHAR(40) NOT NULL,-- 站长邮箱
FriendshipLink_SortValue INT DEFAULT 0 NOT NULL,-- 排序值,
FriendshipLink_Sfsh INT DEFAULT 0 NOT NULL,-- 是否审核(1-已审核 0-未审核)
CreateUserId  VARCHAR(36) NULL,-- 创建者ID(对应Sys_Users表UserId字段)
CreateTime DATETIME  NOT NULL,-- 创建时间
EditTime DATETIME  NULL ,-- 修改时间
DeleteSign INT DEFAULT 1 NOT NULL,-- 1 未删除 2 已删除
DeleteTime DATETIME NULL,-- 删除时间
Note NVARCHAR(2048) NULL-- 备注
);
-- 博客 首页导航图表
CREATE TABLE Blog_NavigationImg
(
NavigationImg_Id INT auto_increment PRIMARY KEY NOT NULL ,-- 自增id(主键)
NavigationImg_Url VARCHAR(200) NOT NULL,-- 图片Url
NavigationImg_SortValue INT DEFAULT 0 NOT NULL,-- 排序值,
NavigationImg_Describe NVARCHAR(2048) DEFAULT '0' NOT NULL,-- 描述
NavigationImg_IsEnable INT DEFAULT '1' NOT NULL,-- 是否启用(1启用,0不启用)
CreateUserId  VARCHAR(36) NULL,-- 创建者ID(对应Sys_Users表UserId字段)
CreateTime DATETIME  NOT NULL,-- 创建时间
EditTime DATETIME  NULL ,-- 修改时间
DeleteSign INT DEFAULT 1 NOT NULL,-- 1 未删除 2 已删除
DeleteTime DATETIME NULL,-- 删除时间
Note NVARCHAR(2048) NULL-- 备注
);