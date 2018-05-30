using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.Entity.Models
{
    public partial class GRWEBSITEContext : DbContext
    {
        public GRWEBSITEContext(DbContextOptions<GRWEBSITEContext> options)
       : base(options)
        {
        }
        public virtual DbSet<DictAuthorityType> DictAuthorityType { get; set; }
        public virtual DbSet<DictUserStatus> DictUserStatus { get; set; }
        public virtual DbSet<SysAmRelated> SysAmRelated { get; set; }
        public virtual DbSet<SysAuthority> SysAuthority { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysRaRelated> SysRaRelated { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUrRelated> SysUrRelated { get; set; }
        public virtual DbSet<SysUserGroup> SysUserGroup { get; set; }
        public virtual DbSet<SysUsers> SysUsers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=.;Database=GRWEBSITE;Integrated Security=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictAuthorityType>(entity =>
            {
                entity.ToTable("Dict_AuthorityType");

                entity.Property(e => e.AuthorityTypeName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<DictUserStatus>(entity =>
            {
                entity.ToTable("Dict_UserStatus");

                entity.Property(e => e.UserStatusName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SysAmRelated>(entity =>
            {
                entity.HasKey(e => e.AmRelatedId);

                entity.ToTable("Sys_AmRelated");

                entity.Property(e => e.AmRelatedId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SysAuthority>(entity =>
            {
                entity.HasKey(e => e.AuthorityId);

                entity.ToTable("Sys_Authority");

                entity.Property(e => e.AuthorityId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Sys_Menu");

                entity.Property(e => e.MenuId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(2048);
            });

            modelBuilder.Entity<SysRaRelated>(entity =>
            {
                entity.HasKey(e => e.RaRelatedId);

                entity.ToTable("Sys_RaRelated");

                entity.Property(e => e.RaRelatedId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Sys_Role");

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUrRelated>(entity =>
            {
                entity.HasKey(e => e.UrRelatedId);

                entity.ToTable("Sys_UrRelated");

                entity.Property(e => e.UrRelatedId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SysUserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId);

                entity.ToTable("Sys_UserGroup");

                entity.Property(e => e.UserGroupId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUsers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Sys_Users");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Sys_User__C9F28456C6913481")
                    .IsUnique();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Note).HasMaxLength(2048);

                entity.Property(e => e.UserAvatar)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserBirthday).HasColumnType("date");

                entity.Property(e => e.UserCreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(CONVERT([varchar],getdate(),(120)))");

                entity.Property(e => e.UserEditTime).HasColumnType("datetime");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(15)
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
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(substring([sys].[fn_sqlvarbasetostr](hashbytes('MD5','123456')),(3),(32)))");

                entity.Property(e => e.UserQq)
                    .HasColumnName("UserQQ")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserWx)
                    .HasColumnName("UserWX")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
