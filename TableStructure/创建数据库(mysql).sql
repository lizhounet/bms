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
   article_id           int not null auto_increment comment '����id',
   article_title        nvarchar(50) not null comment '���±���',
   article_thrink       varchar(100) not null comment '����ͼƬ',
   article_body         text not null comment '��������',
   article_body_markdown text comment '����Markdown����',
   article_body_summary nvarchar(100) comment '����ժҪ',
   article_sort_value   int not null default 0 comment '�����',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (article_id)
);

alter table blog_article comment '�������±�';

/*==============================================================*/
/* Table: blog_article_browsing                                 */
/*==============================================================*/
create table blog_article_browsing
(
   id                   int not null auto_increment comment '���������������id',
   article_id           int not null comment '����id',
   ip                   varchar(20) not null comment 'ip��ַ',
   create_time          datetime not null comment '����ʱ��',
   primary key (id)
);

/*==============================================================*/
/* Table: blog_article_like                                     */
/*==============================================================*/
create table blog_article_like
(
   id                   int not null auto_increment comment '�������µ�������id',
   article_id           int not null comment '����id',
   ip                   varchar(20) not null comment 'ip��ַ',
   create_time          datetime not null comment '����ʱ��',
   primary key (id)
);

/*==============================================================*/
/* Table: blog_friendship_link                                  */
/*==============================================================*/
create table blog_friendship_link
(
   friendship_link_id   int not null auto_increment comment '��������id',
   friendship_link_name nvarchar(40) not null comment 'վ������',
   friendship_link_url  varchar(40) not null comment 'վ��url',
   friendship_link_email varchar(40) not null comment 'վ������',
   friendship_link_sort_value int not null default 0 comment '�����',
   friendship_link_sfsh int not null default 0 comment '�Ƿ����',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (friendship_link_id)
);

/*==============================================================*/
/* Table: blog_lable                                            */
/*==============================================================*/
create table blog_lable
(
   lable_id             int not null auto_increment comment '���ͱ�ǩid',
   lable_name           nvarchar(20) not null comment '��ǩ����',
   lable_sort_value     int not null default 0 comment '��ǩ�����',
   lable_click_num      bigint not null default 0 comment '��ǩ�����',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (lable_id)
);

/*==============================================================*/
/* Table: blog_navigation_img                                   */
/*==============================================================*/
create table blog_navigation_img
(
   navigation_img_id    int not null auto_increment comment '�����ֲ�ͼid',
   navigation_img_url   varchar(200) not null comment '�ֲ�ͼurl',
   navigation_img_sort_value int not null default 0 comment '�ֲ�ͼ�����',
   navigation_img_describe nvarchar(2048) not null default '0' comment '�ֲ�ͼ����',
   navigation_img_is_enable int not null default 1 comment '�Ƿ�����',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (navigation_img_id)
);

/*==============================================================*/
/* Table: blog_related                                          */
/*==============================================================*/
create table blog_related
(
   blog_related_id      int not null auto_increment comment '�������±�ǩ������',
   related_article_id   int not null comment '����id',
   related_lable_id     int not null comment '��ǩid',
   primary key (blog_related_id)
);

/*==============================================================*/
/* Table: dict_authority_type                                   */
/*==============================================================*/
create table dict_authority_type
(
   authority_type_id    varchar(36) not null comment 'Ȩ������id',
   authority_type_name  nvarchar(20) not null comment 'Ȩ����������',
   primary key (authority_type_id)
);

/*==============================================================*/
/* Table: sys_ab_related                                        */
/*==============================================================*/
create table sys_ab_related
(
   ab_related_id        varchar(36) not null comment 'Ȩ�ް�ť����id',
   authority_id         varchar(36) not null comment 'Ȩ��id',
   button_id            varchar(36) not null comment '��ťid',
   primary key (ab_related_id)
);

/*==============================================================*/
/* Table: sys_am_related                                        */
/*==============================================================*/
create table sys_am_related
(
   am_related_id        varchar(36) not null comment 'Ȩ�޲˵�����id',
   authority_id         varchar(36) not null comment 'Ȩ��id',
   menu_id              varchar(36) not null comment '�˵�id',
   primary key (am_related_id)
);

