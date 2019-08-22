/*==============================================================*/
/* Database name:  ZhouLi                                       */
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2019-08-22 17:33:51                          */
/*==============================================================*/


drop database ZhouLi
go

/*==============================================================*/
/* Database: ZhouLi                                             */
/*==============================================================*/
create database ZhouLi
go

use ZhouLi
go

/*==============================================================*/
/* Table: Blog_Article                                          */
/*==============================================================*/
create table Blog_Article (
   Article_Id           int                  identity,
   Article_Title        varchar(50)          not null,
   Article_Thrink       varchar(100)         not null,
   Article_Body         text                 not null,
   Article_Body_Markdown text                 null,
   Article_Body_Summary varchar(100)         null,
   Article_SortValue    int                  not null default 0,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_BLOG_ARTICLE primary key nonclustered (Article_Id)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Blog_Article') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Blog_Article' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '博客文章表', 
   'user', @CurrentUser, 'table', 'Blog_Article'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Title')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Title'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章标题',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Thrink')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Thrink'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章图片',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Thrink'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Body')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章内容',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Body_Markdown')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body_Markdown'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章Markdown内容',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body_Markdown'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_Body_Summary')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body_Summary'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章摘要',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_Body_Summary'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Article_SortValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_SortValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序号',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Article_SortValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Article')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Blog_Article', 'column', 'Note'
go

