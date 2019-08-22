/*==============================================================*/
/* Database name:  ZhouLi                                       */
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2019-08-22 17:34:15                          */
/*==============================================================*/


drop database if exists ZhouLi;

/*==============================================================*/
/* Database: ZhouLi                                             */
/*==============================================================*/
create database ZhouLi;

use ZhouLi;

/*==============================================================*/
/* Table: Blog_Article                                          */
/*==============================================================*/
create table Blog_Article
(
   Article_Id           int not null auto_increment comment '����id',
   Article_Title        varchar(50) not null comment '���±���',
   Article_Thrink       varchar(100) not null comment '����ͼƬ',
   Article_Body         text not null comment '��������',
   Article_Body_Markdown text comment '����Markdown����',
   Article_Body_Summary varchar(100) comment '����ժҪ',
   Article_SortValue    int not null default 0 comment '�����',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (Article_Id)
);

alter table Blog_Article comment '�������±�';

/*==============================================================*/
/* Table: Blog_ArticleBrowsing                                  */
/*==============================================================*/
create table Blog_ArticleBrowsing
(
   Id                   int not null auto_increment comment '���������������id',
   ArticleId            int not null comment '����id',
   Ip                   varchar(20) not null comment 'ip��ַ',
   CreateTime           datetime not null comment '����ʱ��',
   primary key (Id)
);

/*==============================================================*/
/* Table: Blog_ArticleLike                                      */
/*==============================================================*/
create table Blog_ArticleLike
(
   Id                   int not null auto_increment comment '�������µ�������id',
   ArticleId            int not null comment '����id',
   Ip                   varchar(20) not null comment 'ip��ַ',
   CreateTime           datetime not null comment '����ʱ��',
   primary key (Id)
);

/*==============================================================*/
/* Table: Blog_FriendshipLink                                   */
/*==============================================================*/
create table Blog_FriendshipLink
(
   FriendshipLink_Id    int not null auto_increment comment '��������id',
   FriendshipLink_Name  varchar(40) not null comment 'վ������',
   FriendshipLink_Url   varchar(40) not null comment 'վ��url',
   FriendshipLink_Email varchar(40) not null comment 'վ������',
   FriendshipLink_SortValue int not null default 0 comment '�����',
   FriendshipLink_Sfsh  int not null default 0 comment '�Ƿ����',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (FriendshipLink_Id)
);

/*==============================================================*/
/* Table: Blog_Lable                                            */
/*==============================================================*/
create table Blog_Lable
(
   Lable_Id             int not null auto_increment comment '���ͱ�ǩid',
   Lable_Name           varchar(20) not null comment '��ǩ����',
   Lable_SortValue      int not null default 0 comment '��ǩ�����',
   Lable_ClickNum       bigint not null default 0 comment '��ǩ�����',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (Lable_Id)
);

/*==============================================================*/
/* Table: Blog_NavigationImg                                    */
/*==============================================================*/
create table Blog_NavigationImg
(
   NavigationImg_Id     int not null auto_increment comment '�����ֲ�ͼid',
   NavigationImg_Url    varchar(200) not null comment '�ֲ�ͼurl',
   NavigationImg_SortValue int not null default 0 comment '�ֲ�ͼ�����',
   NavigationImg_Describe varchar(2048) not null default '0' comment '�ֲ�ͼ����',
   NavigationImg_IsEnable int not null default 1 comment '�Ƿ�����',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (NavigationImg_Id)
);

/*==============================================================*/
/* Table: Blog_Related                                          */
/*==============================================================*/
create table Blog_Related
(
   Blog_RelatedId       int not null auto_increment comment '�������±�ǩ������',
   Related_Article_Id   int not null comment '����id',
   Related_Lable_Id     int not null comment '��ǩid',
   primary key (Blog_RelatedId)
);

/*==============================================================*/
/* Table: Dict_AuthorityType                                    */
/*==============================================================*/
create table Dict_AuthorityType
(
   AuthorityTypeId      varchar(36) not null comment 'Ȩ������id',
   AuthorityTypeName    varchar(20) not null comment 'Ȩ����������',
   primary key (AuthorityTypeId)
);

