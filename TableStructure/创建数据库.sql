--创建数据库
CREATE DATABASE  ZhouLi; --个人网站
use ZhouLi;
 --用户表 
 CREATE TABLE Sys_User(
 UserId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键 用户id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--用户帐号
 UserNikeName NVARCHAR(20),--用户昵称
 UserPwd NVARCHAR(50) DEFAULT upper(substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32)) NOT NULL,--用户密码
 UserSex int  NULL,--用户性别
 UserBirthday DATE  NULL,--用户出生年月日
 UserEmail VARCHAR(50)  NULL,--用户邮箱
 UserQQ VARCHAR(15)  NULL,--用户QQ
 UserWX VARCHAR(50)  NULL,--用户微信
 UserAvatar VARCHAR(150)  NULL,--用户头像
 UserPhone VARCHAR(11) NULL,--用户手机
 UserStatus INT  DEFAULT 1 NOT NULL,--用户状态(与Dict_UserStatus的id关联)
 CreateUserId uniqueidentifier ,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign int DEFAULT 0 not null,--0 未删除 1 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )
 --用户状态表
 CREATE TABLE Dict_UserStatus(
 UserStatusId int identity(1,1) primary key NOT NULL ,--主键Id
 UserStatusName nvarchar(20) not null--用户状态名称
 )
 --角色表
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键 角色Id
 RoleName NVARCHAR(50) NOT NULL,--角色名
 CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign int DEFAULT 0 not null,--0 未删除 1 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )

 --权限表
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 AuthorityType INT NOT NULL,--权限类型
 CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign int DEFAULT 0 not null,--0 未删除 1 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )
  --权限类型表
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId int identity(1,1) primary key NOT NULL ,--主键Id
 AuthorityTypeName nvarchar(20) not null,--权限类型名称
 )
 --用户角色关联表
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 UserId uniqueidentifier NOT NULL,--用户id
 RoleId uniqueidentifier NOT NULL--角色id
 )
  --角色权限关联表
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 RoleId uniqueidentifier NOT NULL,--角色id
 AuthorityId uniqueidentifier NOT NULL--权限id
 )
 --用户组表
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 UserGroupName NVARCHAR(50) NOT NULL, --用户组名称
  ParentUserGroupId uniqueidentifier NULL,--父用户组id
  CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign int DEFAULT 0 not null,--0 未删除 1 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )
 --用户与用户组关联表
  CREATE TABLE Sys_UuRelated(
 UuRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 UserId uniqueidentifier NOT NULL, --用户id
 UserGroupId uniqueidentifier NOT NULL,--用户组id
 )
 --菜单表
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 MenuName NVARCHAR(50) NOT NULL,--菜单名称
 MenuIcon NVARCHAR(10) NULL,--菜单图标(只支持layui图标)
 MenuUrl varchar(80) NULL,--菜单url
 ParentMenuId uniqueidentifier NULL,--父菜单id
 CreateUserId uniqueidentifier,--创建者ID(对应Sys_Users表UserId字段)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 EditTime DATETIME  NULL ,--修改时间
 DeleteSign int DEFAULT 0 not null,--0 未删除 1 已删除
 DeleteTime DATETIME NULL,--删除时间
 Note NVARCHAR(2048) NULL--备注
 )

 --权限菜单关联表
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 AuthorityId uniqueidentifier NOT NULL,--权限id
 MenuId uniqueidentifier NOT NULL--菜单id
 )
 --用户组与角色关联表
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--主键
 UserGroupId uniqueidentifier NOT NULL,--用户组id
 RoleId uniqueidentifier NOT NULL--角色id
 )
