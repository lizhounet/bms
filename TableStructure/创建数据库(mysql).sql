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
   Article_Id           int not null auto_increment comment '文章id',
   Article_Title        varchar(50) not null comment '文章标题',
   Article_Thrink       varchar(100) not null comment '文章图片',
   Article_Body         text not null comment '文章内容',
   Article_Body_Markdown text comment '文章Markdown内容',
   Article_Body_Summary varchar(100) comment '文章摘要',
   Article_SortValue    int not null default 0 comment '排序号',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (Article_Id)
);

alter table Blog_Article comment '博客文章表';

/*==============================================================*/
/* Table: Blog_ArticleBrowsing                                  */
/*==============================================================*/
create table Blog_ArticleBrowsing
(
   Id                   int not null auto_increment comment '博客文章浏览量表id',
   ArticleId            int not null comment '文章id',
   Ip                   varchar(20) not null comment 'ip地址',
   CreateTime           datetime not null comment '创建时间',
   primary key (Id)
);

/*==============================================================*/
/* Table: Blog_ArticleLike                                      */
/*==============================================================*/
create table Blog_ArticleLike
(
   Id                   int not null auto_increment comment '博客文章点赞量表id',
   ArticleId            int not null comment '文章id',
   Ip                   varchar(20) not null comment 'ip地址',
   CreateTime           datetime not null comment '创建时间',
   primary key (Id)
);

/*==============================================================*/
/* Table: Blog_FriendshipLink                                   */
/*==============================================================*/
create table Blog_FriendshipLink
(
   FriendshipLink_Id    int not null auto_increment comment '友情链接id',
   FriendshipLink_Name  varchar(40) not null comment '站点名称',
   FriendshipLink_Url   varchar(40) not null comment '站点url',
   FriendshipLink_Email varchar(40) not null comment '站长邮箱',
   FriendshipLink_SortValue int not null default 0 comment '排序号',
   FriendshipLink_Sfsh  int not null default 0 comment '是否审核',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (FriendshipLink_Id)
);

/*==============================================================*/
/* Table: Blog_Lable                                            */
/*==============================================================*/
create table Blog_Lable
(
   Lable_Id             int not null auto_increment comment '博客标签id',
   Lable_Name           varchar(20) not null comment '标签名称',
   Lable_SortValue      int not null default 0 comment '标签排序号',
   Lable_ClickNum       bigint not null default 0 comment '标签点击量',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (Lable_Id)
);

/*==============================================================*/
/* Table: Blog_NavigationImg                                    */
/*==============================================================*/
create table Blog_NavigationImg
(
   NavigationImg_Id     int not null auto_increment comment '博客轮播图id',
   NavigationImg_Url    varchar(200) not null comment '轮播图url',
   NavigationImg_SortValue int not null default 0 comment '轮播图排序号',
   NavigationImg_Describe varchar(2048) not null default '0' comment '轮播图描述',
   NavigationImg_IsEnable int not null default 1 comment '是否启用',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (NavigationImg_Id)
);

/*==============================================================*/
/* Table: Blog_Related                                          */
/*==============================================================*/
create table Blog_Related
(
   Blog_RelatedId       int not null auto_increment comment '博客文章标签关联表',
   Related_Article_Id   int not null comment '文章id',
   Related_Lable_Id     int not null comment '标签id',
   primary key (Blog_RelatedId)
);

/*==============================================================*/
/* Table: Dict_AuthorityType                                    */
/*==============================================================*/
create table Dict_AuthorityType
(
   AuthorityTypeId      varchar(36) not null comment '权限类型id',
   AuthorityTypeName    varchar(20) not null comment '权限类型名称',
   primary key (AuthorityTypeId)
);

/*==============================================================*/
/* Table: Sys_AmRelated                                         */
/*==============================================================*/
create table Sys_AmRelated
(
   AmRelatedId          varchar(36) not null comment '权限菜单关联id',
   AuthorityId          varchar(36) not null comment '权限id',
   MenuId               varchar(36) not null comment '菜单id',
   primary key (AmRelatedId)
);

/*==============================================================*/
/* Table: Sys_Authority                                         */
/*==============================================================*/
create table Sys_Authority
(
   AuthorityId          varchar(36) not null comment '权限id',
   AuthorityType        int not null comment '权限类型',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (AuthorityId)
);

/*==============================================================*/
/* Table: Sys_Menu                                              */
/*==============================================================*/
create table Sys_Menu
(
   MenuId               varchar(36) not null comment '菜单id',
   MenuName             varchar(50) not null comment '菜单名称',
   MenuIcon             varchar(50) comment '菜单图标',
   MenuUrl              varchar(80) comment '菜单url',
   MenuSort             int not null comment '菜单排序号',
   ParentMenuId         varchar(36) comment '父级菜单id',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (MenuId)
);

/*==============================================================*/
/* Table: Sys_RaRelated                                         */
/*==============================================================*/
create table Sys_RaRelated
(
   RaRelatedId          varchar(36) not null comment '角色权限关联表id',
   RoleId               varchar(36) not null comment '角色id',
   AuthorityId          varchar(36) not null comment '权限id',
   primary key (RaRelatedId)
);

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role
(
   RoleId               varchar(36) not null comment '角色id',
   RoleName             varchar(50) not null comment '角色名称',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (RoleId)
);

/*==============================================================*/
/* Table: Sys_UgrRelated                                        */
/*==============================================================*/
create table Sys_UgrRelated
(
   UgrRelatedId         varchar(36) not null comment '用户组角色管理表',
   UserGroupId          varchar(36) not null comment '用户组id',
   RoleId               varchar(36) not null comment '角色id',
   primary key (UgrRelatedId)
);

/*==============================================================*/
/* Table: Sys_UrRelated                                         */
/*==============================================================*/
create table Sys_UrRelated
(
   UrRelatedId          varchar(36) not null comment '用户角色管理表id',
   UserId               varchar(36) not null comment '用户id',
   RoleId               varchar(36) not null comment '角色id',
   primary key (UrRelatedId)
);

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User
(
   UserId               varchar(36) not null comment '用户id',
   UserName             varchar(20) not null comment '账号',
   UserNikeName         varchar(20) comment '昵称',
   UserPwd              varchar(50) not null comment '密码',
   UserSex              int default 1 comment '性别',
   UserBirthday         datetime comment '生日',
   UserEmail            varchar(50) comment '邮箱',
   UserQq               varchar(15) comment 'qq',
   UserWx               varchar(50) comment '微信',
   UserAvatar           varchar(150) comment '头像',
   UserPhone            varchar(11) comment '电话',
   UserGroupId          varchar(36) comment '所属用户组',
   UserStatus           int not null default 1 comment '用户状态',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (UserId)
);

/*==============================================================*/
/* Table: Sys_UserGroup                                         */
/*==============================================================*/
create table Sys_UserGroup
(
   UserGroupId          varchar(36) not null comment '用户组id',
   UserGroupName        varchar(50) not null comment '用户组名称',
   ParentUserGroupId    varchar(36) comment '父级用户组id',
   CreateUserId         varchar(36) comment '创建人id',
   CreateTime           datetime not null comment '创建时间',
   EditTime             datetime comment '修改时间',
   DeleteSign           int not null default 1 comment '删除标识',
   DeleteTime           datetime comment '删除时间',
   Note                 varchar(2048) comment '备注',
   primary key (UserGroupId)
);