/*==============================================================*/
/* Table: sys_authority                                         */
/*==============================================================*/
create table sys_authority
(
   authority_id         varchar(36) not null comment 'Ȩ��id',
   authority_type       int not null comment 'Ȩ������',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 varchar(2048) comment '��ע',
   primary key (authority_id)
);

/*==============================================================*/
/* Table: sys_button                                            */
/*==============================================================*/
create table sys_button
(
   button_id            varchar(36) not null comment '��ťId',
   menu_id              varchar(36) not null comment '�˵�Id',
   button_name          nvarchar(20) not null comment '��ť����',
   button_show_type     int not null comment '��ť��ʾ����(1=��ʾ����,2=��ʾ������,3=����ʾ)',
   primary key (button_id)
);

/*==============================================================*/
/* Table: sys_menu                                              */
/*==============================================================*/
create table sys_menu
(
   menu_id              varchar(36) not null comment '�˵�id',
   menu_name            nvarchar(50) not null comment '�˵�����',
   menu_icon            varchar(50) comment '�˵�ͼ��',
   menu_url             varchar(80) comment '�˵�url',
   menu_sort            int not null comment '�˵������',
   parent_menu_id       varchar(36) comment '�����˵�id',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (menu_id)
);

/*==============================================================*/
/* Table: sys_ra_related                                        */
/*==============================================================*/
create table sys_ra_related
(
   ra_related_id        varchar(36) not null comment '��ɫȨ�޹�����id',
   role_id              varchar(36) not null comment '��ɫid',
   authority_id         varchar(36) not null comment 'Ȩ��id',
   primary key (ra_related_id)
);

/*==============================================================*/
/* Table: sys_role                                              */
/*==============================================================*/
create table sys_role
(
   role_id              varchar(36) not null comment '��ɫid',
   role_name            nvarchar(50) not null comment '��ɫ����',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (role_id)
);

/*==============================================================*/
/* Table: sys_ugr_related                                       */
/*==============================================================*/
create table sys_ugr_related
(
   ugr_related_id       varchar(36) not null comment '�û����ɫ�����',
   user_group_id        varchar(36) not null comment '�û���id',
   role_id              varchar(36) not null comment '��ɫid',
   primary key (ugr_related_id)
);

/*==============================================================*/
/* Table: sys_ur_related                                        */
/*==============================================================*/
create table sys_ur_related
(
   ur_related_id        varchar(36) not null comment '�û���ɫ�����id',
   user_id              varchar(36) not null comment '�û�id',
   role_id              varchar(36) not null comment '��ɫid',
   primary key (ur_related_id)
);

/*==============================================================*/
/* Table: sys_user                                              */
/*==============================================================*/
create table sys_user
(
   user_id              varchar(36) not null comment '�û�id',
   user_name            varchar(20) not null comment '�˺�',
   user_nike_name       nvarchar(20) comment '�ǳ�',
   user_pwd             varchar(50) not null comment '����',
   user_sex             int default 1 comment '�Ա�',
   user_birthday        datetime comment '����',
   user_email           varchar(50) comment '����',
   user_qq              varchar(15) comment 'qq',
   user_wx              varchar(50) comment '΢��',
   user_avatar          varchar(150) comment 'ͷ��',
   user_phone           varchar(11) comment '�绰',
   user_group_id        varchar(36) comment '�����û���',
   user_status          int not null default 1 comment '�û�״̬',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (user_id)
);

/*==============================================================*/
/* Table: sys_user_group                                        */
/*==============================================================*/
create table sys_user_group
(
   user_group_id        varchar(36) not null comment '�û���id',
   user_group_name      nvarchar(50) not null comment '�û�������',
   parent_user_group_id varchar(36) comment '�����û���id',
   create_user_id       varchar(36) comment '������id',
   create_time          datetime not null comment '����ʱ��',
   edit_time            datetime comment '�޸�ʱ��',
   delete_sign          int not null default 1 comment 'ɾ����ʶ',
   delete_time          datetime comment 'ɾ��ʱ��',
   note                 nvarchar(2048) comment '��ע',
   primary key (user_group_id)
);

