﻿// <auto-generated />
using Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aggregate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CircleMemeber", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CircleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "CircleId");

                    b.HasIndex("CircleId");

                    b.ToTable("CircleMemeber");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            CircleId = 1L
                        },
                        new
                        {
                            UserId = 3L,
                            CircleId = 1L
                        },
                        new
                        {
                            UserId = 4L,
                            CircleId = 1L
                        },
                        new
                        {
                            UserId = 2L,
                            CircleId = 2L
                        },
                        new
                        {
                            UserId = 5L,
                            CircleId = 2L
                        },
                        new
                        {
                            UserId = 6L,
                            CircleId = 2L
                        },
                        new
                        {
                            UserId = 7L,
                            CircleId = 2L
                        },
                        new
                        {
                            UserId = 3L,
                            CircleId = 3L
                        },
                        new
                        {
                            UserId = 8L,
                            CircleId = 3L
                        });
                });

            modelBuilder.Entity("Domain.Entity.Activity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CircleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("TotalExpense")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CircleId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Domain.Entity.Circle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Circles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "통기타"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "축구"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "농구"
                        });
                });

            modelBuilder.Entity("Domain.Entity.Expense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ActivityId")
                        .HasColumnType("bigint");

                    b.Property<float>("Payment")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 20,
                            Email = "박@email.com",
                            IsPremium = true,
                            Name = "박"
                        },
                        new
                        {
                            Id = 2L,
                            Age = 21,
                            Email = "조@email.com",
                            IsPremium = true,
                            Name = "조"
                        },
                        new
                        {
                            Id = 3L,
                            Age = 22,
                            Email = "김@email.com",
                            IsPremium = false,
                            Name = "김"
                        },
                        new
                        {
                            Id = 4L,
                            Age = 23,
                            Email = "이@email.com",
                            IsPremium = false,
                            Name = "이"
                        },
                        new
                        {
                            Id = 5L,
                            Age = 24,
                            Email = "도@email.com",
                            IsPremium = false,
                            Name = "도"
                        },
                        new
                        {
                            Id = 6L,
                            Age = 24,
                            Email = "최@email.com",
                            IsPremium = false,
                            Name = "최"
                        },
                        new
                        {
                            Id = 7L,
                            Age = 24,
                            Email = "백@email.com",
                            IsPremium = false,
                            Name = "백"
                        },
                        new
                        {
                            Id = 8L,
                            Age = 24,
                            Email = "노@email.com",
                            IsPremium = false,
                            Name = "노"
                        },
                        new
                        {
                            Id = 9L,
                            Age = 24,
                            Email = "남@email.com",
                            IsPremium = false,
                            Name = "남"
                        },
                        new
                        {
                            Id = 10L,
                            Age = 24,
                            Email = "송@email.com",
                            IsPremium = false,
                            Name = "송"
                        });
                });

            modelBuilder.Entity("CircleMemeber", b =>
                {
                    b.HasOne("Domain.Entity.Circle", null)
                        .WithMany()
                        .HasForeignKey("CircleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Activity", b =>
                {
                    b.HasOne("Domain.Entity.Circle", "Circle")
                        .WithMany("Activies")
                        .HasForeignKey("CircleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Circle");
                });

            modelBuilder.Entity("Domain.Entity.Expense", b =>
                {
                    b.HasOne("Domain.Entity.Activity", "Activity")
                        .WithMany("Expenses")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Domain.Entity.Activity", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Domain.Entity.Circle", b =>
                {
                    b.Navigation("Activies");
                });
#pragma warning restore 612, 618
        }
    }
}
