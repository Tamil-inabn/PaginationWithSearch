using System;
using System.Collections.Generic;
using CopyData.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace CopyData.DbContexts;

public partial class SampleContext : DbContext
{
    public SampleContext()
    {
    }

    public SampleContext(DbContextOptions<SampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CIPL1309_DOTNET\\MSSQLSERVER19;Initial Catalog=sample;User ID=sa;Password=Colan123;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Employee1).HasName("PK__Employee__AA4A8715542736A1");

            entity.ToTable("Employee");

            entity.Property(e => e.Employee1).HasColumnName("Employee");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Dob)
                .HasMaxLength(50)
                .HasColumnName("DOB");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMpName");
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Govid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GOVID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
