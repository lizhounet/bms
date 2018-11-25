<<<<<<< HEAD:TableStructure/sqlserver.sql
--´´½¨Êı¾İ¿â
CREATE DATABASE  ZhouLi; --¸öÈËÍøÕ¾
use ZhouLi;
 --ÓÃ»§±í 
 CREATE TABLE Sys_User(
 UserId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü ÓÃ»§id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--ÓÃ»§ÕÊºÅ
 UserNikeName NVARCHAR(20),--ÓÃ»§êÇ³Æ
 UserPwd NVARCHAR(50) DEFAULT upper(substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32)) NOT NULL,--ÓÃ»§ÃÜÂë
 UserSex int DEFAULT 1 NULL,--ÓÃ»§ĞÔ±ğ 1ÄĞ 2Å®
 UserBirthday DATE  NULL,--ÓÃ»§³öÉúÄêÔÂÈÕ
 UserEmail VARCHAR(50)  NULL,--ÓÃ»§ÓÊÏä
 UserQq VARCHAR(15)  NULL,--ÓÃ»§QQ
 UserWx VARCHAR(50)  NULL,--ÓÃ»§Î¢ĞÅ
 UserAvatar VARCHAR(150)  NULL,--ÓÃ»§Í·Ïñ
 UserPhone VARCHAR(11) NULL,--ÓÃ»§ÊÖ»ú
 UserGroupId uniqueidentifier NULL,--ËùÊôÓÃ»§×é
 UserStatus INT  DEFAULT 1 NOT NULL,--ÓÃ»§×´Ì¬(ÓëDict_UserStatusµÄid¹ØÁª)
 CreateUserId uniqueidentifier ,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
 --½ÇÉ«±í
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü ½ÇÉ«Id
 RoleName NVARCHAR(50) NOT NULL,--½ÇÉ«Ãû
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )

 --È¨ÏŞ±í
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 AuthorityType INT NOT NULL,--È¨ÏŞÀàĞÍ
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
  --È¨ÏŞÀàĞÍ±í
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId int identity(1,1) primary key NOT NULL ,--Ö÷¼üId
 AuthorityTypeName nvarchar(20) not null,--È¨ÏŞÀàĞÍÃû³Æ
 )
 --ÓÃ»§½ÇÉ«¹ØÁª±í
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserId uniqueidentifier NOT NULL,--ÓÃ»§id
 RoleId uniqueidentifier NOT NULL--½ÇÉ«id
 )
  --½ÇÉ«È¨ÏŞ¹ØÁª±í
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 RoleId uniqueidentifier NOT NULL,--½ÇÉ«id
 AuthorityId uniqueidentifier NOT NULL--È¨ÏŞid
 )
 --ÓÃ»§×é±í
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserGroupName NVARCHAR(50) NOT NULL, --ÓÃ»§×éÃû³Æ
  ParentUserGroupId uniqueidentifier NULL,--¸¸ÓÃ»§×éid
  CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
 ----ÓÃ»§ÓëÓÃ»§×é¹ØÁª±í
 -- CREATE TABLE Sys_UuRelated(
 --UuRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 --UserId uniqueidentifier NOT NULL, --ÓÃ»§id
 --UserGroupId uniqueidentifier NOT NULL,--ÓÃ»§×éid
 --)
 --²Ëµ¥±í
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 MenuName NVARCHAR(50) NOT NULL,--²Ëµ¥Ãû³Æ
 MenuIcon NVARCHAR(10) NULL,--²Ëµ¥Í¼±ê(Ö»Ö§³ÖlayuiÍ¼±ê)
 MenuUrl varchar(80) NULL,--²Ëµ¥url
 MenuSort int NOT NULL,--²Ëµ¥ÅÅĞòºÅ
 ParentMenuId uniqueidentifier DEFAULT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)   NULL,--¸¸²Ëµ¥id
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )

 --È¨ÏŞ²Ëµ¥¹ØÁª±í
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 AuthorityId uniqueidentifier NOT NULL,--È¨ÏŞid
 MenuId uniqueidentifier NOT NULL--²Ëµ¥id
 )
 --ÓÃ»§×éÓë½ÇÉ«¹ØÁª±í
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserGroupId uniqueidentifier NOT NULL,--ÓÃ»§×éid
 RoleId uniqueidentifier NOT NULL--½ÇÉ«id
 )
