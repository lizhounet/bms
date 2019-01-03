-- �������ݿ�
CREATE DATABASE  ZhouLi; -- --������վ
USE ZhouLi;
-- ------------------------------------------------------------����ϵͳ��Ҫ�ı�
 -- --�û��� 
 CREATE TABLE Sys_User(
 UserId VARCHAR(36)  PRIMARY KEY NOT NULL ,-- --���� �û�id
 UserName NVARCHAR(20) NOT NULL UNIQUE,-- --�û��ʺ�
 UserNikeName NVARCHAR(20),-- --�û��ǳ�
 UserPwd NVARCHAR(50)  NOT NULL,-- --�û�����
 UserSex INT DEFAULT 1 NULL,-- --�û��Ա� 1�� 2Ů
 UserBirthday DATE  NULL,-- --�û�����������
 UserEmail VARCHAR(50)  NULL,-- --�û�����
 UserQq VARCHAR(15)  NULL,-- --�û�QQ
 UserWx VARCHAR(50)  NULL,-- --�û�΢��
 UserAvatar VARCHAR(150)  NULL,-- --�û�ͷ��
 UserPhone VARCHAR(11) NULL,-- --�û��ֻ�
 UserGroupId  VARCHAR(36) NULL,-- --�����û���
 UserStatus INT  DEFAULT 1 NOT NULL,-- --�û�״̬(��Dict_UserStatus��id����)
 CreateUserId  VARCHAR(36) NULL,-- --������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME   NOT NULL,-- --����ʱ��
 EditTime DATETIME  NULL ,-- --�޸�ʱ��
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 δɾ�� 2 ��ɾ��
 DeleteTime DATETIME NULL,-- --ɾ��ʱ��
 Note NVARCHAR(2048) NULL-- --��ע
 );
 -- --��ɫ��
 CREATE TABLE Sys_Role(
 RoleId  VARCHAR(36) PRIMARY KEY NOT NULL  ,-- --���� ��ɫId
 RoleName NVARCHAR(50) NOT NULL,-- --��ɫ��
 CreateUserId  VARCHAR(36) NULL,-- --������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME   NOT NULL,-- --����ʱ��
 EditTime DATETIME  NULL ,-- --�޸�ʱ��
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 δɾ�� 2 ��ɾ��
 DeleteTime DATETIME NULL,-- --ɾ��ʱ��
 Note NVARCHAR(2048) NULL-- --��ע
 );

 -- --Ȩ�ޱ�
 CREATE TABLE Sys_Authority(
 AuthorityId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --����
 AuthorityType INT NOT NULL,-- --Ȩ������
 CreateUserId  VARCHAR(36) NULL,-- --������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  NOT NULL,-- --����ʱ��
 EditTime DATETIME  NULL ,-- --�޸�ʱ��
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 δɾ�� 2 ��ɾ��
 DeleteTime DATETIME NULL,-- --ɾ��ʱ��
 Note NVARCHAR(2048) NULL-- --��ע
 );
  -- --Ȩ�����ͱ�
 CREATE TABLE Dict_AuthorityType(
 AuthorityTypeId  VARCHAR(36)  PRIMARY KEY NOT NULL ,-- --����Id
 AuthorityTypeName NVARCHAR(20) NOT NULL-- --Ȩ����������
 );
 -- --�û���ɫ������
 CREATE TABLE Sys_UrRelated(
 UrRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --����
 UserId  VARCHAR(36) NOT NULL,-- --�û�id
 RoleId  VARCHAR(36) NOT NULL-- --��ɫid
 );
  -- --��ɫȨ�޹�����
 CREATE TABLE Sys_RaRelated(
 RaRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --����
 RoleId  VARCHAR(36) NOT NULL,-- --��ɫid
 AuthorityId  VARCHAR(36) NOT NULL-- --Ȩ��id
 );
 -- --�û����
 CREATE TABLE Sys_UserGroup(
 UserGroupId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- --����
 UserGroupName NVARCHAR(50) NOT NULL, -- --�û�������
 ParentUserGroupId  VARCHAR(36) NULL,-- --���û���id
 CreateUserId  VARCHAR(36) NULL,-- --������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  NOT NULL,-- --����ʱ��
 EditTime DATETIME  NULL ,-- --�޸�ʱ��
 DeleteSign INT DEFAULT 1 NOT NULL,-- --1 δɾ�� 2 ��ɾ��
 DeleteTime DATETIME NULL,-- --ɾ��ʱ��
 Note NVARCHAR(2048) NULL-- --��ע
 );
