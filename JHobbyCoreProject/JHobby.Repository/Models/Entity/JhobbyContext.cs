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
            entity
                .HasNoKey()
                .ToTable("Activity");

            entity.Property(e => e.ActivityArea)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.ActivityCity)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.ActivityId).ValueGeneratedOnAdd();
            entity.Property(e => e.ActivityLocation)
                .HasMaxLength(70)
                .IsFixedLength();
            entity.Property(e => e.ActivityName).HasMaxLength(20);
            entity.Property(e => e.ActivityNotes)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.JoinFee).HasColumnType("money");
            entity.Property(e => e.Payment)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ActivityImage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ActivityImage");

            entity.Property(e => e.ActivityId)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ActivityID");
            entity.Property(e => e.ActivityImage1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ActivityImage");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.IsCover).HasColumnName("isCover");
            entity.Property(e => e.UploadTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ActivityUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ActivityUser");

            entity.Property(e => e.ActivityUserId).ValueGeneratedOnAdd();
            entity.Property(e => e.ReviewStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.CategoryName).HasMaxLength(10);
            entity.Property(e => e.TypeName).HasMaxLength(5);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Member");

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
            entity.Property(e => e.IdentityCard).HasMaxLength(50);
            entity.Property(e => e.LastSignIn).HasColumnType("datetime");
            entity.Property(e => e.MemberId).ValueGeneratedOnAdd();
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
            entity
                .HasNoKey()
                .ToTable("MsgBoard");

            entity.Property(e => e.MessageTime).HasColumnType("datetime");
            entity.Property(e => e.MsgBoardId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Score");

            entity.Property(e => e.EvaluationTime).HasColumnType("datetime");
            entity.Property(e => e.ScoreId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Wish>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Wish");

            entity.Property(e => e.AddTime).HasColumnType("datetime");
            entity.Property(e => e.WishId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
