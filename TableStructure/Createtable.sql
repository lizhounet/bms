 --用户表
 CREATE TABLE Sys_Users(
 UserId uniqueidentifier DEFAULT newid() NOT NULL ,--主键 用户id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--用户帐号
 UserNikeName NVARCHAR(20),--用户昵称
 UserPwd NVARCHAR(50) DEFAULT substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32) NOT NULL,--用户密码
 UserSex int  NULL,--用户性别
 UserBirthday DATE  NULL,--用户出生年月日
 UserEmail VARCHAR(15)  NULL,--用户邮箱
 UserQQ VARCHAR(15)  NULL,--用户QQ
 UserWX VARCHAR(30)  NULL,--用户微信
 UserAvatar VARCHAR(150)  NULL,--用户头像
 UserPhone VARCHAR(11) NULL,--用户手机
 UserStatus INT  DEFAULT 1 NOT NULL,--用户状态(与Dict_UserStatus的id关联)
 UserCreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--创建时间
 UserEditTime DATETIME  ,--修改时间
 Note NVARCHAR(2048) NULL--备注
 )
 --用户状态表
 CREATE TABLE Dict_UserStatus(
 Id int identity(1,1) primary key NOT NULL ,--主键Id
 UserStatusName nvarchar(20) not null--用户状态名称
 )
 insert into Dict_UserStatus(UserStatusName) values('正常'),('停用');
 --角色表
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier DEFAULT newid() NOT NULL ,--主键 角色Id
 RoleName NVARCHAR(50) NOT NULL,--角色名
 Note NVARCHAR(2048) NULL--备注
 )
 --权限表
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier DEFAULT newid() NOT NULL ,--主键
 AuthorityType INT NOT NULL,--权限类型
 Note NVARCHAR(2048) NULL--备注
 )