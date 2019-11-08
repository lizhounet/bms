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
        public virtual DbSet<BlogArticleBrowsing> BlogArticleBrowsing { get; set; }
        public virtual DbSet<BlogArticleLike> BlogArticleLike { get; set; }
        public virtual DbSet<BlogFriendshipLink> BlogFriendshipLink { get; set; }
        public virtual DbSet<BlogLable> BlogLable { get; set; }
        public virtual DbSet<BlogNavigationImg> BlogNavigationImg { get; set; }
        public virtual DbSet<BlogRelated> BlogRelated { get; set; }
        public virtual DbSet<DictAuthorityType> DictAuthorityType { get; set; }
        public virtual DbSet<SysAbRelated> SysAbRelated { get; set; }
        public virtual DbSet<SysAmRelated> SysAmRelated { get; set; }
        public virtual DbSet<SysAuthority> SysAuthority { get; set; }
        public virtual DbSet<SysButton> SysButton { get; set; }
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

                entity.ToTable("blog_article");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleBody)
                    .IsRequired()
                    .HasColumnName("article_body")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleBodyMarkdown)
                    .HasColumnName("article_body_markdown")
                    .HasColumnType("text");

                entity.Property(e => e.ArticleBodySummary)
                    .HasColumnName("article_body_summary")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ArticleSortValue)
                    .HasColumnName("article_sort_value")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArticleThrink)
                    .IsRequired()
                    .HasColumnName("article_thrink")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ArticleTitle)
                    .IsRequired()
                    .HasColumnName("article_title")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogArticleBrowsing>(entity =>
            {
                entity.ToTable("blog_article_browsing");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<BlogArticleLike>(entity =>
            {
                entity.ToTable("blog_article_like");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ArticleId)
                    .HasColumnName("article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<BlogFriendshipLink>(entity =>
            {
                entity.HasKey(e => e.FriendshipLinkId);

                entity.ToTable("blog_friendship_link");

                entity.Property(e => e.FriendshipLinkId)
                    .HasColumnName("friendship_link_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.FriendshipLinkEmail)
                    .IsRequired()
                    .HasColumnName("friendship_link_email")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.FriendshipLinkName)
                    .IsRequired()
                    .HasColumnName("friendship_link_name")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.FriendshipLinkSfsh)
                    .HasColumnName("friendship_link_sfsh")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FriendshipLinkSortValue)
                    .HasColumnName("friendship_link_sort_value")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FriendshipLinkUrl)
                    .IsRequired()
                    .HasColumnName("friendship_link_url")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogLable>(entity =>
            {
                entity.HasKey(e => e.LableId);

                entity.ToTable("blog_lable");

                entity.Property(e => e.LableId)
                    .HasColumnName("lable_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LableClickNum)
                    .HasColumnName("lable_click_num")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LableName)
                    .IsRequired()
                    .HasColumnName("lable_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LableSortValue)
                    .HasColumnName("lable_sort_value")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogNavigationImg>(entity =>
            {
                entity.HasKey(e => e.NavigationImgId);

                entity.ToTable("blog_navigation_img");

                entity.Property(e => e.NavigationImgId)
                    .HasColumnName("navigation_img_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NavigationImgDescribe)
                    .IsRequired()
                    .HasColumnName("navigation_img_describe")
                    .HasColumnType("varchar(2048)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgIsEnable)
                    .HasColumnName("navigation_img_is_enable")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.NavigationImgSortValue)
                    .HasColumnName("navigation_img_sort_value")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgUrl)
                    .IsRequired()
                    .HasColumnName("navigation_img_url")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<BlogRelated>(entity =>
            {
                entity.ToTable("blog_related");

                entity.Property(e => e.BlogRelatedId)
                    .HasColumnName("blog_related_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelatedArticleId)
                    .HasColumnName("related_article_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RelatedLableId)
                    .HasColumnName("related_lable_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<DictAuthorityType>(entity =>
            {
                entity.HasKey(e => e.AuthorityTypeId);

                entity.ToTable("dict_authority_type");

                entity.Property(e => e.AuthorityTypeId)
                    .HasColumnName("authority_type_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityTypeName)
                    .IsRequired()
                    .HasColumnName("authority_type_name")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<SysAbRelated>(entity =>
            {
                entity.HasKey(e => e.AbRelatedId);

                entity.ToTable("sys_ab_related");

                entity.Property(e => e.AbRelatedId)
                    .HasColumnName("ab_related_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnName("authority_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.ButtonId)
                    .IsRequired()
                    .HasColumnName("button_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysAmRelated>(entity =>
            {
                entity.HasKey(e => e.AmRelatedId);

                entity.ToTable("sys_am_related");

                entity.Property(e => e.AmRelatedId)
                    .HasColumnName("am_related_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnName("authority_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.MenuId)
                    .IsRequired()
                    .HasColumnName("menu_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.ToTable("sys_authority");

                entity.Property(e => e.AuthorityId)
                    .HasColumnName("authority_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityType)
                    .HasColumnName("authority_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<SysButton>(entity =>
            {
                entity.HasKey(e => e.ButtonId);

                entity.ToTable("sys_button");

                entity.Property(e => e.ButtonId)
                    .HasColumnName("button_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.ButtonName)
                    .IsRequired()
                    .HasColumnName("button_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ButtonShowType)
                    .HasColumnName("button_show_type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenuId)
                    .IsRequired()
                    .HasColumnName("menu_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("sys_menu");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MenuIcon)
                    .HasColumnName("menu_icon")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnName("menu_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MenuSort)
                    .HasColumnName("menu_sort")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenuUrl)
                    .HasColumnName("menu_url")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentMenuId)
                    .HasColumnName("parent_menu_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysRaRelated>(entity =>
            {
                entity.HasKey(e => e.RaRelatedId);

                entity.ToTable("sys_ra_related");

                entity.Property(e => e.RaRelatedId)
                    .HasColumnName("ra_related_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnName("authority_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("sys_role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysUgrRelated>(entity =>
            {
                entity.HasKey(e => e.UgrRelatedId);

                entity.ToTable("sys_ugr_related");

                entity.Property(e => e.UgrRelatedId)
                    .HasColumnName("ugr_related_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserGroupId)
                    .IsRequired()
                    .HasColumnName("user_group_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysUrRelated>(entity =>
            {
                entity.HasKey(e => e.UrRelatedId);

                entity.ToTable("sys_ur_related");

                entity.Property(e => e.UrRelatedId)
                    .HasColumnName("ur_related_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("role_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("sys_user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.UserAvatar)
                    .HasColumnName("user_avatar")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.UserBirthday)
                    .HasColumnName("user_birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserNikeName)
                    .HasColumnName("user_nike_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.UserPhone)
                    .HasColumnName("user_phone")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.UserPwd)
                    .IsRequired()
                    .HasColumnName("user_pwd")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UserQq)
                    .HasColumnName("user_qq")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.UserSex)
                    .HasColumnName("user_sex")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserStatus)
                    .HasColumnName("user_status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.UserWx)
                    .HasColumnName("user_wx")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("sys_user_group");

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasColumnName("create_user_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnName("delete_sign")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime)
                    .HasColumnName("delete_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditTime)
                    .HasColumnName("edit_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentUserGroupId)
                    .HasColumnName("parent_user_group_id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasColumnName("user_group_name")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
