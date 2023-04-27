﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class RentersContext : DbContext
{
    public RentersContext(DbContextOptions<RentersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8C81A463B");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Adress)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDDA03A7BA");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.RentsId).HasName("PK__Rent__2EC66D755B45210B");

            entity.ToTable("Rent");

            entity.Property(e => e.RentsId).HasColumnName("RentsID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductsId).HasColumnName("ProductsID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Rents)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rent__CustomerID__29572725");

            entity.HasOne(d => d.Products).WithMany(p => p.Rents)
                .HasForeignKey(d => d.ProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rent__ProductsID__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}