/*==============================================================*/
/* Table: Sys_AmRelated                                         */
/*==============================================================*/
create table Sys_AmRelated
(
   AmRelatedId          varchar(36) not null comment 'Ȩ�޲˵�����id',
   AuthorityId          varchar(36) not null comment 'Ȩ��id',
   MenuId               varchar(36) not null comment '�˵�id',
   primary key (AmRelatedId)
);

/*==============================================================*/
/* Table: Sys_Authority                                         */
/*==============================================================*/
create table Sys_Authority
(
   AuthorityId          varchar(36) not null comment 'Ȩ��id',
   AuthorityType        int not null comment 'Ȩ������',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (AuthorityId)
);

/*==============================================================*/
/* Table: Sys_Menu                                              */
/*==============================================================*/
create table Sys_Menu
(
   MenuId               varchar(36) not null comment '�˵�id',
   MenuName             varchar(50) not null comment '�˵�����',
   MenuIcon             varchar(50) comment '�˵�ͼ��',
   MenuUrl              varchar(80) comment '�˵�url',
   MenuSort             int not null comment '�˵������',
   ParentMenuId         varchar(36) comment '�����˵�id',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (MenuId)
);

/*==============================================================*/
/* Table: Sys_RaRelated                                         */
/*==============================================================*/
create table Sys_RaRelated
(
   RaRelatedId          varchar(36) not null comment '��ɫȨ�޹�����id',
   RoleId               varchar(36) not null comment '��ɫid',
   AuthorityId          varchar(36) not null comment 'Ȩ��id',
   primary key (RaRelatedId)
);

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role
(
   RoleId               varchar(36) not null comment '��ɫid',
   RoleName             varchar(50) not null comment '��ɫ����',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (RoleId)
);

/*==============================================================*/
/* Table: Sys_UgrRelated                                        */
/*==============================================================*/
create table Sys_UgrRelated
(
   UgrRelatedId         varchar(36) not null comment '�û����ɫ�����',
   UserGroupId          varchar(36) not null comment '�û���id',
   RoleId               varchar(36) not null comment '��ɫid',
   primary key (UgrRelatedId)
);

/*==============================================================*/
/* Table: Sys_UrRelated                                         */
/*==============================================================*/
create table Sys_UrRelated
(
   UrRelatedId          varchar(36) not null comment '�û���ɫ�����id',
   UserId               varchar(36) not null comment '�û�id',
   RoleId               varchar(36) not null comment '��ɫid',
   primary key (UrRelatedId)
);

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User
(
   UserId               varchar(36) not null comment '�û�id',
   UserName             varchar(20) not null comment '�˺�',
   UserNikeName         varchar(20) comment '�ǳ�',
   UserPwd              varchar(50) not null comment '����',
   UserSex              int default 1 comment '�Ա�',
   UserBirthday         datetime comment '����',
   UserEmail            varchar(50) comment '����',
   UserQq               varchar(15) comment 'qq',
   UserWx               varchar(50) comment '΢��',
   UserAvatar           varchar(150) comment 'ͷ��',
   UserPhone            varchar(11) comment '�绰',
   UserGroupId          varchar(36) comment '�����û���',
   UserStatus           int not null default 1 comment '�û�״̬',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (UserId)
);

/*==============================================================*/
/* Table: Sys_UserGroup                                         */
/*==============================================================*/
create table Sys_UserGroup
(
   UserGroupId          varchar(36) not null comment '�û���id',
   UserGroupName        varchar(50) not null comment '�û�������',
   ParentUserGroupId    varchar(36) comment '�����û���id',
   CreateUserId         varchar(36) comment '������id',
   CreateTime           datetime not null comment '����ʱ��',
   EditTime             datetime comment '�޸�ʱ��',
   DeleteSign           int not null default 1 comment 'ɾ����ʶ',
   DeleteTime           datetime comment 'ɾ��ʱ��',
   Note                 varchar(2048) comment '��ע',
   primary key (UserGroupId)
);

