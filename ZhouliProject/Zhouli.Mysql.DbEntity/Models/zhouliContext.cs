using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zhouli.Mysql.DbEntity.Models
{
    public partial class zhouliContext : DbContext
    {
        public zhouliContext()
        {
        }

        public zhouliContext(DbContextOptions<zhouliContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogArticle> BlogArticle { get; set; }
        public virtual DbSet<BlogArticleseeinfo> BlogArticleseeinfo { get; set; }
        public virtual DbSet<BlogFriendshiplink> BlogFriendshiplink { get; set; }
        public virtual DbSet<BlogLable> BlogLable { get; set; }
        public virtual DbSet<BlogNavigationimg> BlogNavigationimg { get; set; }
        public virtual DbSet<BlogRelated> BlogRelated { get; set; }
        public virtual DbSet<DictAuthoritytype> DictAuthoritytype { get; set; }
        public virtual DbSet<SysAmrelated> SysAmrelated { get; set; }
        public virtual DbSet<SysAuthority> SysAuthority { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRarelated> SysRarelated { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUgrrelated> SysUgrrelated { get; set; }
        public virtual DbSet<SysUrrelated> SysUrrelated { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUsergroup> SysUsergroup { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=123456;port=3306;database=zhouli;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogArticle>(entity =>
            {
                entity.HasKey(e => e.ArticleId);

                entity.ToTable("blog_article");

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

                entity.Property(e => e.ArticleCreateTime)
                    .HasColumnName("Article_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ArticleNote)
                    .HasColumnName("Article_Note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.ArticleSortValue)
                    .HasColumnName("Article_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ArticleTitle)
                    .IsRequired()
                    .HasColumnName("Article_Title")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ArticleUserId)
                    .IsRequired()
                    .HasColumnName("Article_UserId")
                    .HasColumnType("char(40)");

                entity.Property(e => e.ArticleUserNikeName)
                    .IsRequired()
                    .HasColumnName("Article_UserNikeName")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<BlogArticleseeinfo>(entity =>
            {
                entity.HasKey(e => e.ArticleSeeInfoArticleId);

                entity.ToTable("blog_articleseeinfo");

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

            modelBuilder.Entity<BlogFriendshiplink>(entity =>
            {
                entity.HasKey(e => e.FriendshipLinkId);

                entity.ToTable("blog_friendshiplink");

                entity.Property(e => e.FriendshipLinkId)
                    .HasColumnName("FriendshipLink_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FriendshipLinkEmail)
                    .HasColumnName("FriendshipLink_Email")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

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
                    .HasColumnName("FriendshipLink_Url")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<BlogLable>(entity =>
            {
                entity.HasKey(e => e.LableId);

                entity.ToTable("blog_lable");

                entity.HasIndex(e => e.LableName)
                    .HasName("Lable_Name")
                    .IsUnique();

                entity.Property(e => e.LableId)
                    .HasColumnName("Lable_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LableClickNum)
                    .HasColumnName("Lable_ClickNum")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LableCreateTime)
                    .HasColumnName("Lable_CreateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.LableName)
                    .IsRequired()
                    .HasColumnName("Lable_Name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LableNote)
                    .HasColumnName("Lable_Note")
                    .HasColumnType("varchar(2048)");

                entity.Property(e => e.LableSortValue)
                    .HasColumnName("Lable_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<BlogNavigationimg>(entity =>
            {
                entity.HasKey(e => e.NavigationImgId);

                entity.ToTable("blog_navigationimg");

                entity.Property(e => e.NavigationImgId)
                    .HasColumnName("NavigationImg_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NavigationImgDescribe)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Describe")
                    .HasColumnType("varchar(2048)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgSortValue)
                    .HasColumnName("NavigationImg_SortValue")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.NavigationImgUrl)
                    .IsRequired()
                    .HasColumnName("NavigationImg_Url")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<BlogRelated>(entity =>
            {
                entity.ToTable("blog_related");

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

            modelBuilder.Entity<DictAuthoritytype>(entity =>
            {
                entity.HasKey(e => e.AuthorityTypeId);

                entity.ToTable("dict_authoritytype");

                entity.Property(e => e.AuthorityTypeId).HasColumnType("int(11)");

                entity.Property(e => e.AuthorityTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<SysAmrelated>(entity =>
            {
                entity.HasKey(e => e.AmRelatedId);

                entity.ToTable("sys_amrelated");

                entity.Property(e => e.AmRelatedId).HasColumnType("char(40)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnType("char(40)");

                entity.Property(e => e.MenuId)
                    .IsRequired()
                    .HasColumnType("char(40)");
            });

            modelBuilder.Entity<SysAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.ToTable("sys_authority");

                entity.Property(e => e.AuthorityId).HasColumnType("char(40)");

                entity.Property(e => e.AuthorityType).HasColumnType("int(11)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("char(40)");

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

                entity.ToTable("sys_menu");

                entity.Property(e => e.MenuId).HasColumnType("char(40)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("char(40)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.MenuIcon).HasColumnType("varchar(10)");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MenuSort).HasColumnType("int(11)");

                entity.Property(e => e.MenuUrl).HasColumnType("varchar(80)");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentMenuId).HasColumnType("char(40)");
            });

            modelBuilder.Entity<SysRarelated>(entity =>
            {
                entity.HasKey(e => e.RaRelatedId);

                entity.ToTable("sys_rarelated");

                entity.Property(e => e.RaRelatedId).HasColumnType("char(40)");

                entity.Property(e => e.AuthorityId)
                    .IsRequired()
                    .HasColumnType("char(40)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("char(40)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("sys_role");

                entity.Property(e => e.RoleId).HasColumnType("char(40)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("char(40)");

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

            modelBuilder.Entity<SysUgrrelated>(entity =>
            {
                entity.HasKey(e => e.UgrRelatedId);

                entity.ToTable("sys_ugrrelated");

                entity.Property(e => e.UgrRelatedId).HasColumnType("char(40)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("char(40)");

                entity.Property(e => e.UserGroupId)
                    .IsRequired()
                    .HasColumnType("char(40)");
            });

            modelBuilder.Entity<SysUrrelated>(entity =>
            {
                entity.HasKey(e => e.UrRelatedId);

                entity.ToTable("sys_urrelated");

                entity.Property(e => e.UrRelatedId).HasColumnType("char(40)");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("char(40)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("char(40)");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("sys_user");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserName")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnType("char(40)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("char(40)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.UserAvatar).HasColumnType("varchar(150)");

                entity.Property(e => e.UserBirthday).HasColumnType("date");

                entity.Property(e => e.UserEmail).HasColumnType("varchar(50)");

                entity.Property(e => e.UserGroupId).HasColumnType("char(40)");

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

            modelBuilder.Entity<SysUsergroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("sys_usergroup");

                entity.Property(e => e.UserGroupId).HasColumnType("char(40)");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasColumnType("char(40)");

                entity.Property(e => e.DeleteSign)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasColumnType("varchar(2048)");

                entity.Property(e => e.ParentUserGroupId).HasColumnType("char(40)");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