=======
--´´½¨Êı¾İ¿â
CREATE DATABASE  ZhouLi; --¸öÈËÍøÕ¾
use ZhouLi;
 --ÓÃ»§±í 
 CREATE TABLE Sys_User(
 UserId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü ÓÃ»§id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--ÓÃ»§ÕÊºÅ
 UserNikeName NVARCHAR(20),--ÓÃ»§êÇ³Æ
 UserPwd NVARCHAR(50) DEFAULT upper(substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32)) NOT NULL,--ÓÃ»§ÃÜÂë
 UserSex int DEFAULT 1 NULL,--ÓÃ»§ĞÔ±ğ 1ÄĞ 2Å®
 UserBirthday DATE  NULL,--ÓÃ»§³öÉúÄêÔÂÈÕ
 UserEmail VARCHAR(50)  NULL,--ÓÃ»§ÓÊÏä
 UserQq VARCHAR(15)  NULL,--ÓÃ»§QQ
 UserWx VARCHAR(50)  NULL,--ÓÃ»§Î¢ĞÅ
 UserAvatar VARCHAR(150)  NULL,--ÓÃ»§Í·Ïñ
 UserPhone VARCHAR(11) NULL,--ÓÃ»§ÊÖ»ú
 UserGroupId uniqueidentifier NULL,--ËùÊôÓÃ»§×é
 UserStatus INT  DEFAULT 1 NOT NULL,--ÓÃ»§×´Ì¬(ÓëDict_UserStatusµÄid¹ØÁª)
 CreateUserId uniqueidentifier ,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
 --½ÇÉ«±í
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü ½ÇÉ«Id
 RoleName NVARCHAR(50) NOT NULL,--½ÇÉ«Ãû
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )

 --È¨ÏŞ±í
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 AuthorityType INT NOT NULL,--È¨ÏŞÀàĞÍ
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
  --È¨ÏŞÀàĞÍ±í
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId int identity(1,1) primary key NOT NULL ,--Ö÷¼üId
 AuthorityTypeName nvarchar(20) not null,--È¨ÏŞÀàĞÍÃû³Æ
 )
 --ÓÃ»§½ÇÉ«¹ØÁª±í
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserId uniqueidentifier NOT NULL,--ÓÃ»§id
 RoleId uniqueidentifier NOT NULL--½ÇÉ«id
 )
  --½ÇÉ«È¨ÏŞ¹ØÁª±í
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 RoleId uniqueidentifier NOT NULL,--½ÇÉ«id
 AuthorityId uniqueidentifier NOT NULL--È¨ÏŞid
 )
 --ÓÃ»§×é±í
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserGroupName NVARCHAR(50) NOT NULL, --ÓÃ»§×éÃû³Æ
  ParentUserGroupId uniqueidentifier NULL,--¸¸ÓÃ»§×éid
  CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )
 ----ÓÃ»§ÓëÓÃ»§×é¹ØÁª±í
 -- CREATE TABLE Sys_UuRelated(
 --UuRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 --UserId uniqueidentifier NOT NULL, --ÓÃ»§id
 --UserGroupId uniqueidentifier NOT NULL,--ÓÃ»§×éid
 --)
 --²Ëµ¥±í
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 MenuName NVARCHAR(50) NOT NULL,--²Ëµ¥Ãû³Æ
 MenuIcon NVARCHAR(50) NULL,--²Ëµ¥Í¼±ê(Ö»Ö§³ÖlayuiÍ¼±ê)
 MenuUrl varchar(80) NULL,--²Ëµ¥url
 MenuSort int NOT NULL,--²Ëµ¥ÅÅĞòºÅ
 ParentMenuId uniqueidentifier DEFAULT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER)   NULL,--¸¸²Ëµ¥id
 CreateUserId uniqueidentifier,--´´½¨ÕßID(¶ÔÓ¦Sys_Users±íUserId×Ö¶Î)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--´´½¨Ê±¼ä
 EditTime DATETIME  NULL ,--ĞŞ¸ÄÊ±¼ä
 DeleteSign int DEFAULT 1 not null,--1 Î´É¾³ı 2 ÒÑÉ¾³ı
 DeleteTime DATETIME NULL,--É¾³ıÊ±¼ä
 Note NVARCHAR(2048) NULL--±¸×¢
 )

 --È¨ÏŞ²Ëµ¥¹ØÁª±í
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 AuthorityId uniqueidentifier NOT NULL,--È¨ÏŞid
 MenuId uniqueidentifier NOT NULL--²Ëµ¥id
 )
 --ÓÃ»§×éÓë½ÇÉ«¹ØÁª±í
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--Ö÷¼ü
 UserGroupId uniqueidentifier NOT NULL,--ÓÃ»§×éid
 RoleId uniqueidentifier NOT NULL--½ÇÉ«id
 )
>>>>>>> a808b5f182f18453e1ebf432cc67fcb426ed8f37:TableStructure/åˆ›å»ºæ•°æ®åº“.sql
