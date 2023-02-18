﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.Tickets.DataAccess.Database;

#nullable disable

namespace TicketingSystem.Tickets.DataAccess.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    [Migration("20230218184830_ChangeDbSetsNames")]
    partial class ChangeDbSetsNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Opened")
                        .HasColumnType("datetime2");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserWhoCreatedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TicketTypeId");

                    b.HasIndex("UserWhoCreatedId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketingSystem.Tickets.Domain.Models.TicketPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketPriorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "LOW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MEDIUM"
                        },
                        new
                        {
                            Id = 3,
                            Name = "HIGH"
                        });
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

                    b.ToTable("TicketServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Service type 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Service type 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Service type 3"
                        });
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

                    b.ToTable("TicketStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Closed"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Open"
                        });
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

                    b.ToTable("TicketTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bug"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Feature Request"
                        },
                        new
                        {
                            Id = 3,
                            Name = "How To"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Technical Issue"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancellation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sales Question"
                        });
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
                    b.HasOne("TicketingSystem.Tickets.Domain.Models.TicketPriority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.HasOne("TicketingSystem.Tickets.Domain.Models.User", "UserWhoCreated")
                        .WithMany()
                        .HasForeignKey("UserWhoCreatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("ServiceType");

                    b.Navigation("Status");

                    b.Navigation("TicketType");

                    b.Navigation("UserWhoCreated");
                });
#pragma warning restore 612, 618
        }
    }
}
