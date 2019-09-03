/*==============================================================*/
/* Database name:  zhouli                                       */
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2019-08-28 11:45:35                          */
/*==============================================================*/


drop database if exists zhouli;

/*==============================================================*/
/* Database: zhouli                                             */
/*==============================================================*/
create database zhouli;

use zhouli;

/*==============================================================*/
/* Table: blog_article                                          */
/*==============================================================*/
create table blog_article
(
   article_id           int not null auto_increment comment '文章id',
   article_title        nvarchar(50) not null comment '文章标题',
   article_thrink       varchar(100) not null comment '文章图片',
   article_body         text not null comment '文章内容',
   article_body_markdown text comment '文章Markdown内容',
   article_body_summary nvarchar(100) comment '文章摘要',
   article_sort_value   int not null default 0 comment '排序号',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (article_id)
);

alter table blog_article comment '博客文章表';

/*==============================================================*/
/* Table: blog_article_browsing                                 */
/*==============================================================*/
create table blog_article_browsing
(
   id                   int not null auto_increment comment '博客文章浏览量表id',
   article_id           int not null comment '文章id',
   ip                   varchar(20) not null comment 'ip地址',
   create_time          datetime not null comment '创建时间',
   primary key (id)
);

/*==============================================================*/
/* Table: blog_article_like                                     */
/*==============================================================*/
create table blog_article_like
(
   id                   int not null auto_increment comment '博客文章点赞量表id',
   article_id           int not null comment '文章id',
   ip                   varchar(20) not null comment 'ip地址',
   create_time          datetime not null comment '创建时间',
   primary key (id)
);

/*==============================================================*/
/* Table: blog_friendship_link                                  */
/*==============================================================*/
create table blog_friendship_link
(
   friendship_link_id   int not null auto_increment comment '友情链接id',
   friendship_link_name nvarchar(40) not null comment '站点名称',
   friendship_link_url  varchar(40) not null comment '站点url',
   friendship_link_email varchar(40) not null comment '站长邮箱',
   friendship_link_sort_value int not null default 0 comment '排序号',
   friendship_link_sfsh int not null default 0 comment '是否审核',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (friendship_link_id)
);

/*==============================================================*/
/* Table: blog_lable                                            */
/*==============================================================*/
create table blog_lable
(
   lable_id             int not null auto_increment comment '博客标签id',
   lable_name           nvarchar(20) not null comment '标签名称',
   lable_sort_value     int not null default 0 comment '标签排序号',
   lable_click_num      bigint not null default 0 comment '标签点击量',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (lable_id)
);

/*==============================================================*/
/* Table: blog_navigation_img                                   */
/*==============================================================*/
create table blog_navigation_img
(
   navigation_img_id    int not null auto_increment comment '博客轮播图id',
   navigation_img_url   varchar(200) not null comment '轮播图url',
   navigation_img_sort_value int not null default 0 comment '轮播图排序号',
   navigation_img_describe nvarchar(2048) not null default '0' comment '轮播图描述',
   navigation_img_is_enable int not null default 1 comment '是否启用',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (navigation_img_id)
);

/*==============================================================*/
/* Table: blog_related                                          */
/*==============================================================*/
create table blog_related
(
   blog_related_id      int not null auto_increment comment '博客文章标签关联表',
   related_article_id   int not null comment '文章id',
   related_lable_id     int not null comment '标签id',
   primary key (blog_related_id)
);

/*==============================================================*/
/* Table: dict_authority_type                                   */
/*==============================================================*/
create table dict_authority_type
(
   authority_type_id    varchar(36) not null comment '权限类型id',
   authority_type_name  nvarchar(20) not null comment '权限类型名称',
   primary key (authority_type_id)
);

/*==============================================================*/
/* Table: sys_ab_related                                        */
/*==============================================================*/
create table sys_ab_related
(
   ab_related_id        varchar(36) not null comment '权限按钮关联id',
   authority_id         varchar(36) not null comment '权限id',
   button_id            varchar(36) not null comment '按钮id',
   primary key (ab_related_id)
);

