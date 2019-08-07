using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zhouli.DbEntity.Models
{
    public partial class ZhouLiContext : DbContext
    {
        public ZhouLiContext()
        {
        }

        public ZhouLiContext(DbContextOptions<ZhouLiContext> options)
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("Blog_Article");

                entity.Property(e => e.ArticleId).HasColumnName("Article_Id");

                entity.Property(e => e.ArticleBody)
                    .IsRequired()
                    .HasColumnName("Article_Body")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleBodyMarkdown)
                    .HasColumnName("Article_Body_Markdown")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleBodySummary)
                    .HasColumnName("Article_Body_Summary")
                    .HasMaxLength(100);

                entity.Property(e => e.ArticleSortValue).HasColumnName("Article_SortValue");

                entity.Property(e => e.ArticleThrink)
                    .IsRequired()
                    .HasColumnName("Article_Thrink")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ArticleTitle)
                    .IsRequired()
                    .HasColumnName("Article_Title")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<BlogArticleSeeInfo>(entity =>
            {
                entity.HasKey(e => e.ArticleSeeInfoArticleId);

                entity.ToTable("Blog_ArticleSeeInfo");

                entity.Property(e => e.ArticleSeeInfoArticleId).HasColumnName("ArticleSeeInfo_ArticleId");

                entity.Property(e => e.ArticleSeeInfoArticleBrowsingNum).HasColumnName("ArticleSeeInfo_ArticleBrowsingNum");

                entity.Property(e => e.ArticleSeeInfoArticleCommentNum).HasColumnName("ArticleSeeInfo_ArticleCommentNum");

                entity.Property(e => e.ArticleSeeInfoArticleLikeNum).HasColumnName("ArticleSeeInfo_ArticleLikeNum");
            });

            modelBuilder.Entity<BlogFriendshipLink>(entity =>
            {
                entity.HasKey(e => e.FriendshipLinkId);

                entity.ToTable("Blog_FriendshipLink");

                entity.Property(e => e.FriendshipLinkId).HasColumnName("FriendshipLink_Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.FriendshipLinkEmail)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FriendshipLinkName)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Name")
                    .HasMaxLength(40);

                entity.Property(e => e.FriendshipLinkSfsh).HasColumnName("FriendshipLink_Sfsh");

                entity.Property(e => e.FriendshipLinkSortValue).HasColumnName("FriendshipLink_SortValue");

                entity.Property(e => e.FriendshipLinkUrl)
                    .IsRequired()
                    .HasColumnName("FriendshipLink_Url")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<BlogLable>(entity =>
            {
                entity.HasKey(e => e.LableId);

                entity.ToTable("Blog_Lable");

                entity.HasIndex(e => e.LableName)
                    .HasName("UQ__Blog_Lab__AE42081BAF5C4716")
                    .IsUnique();

                entity.Property(e => e.LableId).HasColumnName("Lable_Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.LableClickNum).HasColumnName("Lable_ClickNum");

                entity.Property(e => e.LableName)
                    .IsRequired()
                    .HasColumnName("Lable_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.LableSortValue).HasColumnName("Lable_SortValue");

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<BlogNavigationImg>(entity =>
            {
                entity.HasKey(e => e.NavigationImgId);

                entity.ToTable("Blog_NavigationImg");

                entity.Property(e => e.NavigationImgId).HasColumnName("NavigationImg_Id");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.NavigationImgDescribe)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Describe")
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NavigationImgIsEnable)
                    .HasColumnName("NavigationImg_IsEnable")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NavigationImgSortValue).HasColumnName("NavigationImg_SortValue");

                entity.Property(e => e.NavigationImgUrl)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Url")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<BlogRelated>(entity =>
            {
                entity.ToTable("Blog_Related");

                entity.Property(e => e.BlogRelatedId).HasColumnName("Blog_RelatedId");

                entity.Property(e => e.RelatedArticleId).HasColumnName("Related_Article_Id");

                entity.Property(e => e.RelatedLableId).HasColumnName("Related_Lable_Id");
            });

            modelBuilder.Entity<DictAuthorityType>(entity =>
            {
                entity.HasKey(e => e.AuthorityTypeId);

                entity.ToTable("Dict_AuthorityType");

                entity.Property(e => e.AuthorityTypeId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorityTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SysAmRelated>(entity =>
            {
                entity.HasKey(e => e.AmRelatedId);

                entity.ToTable("Sys_AmRelated");

                entity.Property(e => e.AmRelatedId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.ToTable("Sys_Authority");

                entity.Property(e => e.AuthorityId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    ;

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Sys_Menu");

                entity.Property(e => e.MenuId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    ;

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.MenuIcon).HasMaxLength(50);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.ParentMenuId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRaRelated>(entity =>
            {
                entity.HasKey(e => e.RaRelatedId);

                entity.ToTable("Sys_RaRelated");

                entity.Property(e => e.RaRelatedId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    ;

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Sys_Role");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    ;

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUgrRelated>(entity =>
            {
                entity.HasKey(e => e.UgrRelatedId);

                entity.ToTable("Sys_UgrRelated");

                entity.Property(e => e.UgrRelatedId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    ;

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUrRelated>(entity =>
            {
                entity.HasKey(e => e.UrRelatedId);

                entity.ToTable("Sys_UrRelated");

                entity.Property(e => e.UrRelatedId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Sys_User");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Sys_User__C9F284560B22F238")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.UserAvatar)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserBirthday).HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserNikeName).HasMaxLength(20);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserQq)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserSex).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserWx)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SysUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("Sys_UserGroup");

                entity.Property(e => e.UserGroupId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteSign).HasDefaultValueSql("((1))");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.ParentUserGroupId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
