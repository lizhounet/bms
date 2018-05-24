
--�������ݿ�
CREATE DATABASE  GRWEBSITE--������վ
 --�û���
 CREATE TABLE Sys_Users(
 UserId uniqueidentifier DEFAULT newid() NOT NULL ,--���� �û�id
 UserName NVARCHAR(20) NOT NULL UNIQUE,--�û��ʺ�
 UserNikeName NVARCHAR(20),--�û��ǳ�
 UserPwd NVARCHAR(50) DEFAULT substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','123456')),3,32) NOT NULL,--�û�����
 UserSex int  NULL,--�û��Ա�
 UserBirthday DATE  NULL,--�û�����������
 UserEmail VARCHAR(15)  NULL,--�û�����
 UserQQ VARCHAR(15)  NULL,--�û�QQ
 UserWX VARCHAR(30)  NULL,--�û�΢��
 UserAvatar VARCHAR(150)  NULL,--�û�ͷ��
 UserPhone VARCHAR(11) NULL,--�û��ֻ�
 UserStatus INT  DEFAULT 1 NOT NULL,--�û�״̬(��Dict_UserStatus��id����)
 UserCreateTime DATETIME  DEFAULT CONVERT(varchar, getdate(), 120 )  NOT NULL,--����ʱ��
 UserEditTime DATETIME  ,--�޸�ʱ��
 Note NVARCHAR(2048) NULL--��ע
 )
 --�û�״̬��
 CREATE TABLE Dict_UserStatus(
 Id int identity(1,1) primary key NOT NULL ,--����Id
 UserStatusName nvarchar(20) not null--�û�״̬����
 )
 insert into Dict_UserStatus(UserStatusName) values('����'),('ͣ��');
 --��ɫ��
 CREATE TABLE Sys_Role(
 RoleId uniqueidentifier DEFAULT newid() NOT NULL ,--���� ��ɫId
 RoleName NVARCHAR(50) NOT NULL,--��ɫ��
 Note NVARCHAR(2048) NULL--��ע
 )
 --Ȩ�ޱ�
 CREATE TABLE Sys_Authority(
 AuthorityId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 AuthorityType INT NOT NULL,--Ȩ������
 Note NVARCHAR(2048) NULL--��ע
 )
  --Ȩ�����ͱ�
 CREATE TABLE Dict_AuthorityType(
 Id int identity(1,1) primary key NOT NULL ,--����Id
 AuthorityTypeName nvarchar(20) not null,--Ȩ����������
 Note NVARCHAR(2048) NULL--��ע
 )
  insert into Dict_AuthorityType(AuthorityTypeName) values('�˵�Ȩ��'),('���ݶ�дȨ��');
 --�û���ɫ������
 CREATE TABLE Sys_UrRelated(
 UrRelatedId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 UserId uniqueidentifier NOT NULL,--�û�id
 RoleId uniqueidentifier NOT NULL--��ɫid
 )
  --��ɫȨ�޹�����
 CREATE TABLE Sys_RaRelated(
 RaRelatedId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 RoleId uniqueidentifier NOT NULL,--��ɫid
 AuthorityId uniqueidentifier NOT NULL--Ȩ��id
 )
 --�û����
 CREATE TABLE Sys_UserGroup(
 UserGroupId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 UserGroupName NVARCHAR(50) NOT NULL, --�û�������
  ParentUserGroupId uniqueidentifier NULL,--���û���id
 )
 --�˵���
 CREATE TABLE Sys_Menu(
 MenuId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 MenuName NVARCHAR(50) NOT NULL,--�˵�����
 MenuUrl varchar(80) NULL,--�˵�url
 ParentMenuId uniqueidentifier NULL,--���˵�id
 Note NVARCHAR(2048) NULL--��ע
 )
 --Ȩ�޲˵�������
 CREATE TABLE Sys_AmRelated(
 AmRelatedId uniqueidentifier DEFAULT newid() NOT NULL ,--����
 RoleId uniqueidentifier NOT NULL,--Ȩ��id
 MenuId uniqueidentifier NOT NULL--�˵�id
 )