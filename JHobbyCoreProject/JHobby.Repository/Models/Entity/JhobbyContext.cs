using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Repository.Models.Entity;

public partial class JhobbyContext : DbContext
{
    public JhobbyContext()
    {
    }

    public JhobbyContext(DbContextOptions<JhobbyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityImage> ActivityImages { get; set; }

    public virtual DbSet<ActivityUser> ActivityUsers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MsgBoard> MsgBoards { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Wish> Wishes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=JHobby;Integrated Security=true;TrustServerCertificate=true;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("Activity");

            entity.Property(e => e.ActivityArea).HasMaxLength(5);
            entity.Property(e => e.ActivityCity).HasMaxLength(50);
            entity.Property(e => e.ActivityLocation).HasMaxLength(70);
            entity.Property(e => e.ActivityName).HasMaxLength(20);
            entity.Property(e => e.ActivityStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.JoinDeadLine).HasColumnType("datetime");
            entity.Property(e => e.JoinFee).HasColumnType("money");
            entity.Property(e => e.Payment)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Activity_Category");
        });

        modelBuilder.Entity<ActivityImage>(entity =>
        {
            entity.ToTable("ActivityImage");

            entity.Property(e => e.ImageName).HasMaxLength(100);
            entity.Property(e => e.IsCover).HasColumnName("isCover");
            entity.Property(e => e.UploadTime).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityImages)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_ActivityImage_Activity");
        });

        modelBuilder.Entity<ActivityUser>(entity =>
        {
            entity.ToTable("ActivityUser");

            entity.Property(e => e.ReviewStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ReviewTime).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.ActivityUsers)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_ActivityUser_Activity");

            entity.HasOne(d => d.Member).WithMany(p => p.ActivityUsers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_ActivityUser_Member");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(5);
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId);

            entity.ToTable("CategoryDetail");

            entity.Property(e => e.TypeName).HasMaxLength(20);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryDetails)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_CategoryDetail_Category");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AcitveCity).HasMaxLength(14);
            entity.Property(e => e.ActiveArea).HasMaxLength(20);
            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.HeadShot).HasMaxLength(13);
            entity.Property(e => e.IdentityCard).HasMaxLength(10);
            entity.Property(e => e.LastSignIn).HasColumnType("datetime");
            entity.Property(e => e.MemberName).HasMaxLength(16);
            entity.Property(e => e.NickName).HasMaxLength(16);
            entity.Property(e => e.OnlineStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MsgBoard>(entity =>
        {
            entity.ToTable("MsgBoard");

            entity.Property(e => e.MessageTime).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.MsgBoards)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_MsgBoard_Activity");

            entity.HasOne(d => d.Member).WithMany(p => p.MsgBoards)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_MsgBoard_Member");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.ToTable("Score");

            entity.Property(e => e.EvaluationTime).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.Scores)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_Score_Activity");

            entity.HasOne(d => d.Member).WithMany(p => p.Scores)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Score_Member");
        });

        modelBuilder.Entity<Wish>(entity =>
        {
            entity.ToTable("Wish");

            entity.Property(e => e.AddTime).HasColumnType("datetime");

            entity.HasOne(d => d.Activity).WithMany(p => p.Wishes)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_Wish_Activity");

            entity.HasOne(d => d.Member).WithMany(p => p.Wishes)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Wish_Member");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