--  ----�û����û��������
--  -- CREATE TABLE Sys_UuRelated(
--  --UuRelatedId uniqueidentifier PRIMARY KEY DEFAULT newid() NOT NULL ,--����
--  --UserId uniqueidentifier NOT NULL, --�û�id
--  --UserGroupId uniqueidentifier NOT NULL,--�û���id
--  --)
 -- --�˵���
 CREATE TABLE Sys_Menu(
 MenuId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- ����
 MenuName NVARCHAR(50) NOT NULL,-- �˵�����
 MenuIcon NVARCHAR(50) NULL,-- �˵�ͼ��(ֻ֧��layuiͼ��)
 MenuUrl VARCHAR(80) NULL,-- �˵�url
 MenuSort INT NOT NULL,-- �˵������
 ParentMenuId  VARCHAR(36)   NULL,-- ���˵�id
 CreateUserId  VARCHAR(36) NULL,-- ������ID(��ӦSys_Users��UserId�ֶ�)
 CreateTime DATETIME  NOT NULL,-- ����ʱ��
 EditTime DATETIME  NULL ,-- �޸�ʱ��
 DeleteSign INT DEFAULT 1 NOT NULL,-- 1 δɾ�� 2 ��ɾ��
 DeleteTime DATETIME NULL,-- ɾ��ʱ��
 Note NVARCHAR(2048) NULL-- ��ע
 );

 -- Ȩ�޲˵�������
 CREATE TABLE Sys_AmRelated(
 AmRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- ����
 AuthorityId  VARCHAR(36) NOT NULL,-- Ȩ��id
 MenuId  VARCHAR(36) NOT NULL-- �˵�id
 );
 -- �û������ɫ������
 CREATE TABLE Sys_UgrRelated(
 UgrRelatedId  VARCHAR(36) PRIMARY KEY NOT NULL ,-- ����
 UserGroupId  VARCHAR(36) NOT NULL,-- �û���id
 RoleId  VARCHAR(36) NOT NULL-- ��ɫid
 );
-- -------------------------------------------------------------------- ����������Ҫ�ı�
-- �������±�
CREATE TABLE Blog_Article(
Article_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,-- ����
Article_Title NVARCHAR(50) NOT NULL,-- �������±���
Article_Body TEXT NOT NULL,-- ������������
Article_Body_Markdown TEXT  NULL,-- ������������,
Article_SortValue INT DEFAULT 0 NOT NULL,-- ����ֵ,
Article_CreateTime DATETIME    NOT NULL,-- ����ʱ��
Article_UserId INT  NOT NULL,-- �����û�id
Article_UserNikeName NVARCHAR(50)  NOT NULL,-- �����û��ǳ�
Article_Note NVARCHAR(2048) NULL-- ��ע
);
-- ���ͱ�ǩ��
CREATE TABLE Blog_Lable(
Lable_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,-- ���ͱ�ǩ���(����)
Lable_Name NVARCHAR(20) NOT NULL UNIQUE,-- ���ͱ�ǩ����
Lable_SortValue INT DEFAULT 0 NOT NULL,-- ����ֵ,
Lable_ClickNum BIGINT DEFAULT 0 NOT NULL,-- ���ͱ�ǩ�����
Lable_CreateTime DATETIME  NOT NULL,-- ����ʱ��
Lable_Note NVARCHAR(2048) NULL-- ��ע
);
-- ��ǩ������
CREATE TABLE Blog_Related(
Blog_RelatedId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Related_Article_Id INT  NOT NULL,-- ��������Id
Related_Lable_Id INT NOT NULL-- ���ͱ�ǩ���
);
-- ��������-�鿴��Ϣ��
CREATE TABLE Blog_ArticleSeeInfo
(
ArticleSeeInfo_ArticleId INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,-- ��������Id
ArticleSeeInfo_ArticleBrowsingNum INT DEFAULT 0 NOT NULL,-- �������������
ArticleSeeInfo_ArticleLikeNum INT DEFAULT 0 NOT NULL,-- �������µ�����
ArticleSeeInfo_ArticleCommentNum INT DEFAULT 0 NOT NULL-- ��������������
);
-- ���� �������ӱ�
CREATE TABLE Blog_FriendshipLink
(
FriendshipLink_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,-- ����id
FriendshipLink_Name NVARCHAR(40) NOT NULL,-- վ������
FriendshipLink_Url INT DEFAULT 0 NOT NULL,-- վ��Url
FriendshipLink_Email INT DEFAULT 0 NOT NULL,-- վ������
FriendshipLink_SortValue INT DEFAULT 0 NOT NULL,-- ����ֵ,
FriendshipLink_Sfsh INT DEFAULT 0 NOT NULL-- �Ƿ����(1-����� 0-δ���)
);
-- ���� ��ҳ����ͼ��
CREATE TABLE Blog_NavigationImg
(
NavigationImg_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,-- ����id(����)
NavigationImg_Url VARCHAR(200) NOT NULL,-- ͼƬUrl
NavigationImg_SortValue INT DEFAULT 0 NOT NULL,-- ����ֵ,
NavigationImg_Describe NVARCHAR(2048) DEFAULT '0' NOT NULL-- ����
);