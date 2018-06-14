--�������ݿ�
CREATE DATABASE  ZhouLi; --������վ
use ZhouLi;
 --�û��� 
 CREATE TABLE Sys_User(
 UserId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--���� �û�id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--�û��ʺ�
 UserNikeName NVARCHAR(20),--�û��ǳ�
 UserPwd NVARCHAR(50) DEFAULT upper(substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32)) NOT NULL,--�û�����
 UserSex int  NULL,--�û��Ա�
 UserBirthday DATE  NULL,--�û�����������
 UserEmail VARCHAR(50)  NULL,--�û�����
 UserQQ VARCHAR(15)  NULL,--�û�QQ
 UserWX VARCHAR(50)  NULL,--�û�΢��
 UserAvatar VARCHAR(150)  NULL,--�û�ͷ��
 UserPhone VARCHAR(11) NULL,--�û��ֻ�
 UserStatus INT  DEFAULT 1 NOT NULL,--�û�״̬(��Dict_UserStatus��id����)
 CreateUserId uniqueidentifier ,--������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 EditTime DATETIME  NULL ,--�޸�ʱ��
 DeleteSign int DEFAULT 0 not null,--0 δɾ�� 1 ��ɾ��
 DeleteTime DATETIME NULL,--ɾ��ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )
 --�û�״̬��
 CREATE TABLE Dict_UserStatus(
 UserStatusId int identity(1,1) primary key NOT NULL ,--����Id
 UserStatusName nvarchar(20) not null--�û�״̬����
 )
 --��ɫ��
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--���� ��ɫId
 RoleName NVARCHAR(50) NOT NULL,--��ɫ��
 CreateUserId uniqueidentifier,--������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 EditTime DATETIME  NULL ,--�޸�ʱ��
 DeleteSign int DEFAULT 0 not null,--0 δɾ�� 1 ��ɾ��
 DeleteTime DATETIME NULL,--ɾ��ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )

 --Ȩ�ޱ�
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 AuthorityType INT NOT NULL,--Ȩ������
 CreateUserId uniqueidentifier,--������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 EditTime DATETIME  NULL ,--�޸�ʱ��
 DeleteSign int DEFAULT 0 not null,--0 δɾ�� 1 ��ɾ��
 DeleteTime DATETIME NULL,--ɾ��ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )
  --Ȩ�����ͱ�
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId int identity(1,1) primary key NOT NULL ,--����Id
 AuthorityTypeName nvarchar(20) not null,--Ȩ����������
 )
 --�û���ɫ������
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 UserId uniqueidentifier NOT NULL,--�û�id
 RoleId uniqueidentifier NOT NULL--��ɫid
 )
  --��ɫȨ�޹�����
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 RoleId uniqueidentifier NOT NULL,--��ɫid
 AuthorityId uniqueidentifier NOT NULL--Ȩ��id
 )
 --�û����
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 UserGroupName NVARCHAR(50) NOT NULL, --�û�������
  ParentUserGroupId uniqueidentifier NULL,--���û���id
  CreateUserId uniqueidentifier,--������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 EditTime DATETIME  NULL ,--�޸�ʱ��
 DeleteSign int DEFAULT 0 not null,--0 δɾ�� 1 ��ɾ��
 DeleteTime DATETIME NULL,--ɾ��ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )
 --�û����û��������
  CREATE TABLE Sys_UuRelated(
 UuRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 UserId uniqueidentifier NOT NULL, --�û�id
 UserGroupId uniqueidentifier NOT NULL,--�û���id
 )
 --�˵���
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 MenuName NVARCHAR(50) NOT NULL,--�˵�����
 MenuIcon NVARCHAR(10) NULL,--�˵�ͼ��(ֻ֧��layuiͼ��)
 MenuUrl varchar(80) NULL,--�˵�url
 ParentMenuId uniqueidentifier NULL,--���˵�id
 CreateUserId uniqueidentifier,--������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 EditTime DATETIME  NULL ,--�޸�ʱ��
 DeleteSign int DEFAULT 0 not null,--0 δɾ�� 1 ��ɾ��
 DeleteTime DATETIME NULL,--ɾ��ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )

 --Ȩ�޲˵�������
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 AuthorityId uniqueidentifier NOT NULL,--Ȩ��id
 MenuId uniqueidentifier NOT NULL--�˵�id
 )
 --�û������ɫ������
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId uniqueidentifier primary key DEFAULT newid() NOT NULL ,--����
 UserGroupId uniqueidentifier NOT NULL,--�û���id
 RoleId uniqueidentifier NOT NULL--��ɫid
 )