/*==============================================================*/
/* Table: sys_am_related                                        */
/*==============================================================*/
create table sys_am_related
(
   am_related_id        varchar(36) not null comment '权限菜单关联id',
   authority_id         varchar(36) not null comment '权限id',
   menu_id              varchar(36) not null comment '菜单id',
   primary key (am_related_id)
);

/*==============================================================*/
/* Table: sys_authority                                         */
/*==============================================================*/
create table sys_authority
(
   authority_id         varchar(36) not null comment '权限id',
   authority_type       int not null comment '权限类型',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 varchar(2048) comment '备注',
   primary key (authority_id)
);

/*==============================================================*/
/* Table: sys_button                                            */
/*==============================================================*/
create table sys_button
(
   button_id            varchar(36) not null comment '按钮Id',
   menu_id              varchar(36) not null comment '菜单Id',
   button_name          nvarchar(20) not null comment '按钮名称',
   button_show_type     int not null comment '按钮显示类型(1=显示可用,2=显示不可用,3=不显示)',
   primary key (button_id)
);

/*==============================================================*/
/* Table: sys_menu                                              */
/*==============================================================*/
create table sys_menu
(
   menu_id              varchar(36) not null comment '菜单id',
   menu_name            nvarchar(50) not null comment '菜单名称',
   menu_icon            varchar(50) comment '菜单图标',
   menu_url             varchar(80) comment '菜单url',
   menu_sort            int not null comment '菜单排序号',
   parent_menu_id       varchar(36) comment '父级菜单id',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (menu_id)
);

/*==============================================================*/
/* Table: sys_ra_related                                        */
/*==============================================================*/
create table sys_ra_related
(
   ra_related_id        varchar(36) not null comment '角色权限关联表id',
   role_id              varchar(36) not null comment '角色id',
   authority_id         varchar(36) not null comment '权限id',
   primary key (ra_related_id)
);

/*==============================================================*/
/* Table: sys_role                                              */
/*==============================================================*/
create table sys_role
(
   role_id              varchar(36) not null comment '角色id',
   role_name            nvarchar(50) not null comment '角色名称',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (role_id)
);

/*==============================================================*/
/* Table: sys_ugr_related                                       */
/*==============================================================*/
create table sys_ugr_related
(
   ugr_related_id       varchar(36) not null comment '用户组角色管理表',
   user_group_id        varchar(36) not null comment '用户组id',
   role_id              varchar(36) not null comment '角色id',
   primary key (ugr_related_id)
);

/*==============================================================*/
/* Table: sys_ur_related                                        */
/*==============================================================*/
create table sys_ur_related
(
   ur_related_id        varchar(36) not null comment '用户角色管理表id',
   user_id              varchar(36) not null comment '用户id',
   role_id              varchar(36) not null comment '角色id',
   primary key (ur_related_id)
);

/*==============================================================*/
/* Table: sys_user                                              */
/*==============================================================*/
create table sys_user
(
   user_id              varchar(36) not null comment '用户id',
   user_name            varchar(20) not null comment '账号',
   user_nike_name       nvarchar(20) comment '昵称',
   user_pwd             varchar(50) not null comment '密码',
   user_sex             int default 1 comment '性别',
   user_birthday        datetime comment '生日',
   user_email           varchar(50) comment '邮箱',
   user_qq              varchar(15) comment 'qq',
   user_wx              varchar(50) comment '微信',
   user_avatar          varchar(150) comment '头像',
   user_phone           varchar(11) comment '电话',
   user_group_id        varchar(36) comment '所属用户组',
   user_status          int not null default 1 comment '用户状态',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (user_id)
);

/*==============================================================*/
/* Table: sys_user_group                                        */
/*==============================================================*/
create table sys_user_group
(
   user_group_id        varchar(36) not null comment '用户组id',
   user_group_name      nvarchar(50) not null comment '用户组名称',
   parent_user_group_id varchar(36) comment '父级用户组id',
   create_user_id       varchar(36) comment '创建人id',
   create_time          datetime not null comment '创建时间',
   edit_time            datetime comment '修改时间',
   delete_sign          int not null default 1 comment '删除标识',
   delete_time          datetime comment '删除时间',
   note                 nvarchar(2048) comment '备注',
   primary key (user_group_id)
);

