/*==============================================================*/
/* Database name:  zhouli                                       */
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2019-08-28 11:46:49                          */
/*==============================================================*/


drop database zhouli
go

/*==============================================================*/
/* Database: zhouli                                             */
/*==============================================================*/
create database zhouli
go

use zhouli
go

/*==============================================================*/
/* Table: blog_article                                          */
/*==============================================================*/
create table blog_article (
   article_id           int                  identity,
   article_title        nvarchar(50)         not null,
   article_thrink       varchar(100)         not null,
   article_body         text                 not null,
   article_body_markdown text                 null,
   article_body_summary nvarchar(100)        null,
   article_sort_value   int                  not null default 0,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_BLOG_ARTICLE primary key nonclustered (article_id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('blog_article') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'blog_article' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '博客文章表', 
   'user', @CurrentUser, 'table', 'blog_article'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_title')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_title'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章标题',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_thrink')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_thrink'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章图片',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_thrink'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_body')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章内容',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_body_markdown')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body_markdown'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章Markdown内容',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body_markdown'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_body_summary')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body_summary'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章摘要',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_body_summary'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_sort_value')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_sort_value'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序号',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'article_sort_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'blog_article', 'column', 'note'
go

/*==============================================================*/
/* Table: blog_article_browsing                                 */
/*==============================================================*/
create table blog_article_browsing (
   id                   int                  identity,
   article_id           int                  not null,
   ip                   varchar(20)          not null,
   create_time          datetime             not null,
   constraint PK_BLOG_ARTICLE_BROWSING primary key nonclustered (id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_browsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章浏览量表id',
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_browsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'article_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'article_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_browsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ip地址',
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_browsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_article_browsing', 'column', 'create_time'
go

/*==============================================================*/
/* Table: blog_article_like                                     */
/*==============================================================*/
create table blog_article_like (
   id                   int                  identity,
   article_id           int                  not null,
   ip                   varchar(20)          not null,
   create_time          datetime             not null,
   constraint PK_BLOG_ARTICLE_LIKE primary key nonclustered (id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_like')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章点赞量表id',
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_like')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'article_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'article_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'article_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_like')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ip地址',
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_article_like')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_article_like', 'column', 'create_time'
go

/*==============================================================*/
/* Table: blog_friendship_link                                  */
/*==============================================================*/
create table blog_friendship_link (
   friendship_link_id   int                  identity,
   friendship_link_name nvarchar(40)         not null,
   friendship_link_url  varchar(40)          not null,
   friendship_link_email varchar(40)          not null,
   friendship_link_sort_value int                  not null default 0,
   friendship_link_sfsh int                  not null default 0,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_BLOG_FRIENDSHIP_LINK primary key nonclustered (friendship_link_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '友情链接id',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站点名称',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_url')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_url'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站点url',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站长邮箱',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_sort_value')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_sort_value'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序号',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_sort_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'friendship_link_sfsh')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_sfsh'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否审核',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'friendship_link_sfsh'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_friendship_link')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'blog_friendship_link', 'column', 'note'
go

/*==============================================================*/
/* Table: blog_lable                                            */
/*==============================================================*/
create table blog_lable (
   lable_id             int                  identity,
   lable_name           nvarchar(20)         not null,
   lable_sort_value     int                  not null default 0,
   lable_click_num      bigint               not null default 0,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_BLOG_LABLE primary key nonclustered (lable_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lable_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客标签id',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lable_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签名称',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lable_sort_value')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_sort_value'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签排序号',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_sort_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'lable_click_num')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_click_num'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签点击量',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'lable_click_num'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'blog_lable', 'column', 'note'
go

/*==============================================================*/
/* Table: blog_navigation_img                                   */
/*==============================================================*/
create table blog_navigation_img (
   navigation_img_id    int                  identity,
   navigation_img_url   varchar(200)         not null,
   navigation_img_sort_value int                  not null default 0,
   navigation_img_describe nvarchar(2048)       not null default '0',
   navigation_img_is_enable int                  not null default 1,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_BLOG_NAVIGATION_IMG primary key nonclustered (navigation_img_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'navigation_img_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客轮播图id',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'navigation_img_url')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_url'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图url',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'navigation_img_sort_value')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_sort_value'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图排序号',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_sort_value'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'navigation_img_describe')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_describe'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图描述',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_describe'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'navigation_img_is_enable')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_is_enable'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'navigation_img_is_enable'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_navigation_img')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'blog_navigation_img', 'column', 'note'
go

/*==============================================================*/
/* Table: blog_related                                          */
/*==============================================================*/
create table blog_related (
   blog_related_id      int                  identity,
   related_article_id   int                  not null,
   related_lable_id     int                  not null,
   constraint PK_BLOG_RELATED primary key nonclustered (blog_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'blog_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'blog_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章标签关联表',
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'blog_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'related_article_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'related_article_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'related_article_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('blog_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'related_lable_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'related_lable_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签id',
   'user', @CurrentUser, 'table', 'blog_related', 'column', 'related_lable_id'
go

/*==============================================================*/
/* Table: dict_authority_type                                   */
/*==============================================================*/
create table dict_authority_type (
   authority_type_id    varchar(36)          not null,
   authority_type_name  nvarchar(20)         not null,
   constraint PK_DICT_AUTHORITY_TYPE primary key nonclustered (authority_type_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dict_authority_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_type_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'dict_authority_type', 'column', 'authority_type_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型id',
   'user', @CurrentUser, 'table', 'dict_authority_type', 'column', 'authority_type_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('dict_authority_type')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_type_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'dict_authority_type', 'column', 'authority_type_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型名称',
   'user', @CurrentUser, 'table', 'dict_authority_type', 'column', 'authority_type_name'
go

/*==============================================================*/
/* Table: sys_ab_related                                        */
/*==============================================================*/
create table sys_ab_related (
   ab_related_id        varchar(36)          not null,
   authority_id         varchar(36)          not null,
   button_id            varchar(36)          not null,
   constraint PK_SYS_AB_RELATED primary key nonclustered (ab_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ab_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ab_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'ab_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限按钮关联id',
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'ab_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ab_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'authority_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'authority_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ab_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'button_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'button_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按钮id',
   'user', @CurrentUser, 'table', 'sys_ab_related', 'column', 'button_id'
go

/*==============================================================*/
/* Table: sys_am_related                                        */
/*==============================================================*/
create table sys_am_related (
   am_related_id        varchar(36)          not null,
   authority_id         varchar(36)          not null,
   menu_id              varchar(36)          not null,
   constraint PK_SYS_AM_RELATED primary key nonclustered (am_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_am_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'am_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'am_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限菜单关联id',
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'am_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_am_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'authority_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'authority_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_am_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'menu_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单id',
   'user', @CurrentUser, 'table', 'sys_am_related', 'column', 'menu_id'
go

/*==============================================================*/
/* Table: sys_authority                                         */
/*==============================================================*/
create table sys_authority (
   authority_id         varchar(36)          not null,
   authority_type       int                  not null,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 varchar(2048)        null,
   constraint PK_SYS_AUTHORITY primary key nonclustered (authority_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'authority_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'authority_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'authority_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'authority_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'sys_authority', 'column', 'note'
go

/*==============================================================*/
/* Table: sys_button                                            */
/*==============================================================*/
create table sys_button (
   button_id            varchar(36)          not null,
   menu_id              varchar(36)          not null,
   button_name          nvarchar(20)         not null,
   button_show_type     int                  not null,
   constraint PK_SYS_BUTTON primary key nonclustered (button_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_button')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'button_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按钮Id',
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_button')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'menu_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单Id',
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'menu_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_button')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'button_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按钮名称',
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_button')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'button_show_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_show_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '按钮显示类型(1=显示可用,2=显示不可用,3=不显示)',
   'user', @CurrentUser, 'table', 'sys_button', 'column', 'button_show_type'
go

/*==============================================================*/
/* Table: sys_menu                                              */
/*==============================================================*/
create table sys_menu (
   menu_id              varchar(36)          not null,
   menu_name            nvarchar(50)         not null,
   menu_icon            varchar(50)          null,
   menu_url             varchar(80)          null,
   menu_sort            int                  not null,
   parent_menu_id       varchar(36)          null,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_SYS_MENU primary key nonclustered (menu_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单id',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单名称',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_icon')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_icon'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单图标',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_icon'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_url')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_url'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单url',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'menu_sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单排序号',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'menu_sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'parent_menu_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'parent_menu_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父级菜单id',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'parent_menu_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'sys_menu', 'column', 'note'
go

/*==============================================================*/
/* Table: sys_ra_related                                        */
/*==============================================================*/
create table sys_ra_related (
   ra_related_id        varchar(36)          not null,
   role_id              varchar(36)          not null,
   authority_id         varchar(36)          not null,
   constraint PK_SYS_RA_RELATED primary key nonclustered (ra_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ra_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ra_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'ra_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色权限关联表id',
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'ra_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ra_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'role_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'role_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ra_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'authority_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'authority_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'sys_ra_related', 'column', 'authority_id'
go

/*==============================================================*/
/* Table: sys_role                                              */
/*==============================================================*/
create table sys_role (
   role_id              varchar(36)          not null,
   role_name            nvarchar(50)         not null,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_SYS_ROLE primary key nonclustered (role_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'role_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'role_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'role_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'role_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'sys_role', 'column', 'note'
go

/*==============================================================*/
/* Table: sys_ugr_related                                       */
/*==============================================================*/
create table sys_ugr_related (
   ugr_related_id       varchar(36)          not null,
   user_group_id        varchar(36)          not null,
   role_id              varchar(36)          not null,
   constraint PK_SYS_UGR_RELATED primary key nonclustered (ugr_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ugr_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ugr_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'ugr_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组角色管理表',
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'ugr_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ugr_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_group_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'user_group_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组id',
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'user_group_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ugr_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'role_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'sys_ugr_related', 'column', 'role_id'
go

/*==============================================================*/
/* Table: sys_ur_related                                        */
/*==============================================================*/
create table sys_ur_related (
   ur_related_id        varchar(36)          not null,
   user_id              varchar(36)          not null,
   role_id              varchar(36)          not null,
   constraint PK_SYS_UR_RELATED primary key nonclustered (ur_related_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ur_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ur_related_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'ur_related_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户角色管理表id',
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'ur_related_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ur_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户id',
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_ur_related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'role_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'role_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'sys_ur_related', 'column', 'role_id'
go

/*==============================================================*/
/* Table: sys_user                                              */
/*==============================================================*/
create table sys_user (
   user_id              varchar(36)          not null,
   user_name            varchar(20)          not null,
   user_nike_name       nvarchar(20)         null,
   user_pwd             varchar(50)          not null,
   user_sex             int                  null default 1,
   user_birthday        datetime             null,
   user_email           varchar(50)          null,
   user_qq              varchar(15)          null,
   user_wx              varchar(50)          null,
   user_avatar          varchar(150)         null,
   user_phone           varchar(11)          null,
   user_group_id        varchar(36)          null,
   user_status          int                  not null default 1,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_SYS_USER primary key nonclustered (user_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户id',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '账号',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_nike_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_nike_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '昵称',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_nike_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_pwd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_pwd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_pwd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_sex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_sex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_birthday')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_birthday'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_birthday'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮箱',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_qq')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_qq'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'qq',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_qq'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_wx')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_wx'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微信',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_wx'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_avatar')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_avatar'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '头像',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_avatar'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_phone')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_phone'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电话',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_phone'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_group_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_group_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属用户组',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_group_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_status')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_status'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户状态',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'user_status'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'sys_user', 'column', 'note'
go

/*==============================================================*/
/* Table: sys_user_group                                        */
/*==============================================================*/
create table sys_user_group (
   user_group_id        varchar(36)          not null,
   user_group_name      nvarchar(50)         not null,
   parent_user_group_id varchar(36)          null,
   create_user_id       varchar(36)          null,
   create_time          datetime             not null,
   edit_time            datetime             null,
   delete_sign          int                  not null default 1,
   delete_time          datetime             null,
   note                 nvarchar(2048)       null,
   constraint PK_SYS_USER_GROUP primary key nonclustered (user_group_id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_group_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'user_group_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组id',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'user_group_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_group_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'user_group_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组名称',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'user_group_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'parent_user_group_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'parent_user_group_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父级用户组id',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'parent_user_group_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_user_id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'create_user_id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'create_user_id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'create_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'create_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'create_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'edit_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'edit_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'edit_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_sign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'delete_sign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'delete_sign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'delete_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'delete_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'delete_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('sys_user_group')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'sys_user_group', 'column', 'note'
go