/*==============================================================*/
/* Table: Blog_ArticleBrowsing                                  */
/*==============================================================*/
create table Blog_ArticleBrowsing (
   Id                   int                  identity,
   ArticleId            int                  not null,
   Ip                   varchar(20)          not null,
   CreateTime           datetime             not null,
   constraint PK_BLOG_ARTICLEBROWSING primary key nonclustered (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleBrowsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章浏览量表id',
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleBrowsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArticleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'ArticleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'ArticleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleBrowsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'Ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ip地址',
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleBrowsing')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_ArticleBrowsing', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: Blog_ArticleLike                                      */
/*==============================================================*/
create table Blog_ArticleLike (
   Id                   int                  identity,
   ArticleId            int                  not null,
   Ip                   varchar(20)          not null,
   CreateTime           datetime             not null,
   constraint PK_BLOG_ARTICLELIKE primary key nonclustered (Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleLike')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章点赞量表id',
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleLike')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArticleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'ArticleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'ArticleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleLike')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'Ip'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ip地址',
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_ArticleLike')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_ArticleLike', 'column', 'CreateTime'
go

/*==============================================================*/
/* Table: Blog_FriendshipLink                                   */
/*==============================================================*/
create table Blog_FriendshipLink (
   FriendshipLink_Id    int                  identity,
   FriendshipLink_Name  varchar(40)          not null,
   FriendshipLink_Url   varchar(40)          not null,
   FriendshipLink_Email varchar(40)          not null,
   FriendshipLink_SortValue int                  not null default 0,
   FriendshipLink_Sfsh  int                  not null default 0,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_BLOG_FRIENDSHIPLINK primary key nonclustered (FriendshipLink_Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '友情链接id',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站点名称',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_Url')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Url'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站点url',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_Email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '站长邮箱',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_SortValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_SortValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排序号',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_SortValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FriendshipLink_Sfsh')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Sfsh'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否审核',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'FriendshipLink_Sfsh'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_FriendshipLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Blog_FriendshipLink', 'column', 'Note'
go

/*==============================================================*/
/* Table: Blog_Lable                                            */
/*==============================================================*/
create table Blog_Lable (
   Lable_Id             int                  identity,
   Lable_Name           varchar(20)          not null,
   Lable_SortValue      int                  not null default 0,
   Lable_ClickNum       bigint               not null default 0,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_BLOG_LABLE primary key nonclustered (Lable_Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Lable_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客标签id',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Lable_Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签名称',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Lable_SortValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_SortValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签排序号',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_SortValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Lable_ClickNum')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_ClickNum'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签点击量',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Lable_ClickNum'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Lable')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Blog_Lable', 'column', 'Note'
go

/*==============================================================*/
/* Table: Blog_NavigationImg                                    */
/*==============================================================*/
create table Blog_NavigationImg (
   NavigationImg_Id     int                  identity,
   NavigationImg_Url    varchar(200)         not null,
   NavigationImg_SortValue int                  not null default 0,
   NavigationImg_Describe varchar(2048)        not null default '0',
   NavigationImg_IsEnable int                  not null default 1,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_BLOG_NAVIGATIONIMG primary key nonclustered (NavigationImg_Id)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavigationImg_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客轮播图id',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavigationImg_Url')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Url'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图url',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavigationImg_SortValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_SortValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图排序号',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_SortValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavigationImg_Describe')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Describe'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '轮播图描述',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_Describe'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NavigationImg_IsEnable')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_IsEnable'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否启用',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'NavigationImg_IsEnable'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_NavigationImg')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Blog_NavigationImg', 'column', 'Note'
go

/*==============================================================*/
/* Table: Blog_Related                                          */
/*==============================================================*/
create table Blog_Related (
   Blog_RelatedId       int                  identity,
   Related_Article_Id   int                  not null,
   Related_Lable_Id     int                  not null,
   constraint PK_BLOG_RELATED primary key nonclustered (Blog_RelatedId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Blog_RelatedId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Blog_RelatedId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '博客文章标签关联表',
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Blog_RelatedId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Related_Article_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Related_Article_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文章id',
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Related_Article_Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Blog_Related')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Related_Lable_Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Related_Lable_Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标签id',
   'user', @CurrentUser, 'table', 'Blog_Related', 'column', 'Related_Lable_Id'
go

/*==============================================================*/
/* Table: Dict_AuthorityType                                    */
/*==============================================================*/
create table Dict_AuthorityType (
   AuthorityTypeId      varchar(36)          not null,
   AuthorityTypeName    varchar(20)          not null,
   constraint PK_DICT_AUTHORITYTYPE primary key nonclustered (AuthorityTypeId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Dict_AuthorityType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityTypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Dict_AuthorityType', 'column', 'AuthorityTypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型id',
   'user', @CurrentUser, 'table', 'Dict_AuthorityType', 'column', 'AuthorityTypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Dict_AuthorityType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityTypeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Dict_AuthorityType', 'column', 'AuthorityTypeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型名称',
   'user', @CurrentUser, 'table', 'Dict_AuthorityType', 'column', 'AuthorityTypeName'
go

/*==============================================================*/
/* Table: Sys_AmRelated                                         */
/*==============================================================*/
create table Sys_AmRelated (
   AmRelatedId          varchar(36)          not null,
   AuthorityId          varchar(36)          not null,
   MenuId               varchar(36)          not null,
   constraint PK_SYS_AMRELATED primary key nonclustered (AmRelatedId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_AmRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AmRelatedId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'AmRelatedId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限菜单关联id',
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'AmRelatedId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_AmRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'AuthorityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'AuthorityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_AmRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'MenuId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单id',
   'user', @CurrentUser, 'table', 'Sys_AmRelated', 'column', 'MenuId'
go

/*==============================================================*/
/* Table: Sys_Authority                                         */
/*==============================================================*/
create table Sys_Authority (
   AuthorityId          varchar(36)          not null,
   AuthorityType        int                  not null,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_SYS_AUTHORITY primary key nonclustered (AuthorityId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'AuthorityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'AuthorityId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'AuthorityType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限类型',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'AuthorityType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Authority')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Sys_Authority', 'column', 'Note'
go

/*==============================================================*/
/* Table: Sys_Menu                                              */
/*==============================================================*/
create table Sys_Menu (
   MenuId               varchar(36)          not null,
   MenuName             varchar(50)          not null,
   MenuIcon             varchar(50)          null,
   MenuUrl              varchar(80)          null,
   MenuSort             int                  not null,
   ParentMenuId         varchar(36)          null,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_SYS_MENU primary key nonclustered (MenuId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单id',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单名称',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuIcon')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuIcon'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单图标',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuIcon'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单url',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MenuSort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuSort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '菜单排序号',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'MenuSort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentMenuId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'ParentMenuId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父级菜单id',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'ParentMenuId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Menu')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Sys_Menu', 'column', 'Note'
go

/*==============================================================*/
/* Table: Sys_RaRelated                                         */
/*==============================================================*/
create table Sys_RaRelated (
   RaRelatedId          varchar(36)          not null,
   RoleId               varchar(36)          not null,
   AuthorityId          varchar(36)          not null,
   constraint PK_SYS_RARELATED primary key nonclustered (RaRelatedId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RaRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RaRelatedId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'RaRelatedId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色权限关联表id',
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'RaRelatedId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RaRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'RoleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_RaRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AuthorityId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'AuthorityId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权限id',
   'user', @CurrentUser, 'table', 'Sys_RaRelated', 'column', 'AuthorityId'
go

/*==============================================================*/
/* Table: Sys_Role                                              */
/*==============================================================*/
create table Sys_Role (
   RoleId               varchar(36)          not null,
   RoleName             varchar(50)          not null,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_SYS_ROLE primary key nonclustered (RoleId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'RoleId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'RoleName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色名称',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'RoleName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Sys_Role', 'column', 'Note'
go

/*==============================================================*/
/* Table: Sys_UgrRelated                                        */
/*==============================================================*/
create table Sys_UgrRelated (
   UgrRelatedId         varchar(36)          not null,
   UserGroupId          varchar(36)          not null,
   RoleId               varchar(36)          not null,
   constraint PK_SYS_UGRRELATED primary key nonclustered (UgrRelatedId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UgrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UgrRelatedId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'UgrRelatedId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组角色管理表',
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'UgrRelatedId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UgrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserGroupId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'UserGroupId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组id',
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'UserGroupId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UgrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'Sys_UgrRelated', 'column', 'RoleId'
go

/*==============================================================*/
/* Table: Sys_UrRelated                                         */
/*==============================================================*/
create table Sys_UrRelated (
   UrRelatedId          varchar(36)          not null,
   UserId               varchar(36)          not null,
   RoleId               varchar(36)          not null,
   constraint PK_SYS_URRELATED primary key nonclustered (UrRelatedId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UrRelatedId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'UrRelatedId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户角色管理表id',
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'UrRelatedId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'UserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户id',
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UrRelated')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RoleId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'RoleId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色id',
   'user', @CurrentUser, 'table', 'Sys_UrRelated', 'column', 'RoleId'
go

/*==============================================================*/
/* Table: Sys_User                                              */
/*==============================================================*/
create table Sys_User (
   UserId               varchar(36)          not null,
   UserName             varchar(20)          not null,
   UserNikeName         varchar(20)          null,
   UserPwd              varchar(50)          not null,
   UserSex              int                  null default 1,
   UserBirthday         datetime             null,
   UserEmail            varchar(50)          null,
   UserQq               varchar(15)          null,
   UserWx               varchar(50)          null,
   UserAvatar           varchar(150)         null,
   UserPhone            varchar(11)          null,
   UserGroupId          varchar(36)          null,
   UserStatus           int                  not null default 1,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_SYS_USER primary key nonclustered (UserId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户id',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '账号',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserNikeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserNikeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '昵称',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserNikeName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserPwd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserPwd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserPwd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserSex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserSex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserSex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserBirthday')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserBirthday'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '生日',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserBirthday'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserEmail')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserEmail'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮箱',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserEmail'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserQq')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserQq'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'qq',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserQq'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserWx')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserWx'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微信',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserWx'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserAvatar')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserAvatar'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '头像',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserAvatar'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserPhone')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserPhone'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电话',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserPhone'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserGroupId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserGroupId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属用户组',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserGroupId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户状态',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'UserStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Sys_User', 'column', 'Note'
go

/*==============================================================*/
/* Table: Sys_UserGroup                                         */
/*==============================================================*/
create table Sys_UserGroup (
   UserGroupId          varchar(36)          not null,
   UserGroupName        varchar(50)          not null,
   ParentUserGroupId    varchar(36)          null,
   CreateUserId         varchar(36)          null,
   CreateTime           datetime             not null,
   EditTime             datetime             null,
   DeleteSign           int                  not null default 1,
   DeleteTime           datetime             null,
   Note                 varchar(2048)        null,
   constraint PK_SYS_USERGROUP primary key nonclustered (UserGroupId)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserGroupId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'UserGroupId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组id',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'UserGroupId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserGroupName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'UserGroupName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户组名称',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'UserGroupName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentUserGroupId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'ParentUserGroupId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '父级用户组id',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'ParentUserGroupId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'CreateUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人id',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'CreateUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EditTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'EditTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '修改时间',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'EditTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteSign')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'DeleteSign'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除标识',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'DeleteSign'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DeleteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'DeleteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '删除时间',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'DeleteTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Sys_UserGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Note')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'Note'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'Sys_UserGroup', 'column', 'Note'
go

