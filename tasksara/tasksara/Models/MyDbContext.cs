using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tasksara.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=table1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF17A2680DD");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmailEmployee).HasMaxLength(150);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.NameEmployee).HasMaxLength(100);
            entity.Property(e => e.PasswordEmployee).HasMaxLength(255);

            entity.HasOne(d => d.Manager).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Managers");

            entity.HasMany(d => d.Tasks).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeTask",
                    r => r.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeT__TaskI__52593CB8"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeT__Emplo__5165187F"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "TaskId").HasName("PK__Employee__7D16DB6C16F2DF1C");
                        j.ToTable("EmployeeTasks");
                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
                        j.IndexerProperty<int>("TaskId").HasColumnName("TaskID");
                    });
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Managers__3BA2AA81F342A1B0");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.EmailManager).HasMaxLength(150);
            entity.Property(e => e.NameManager).HasMaxLength(100);
            entity.Property(e => e.PasswordManager).HasMaxLength(255);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D1CBA96E0F");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.TaskName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
