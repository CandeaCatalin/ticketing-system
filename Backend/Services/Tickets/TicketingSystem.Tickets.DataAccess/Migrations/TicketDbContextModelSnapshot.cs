﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.Tickets.DataAccess.Database;

#nullable disable

namespace TicketingSystem.Tickets.DataAccess.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    partial class TicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Closed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Opened")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TicketTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.TicketServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketServiceType");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketStatus");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.TicketType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketType");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.Ticket", b =>
                {
                    b.HasOne("TicketingSystem.Tickets.Domain.Models.TicketServiceType", "ServiceType")
                        .WithMany()
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Tickets.Domain.Models.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Tickets.Domain.Models.TicketType", "TicketType")
                        .WithMany()
                        .HasForeignKey("TicketTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketingSystem.Tickets.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");

                    b.Navigation("Status");

                    b.Navigation("TicketType");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}