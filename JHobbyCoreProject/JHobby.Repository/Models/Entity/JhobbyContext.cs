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

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MsgBoard> MsgBoards { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

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

        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
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

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Field).HasMaxLength(100);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.Property(e => e.Queue).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ActiveArea).HasMaxLength(20);
            entity.Property(e => e.ActiveCity).HasMaxLength(14);
            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(2)
                .IsUnicode(false);
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

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
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

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(256);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.CreatedAt, "IX_HangFire_State_CreatedAt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
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
