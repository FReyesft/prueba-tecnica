using System;
using System.Collections.Generic;
using Inmersys.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmersys.Api.Data.Context;

public partial class InmersysDbContext : DbContext
{
    public InmersysDbContext()
    {
    }

    public InmersysDbContext(DbContextOptions<InmersysDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employees> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__employee__C52E0BA87656FEF2");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
