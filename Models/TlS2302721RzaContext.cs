using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace RZA_WebsiteJS.Models;

public partial class TlS2302721RzaContext : DbContext
{
    public TlS2302721RzaContext()
    {
    }

    public TlS2302721RzaContext(DbContextOptions<TlS2302721RzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Educationalbooking> Educationalbookings { get; set; }

    public virtual DbSet<Educationalticket> Educationaltickets { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<Zoobooking> Zoobookings { get; set; }

    public virtual DbSet<Zooticket> Zootickets { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attraction");

            entity.Property(e => e.AttractionId).HasColumnName("attractionID");
            entity.Property(e => e.Closingtime)
                .HasColumnType("time")
                .HasColumnName("closingtime");
            entity.Property(e => e.Entryfee).HasColumnName("entryfee");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Openingtime)
                .HasColumnType("time")
                .HasColumnName("openingtime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phoneNumber").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("lastName");
            entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");
            entity.Property(e => e.Passsword)
                .HasMaxLength(255)
                .HasColumnName("passsword");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Postcode)
                .HasMaxLength(8)
                .HasColumnName("postcode");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Educationalbooking>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.EducationalbookingId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("educationalbooking");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.EducationalbookingId).HasColumnName("educationalbookingID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Educationalbookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("edubk_fk_1");
        });

        modelBuilder.Entity<Educationalticket>(entity =>
        {
            entity.HasKey(e => e.EducationalbookingId).HasName("PRIMARY");

            entity.ToTable("educationaltickets");

            entity.HasIndex(e => e.AttractionId, "educationaltk_fk_2_idx");

            entity.Property(e => e.EducationalbookingId)
                .ValueGeneratedNever()
                .HasColumnName("educationalbookingID");
            entity.Property(e => e.AttractionId).HasColumnName("attractionID");
            entity.Property(e => e.Bookingdate).HasColumnName("bookingdate");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Prices).HasColumnName("prices");

            entity.HasOne(d => d.Attraction).WithMany(p => p.Educationaltickets)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("educationaltk_fk_2");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => new { e.RoomNumber, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("rooms");

            entity.HasIndex(e => e.TypeId, "rooms_fk_1_idx");

            entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");
            entity.Property(e => e.TypeId).HasColumnName("typeID");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .HasColumnName("roomType");

            entity.HasOne(d => d.Type).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rooms_fk_1");
        });

        modelBuilder.Entity<Roombooking>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.RoomNumber, e.StartDate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("roombookings");

            entity.HasIndex(e => e.RoomNumber, "roombookings_ibfk_1");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.EndDate).HasColumnName("endDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_2");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("type");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("typeID");
        });

        modelBuilder.Entity<Zoobooking>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.ZoobookingId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("zoobooking");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.ZoobookingId).HasColumnName("zoobookingID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Zoobookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zoobk_fk_1");
        });

        modelBuilder.Entity<Zooticket>(entity =>
        {
            entity.HasKey(e => new { e.ZooticketsId, e.ZoombookingId, e.AttractionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("zootickets");

            entity.HasIndex(e => e.ZoombookingId, "zootk_fk_1_idx");

            entity.HasIndex(e => e.AttractionId, "zootk_fk_2_idx");

            entity.Property(e => e.ZooticketsId).HasColumnName("zooticketsID");
            entity.Property(e => e.ZoombookingId).HasColumnName("zoombookingID");
            entity.Property(e => e.AttractionId).HasColumnName("attractionID");
            entity.Property(e => e.Bookingdate).HasColumnName("bookingdate");
            entity.Property(e => e.Fee).HasColumnName("fee");

            entity.HasOne(d => d.Attraction).WithMany(p => p.Zootickets)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zootk_fk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
