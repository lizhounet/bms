using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zhouli.DbEntity.Models
{
    public partial class ZhouLiContextNew : DbContext
    {
        public ZhouLiContextNew()
        {
        }

        public ZhouLiContextNew(DbContextOptions<ZhouLiContextNew> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogArticle> BlogArticle { get; set; }
        public virtual DbSet<BlogArticleSeeInfo> BlogArticleSeeInfo { get; set; }
        public virtual DbSet<BlogFriendshipLink> BlogFriendshipLink { get; set; }
        public virtual DbSet<BlogLable> BlogLable { get; set; }
        public virtual DbSet<BlogNavigationImg> BlogNavigationImg { get; set; }
        public virtual DbSet<BlogRelated> BlogRelated { get; set; }
        public virtual DbSet<DictAuthorityType> DictAuthorityType { get; set; }
        public virtual DbSet<SysAmRelated> SysAmRelated { get; set; }
        public virtual DbSet<SysAuthority> SysAuthority { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRaRelated> SysRaRelated { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUgrRelated> SysUgrRelated { get; set; }
        public virtual DbSet<SysUrRelated> SysUrRelated { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserGroup> SysUserGroup { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=123456;port=3306;database=ZhouLi;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("Blog_Article");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("Article_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleBody)
                    .IsRequired()
                    .HasColumnName("Article_Body")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleBodyMarkdown)
                    .HasColumnName("Article_Body_Markdown")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleSortValue)
                    .HasColumnName("Article_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArticleTitle)
                    .IsRequired()
                    .HasColumnName("Article_Title")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ArticleThrink)
                    .HasColumnName("Article_Thrink")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ArticleBodySummary)
                  .HasColumnName("Article_Body_Summary")
                  .HasColumnType("varchar(100)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogArticleSeeInfo>(entity =>
            {
                entity.HasKey(e => e.ArticleSeeInfoArticleId);

                entity.ToTable("Blog_ArticleSeeInfo");

                entity.Property(e => e.ArticleSeeInfoArticleId)
                    .HasColumnName("ArticleSeeInfo_ArticleId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleSeeInfoArticleBrowsingNum)
                    .HasColumnName("ArticleSeeInfo_ArticleBrowsingNum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArticleSeeInfoArticleCommentNum)
                    .HasColumnName("ArticleSeeInfo_ArticleCommentNum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArticleSeeInfoArticleLikeNum)
                    .HasColumnName("ArticleSeeInfo_ArticleLikeNum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<BlogFriendshipLink>(entity =>
            {
                entity.HasKey(e => e.FriendshipLinkId);

                entity.ToTable("Blog_FriendshipLink");

                entity.Property(e => e.FriendshipLinkId)
                    .HasColumnName("FriendshipLink_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.FriendshipLinkEmail)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Email")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.FriendshipLinkName)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Name")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.FriendshipLinkSfsh)
                    .HasColumnName("FriendshipLink_Sfsh")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FriendshipLinkSortValue)
                    .HasColumnName("FriendshipLink_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FriendshipLinkUrl)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Url")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogLable>(entity =>
            {
                entity.HasKey(e => e.LableId);

                entity.ToTable("Blog_Lable");

                entity.HasIndex(e => e.LableName)
                    .HasName("Lable_Name")
                    .IsUnique();

                entity.Property(e => e.LableId)
                    .HasColumnName("Lable_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.LableClickNum)
                    .HasColumnName("Lable_ClickNum")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LableName)
                    .IsRequired()
                    .HasColumnName("Lable_Name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LableSortValue)
                    .HasColumnName("Lable_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogNavigationImg>(entity =>
            {
                entity.HasKey(e => e.NavigationImgId);

                entity.ToTable("Blog_NavigationImg");

                entity.Property(e => e.NavigationImgId)
                    .HasColumnName("NavigationImg_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.NavigationImgDescribe)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Describe")
                    .HasColumnType("varchar(2048)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgIsEnable)
                    .HasColumnName("NavigationImg_IsEnable")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NavigationImgSortValue)
                    .HasColumnName("NavigationImg_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgUrl)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Url")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogRelated>(entity =>
            {
                entity.ToTable("Blog_Related");

                entity.Property(e => e.BlogRelatedId)
                    .HasColumnName("Blog_RelatedId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelatedArticleId)
                    .HasColumnName("Related_Article_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelatedLableId)
                    .HasColumnName("Related_Lable_Id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<DictAuthorityType>(entity =>
            {
                entity.HasKey(e => e.AuthorityTypeId);

                entity.ToTable("Dict_AuthorityType");

                entity.Property(e => e.AuthorityTypeId).HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<SysAmRelated>(entity =>
            {
                entity.HasKey(e => e.AmRelatedId);

                entity.ToTable("Sys_AmRelated");

                entity.Property(e => e.AmRelatedId).HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.MenuId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.ToTable("Sys_Authority");

                entity.Property(e => e.AuthorityId).HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityType).HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Sys_Menu");

                entity.Property(e => e.MenuId).HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.MenuIcon).HasColumnType("varchar(50)");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MenuSort).HasColumnType("int(11)");

                entity.Property(e => e.MenuUrl).HasColumnType("varchar(80)");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentMenuId).HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysRaRelated>(entity =>
            {
                entity.HasKey(e => e.RaRelatedId);

                entity.ToTable("Sys_RaRelated");

                entity.Property(e => e.RaRelatedId).HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Sys_Role");

                entity.Property(e => e.RoleId).HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysUgrRelated>(entity =>
            {
                entity.HasKey(e => e.UgrRelatedId);

                entity.ToTable("Sys_UgrRelated");

                entity.Property(e => e.UgrRelatedId).HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserGroupId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysUrRelated>(entity =>
            {
                entity.HasKey(e => e.UrRelatedId);

                entity.ToTable("Sys_UrRelated");

                entity.Property(e => e.UrRelatedId).HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Sys_User");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserName")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.UserAvatar).HasColumnType("varchar(150)");

                entity.Property(e => e.UserBirthday).HasColumnType("date");

                entity.Property(e => e.UserEmail).HasColumnType("varchar(50)");

                entity.Property(e => e.UserGroupId).HasColumnType("varchar(36)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserNikeName).HasColumnType("varchar(20)");

                entity.Property(e => e.UserPhone).HasColumnType("varchar(11)");

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserQq).HasColumnType("varchar(15)");

                entity.Property(e => e.UserSex)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserStatus)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserWx).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("Sys_UserGroup");

                entity.Property(e => e.UserGroupId).HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentUserGroupId).HasColumnType("varchar(36)");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}