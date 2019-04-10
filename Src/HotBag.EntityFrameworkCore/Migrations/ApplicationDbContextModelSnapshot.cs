﻿// <auto-generated />
using System;
using HotBag.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotBag.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotBag.AppUser.HotBagApplicationModule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("ModuleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("HotBagApplicationModule");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagApplicationModulePermissionLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<long>("HotBagApplicationModuleId");

                    b.Property<int>("PermissionLevel");

                    b.HasKey("Id");

                    b.HasIndex("HotBagApplicationModuleId");

                    b.ToTable("HotBagApplicationModulePermissionLevel");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagPasswordHistoryLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HashedPassword")
                        .IsRequired();

                    b.Property<DateTime>("Timestamp");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HotBagPasswordHistoryLog");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("HotBagRole");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagRoleApplicationModule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ApplicationModuleId");

                    b.Property<long?>("ApplicationModulePermissionLevelId");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationModuleId");

                    b.HasIndex("ApplicationModulePermissionLevelId");

                    b.HasIndex("RoleId");

                    b.ToTable("HotBagRoleApplicationModule");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("HashedPassword")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.Property<int?>("TanentIdId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TanentIdId");

                    b.ToTable("HotBagUser");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUserRoles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("RoleIdId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleIdId");

                    b.HasIndex("UserId");

                    b.ToTable("HotBagUserRoles");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUserStatusLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<DateTime>("Timestamp");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HotBagUserStatusLog");
                });

            modelBuilder.Entity("HotBag.Core.Entity.TestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TestName");

                    b.Property<string>("TestProp1");

                    b.Property<int>("TestProp2");

                    b.Property<DateTime>("TestProp3");

                    b.HasKey("Id");

                    b.ToTable("TestEntity");
                });

            modelBuilder.Entity("HotBag.Tanents.TanentConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEmailConfirmationRequired");

                    b.Property<bool>("IsHardPasswordIsRequired");

                    b.Property<bool>("IsUseDifferentDatabase");

                    b.Property<bool>("IsUsernameLoginIsEnabled");

                    b.Property<int>("TanentIdId");

                    b.HasKey("Id");

                    b.HasIndex("TanentIdId");

                    b.ToTable("TanentConfiguration");
                });

            modelBuilder.Entity("HotBag.Tanents.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConnectionString");

                    b.Property<string>("Hostnames");

                    b.Property<string>("Name");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagApplicationModulePermissionLevel", b =>
                {
                    b.HasOne("HotBag.AppUser.HotBagApplicationModule", "HotBagApplicationModule")
                        .WithMany()
                        .HasForeignKey("HotBagApplicationModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagPasswordHistoryLog", b =>
                {
                    b.HasOne("HotBag.AppUser.HotBagUser", "HotBagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagRoleApplicationModule", b =>
                {
                    b.HasOne("HotBag.AppUser.HotBagApplicationModule", "HotBagApplicationModule")
                        .WithMany()
                        .HasForeignKey("ApplicationModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotBag.AppUser.HotBagApplicationModulePermissionLevel", "HotBagApplicationModulePermissionLevel")
                        .WithMany()
                        .HasForeignKey("ApplicationModulePermissionLevelId");

                    b.HasOne("HotBag.AppUser.HotBagRole", "HotBagRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUser", b =>
                {
                    b.HasOne("HotBag.Tanents.Tenant", "Tanents")
                        .WithMany()
                        .HasForeignKey("TanentIdId");
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUserRoles", b =>
                {
                    b.HasOne("HotBag.AppUser.HotBagRole", "HotBagRole")
                        .WithMany()
                        .HasForeignKey("RoleIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotBag.AppUser.HotBagUser", "HotBagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotBag.AppUser.HotBagUserStatusLog", b =>
                {
                    b.HasOne("HotBag.AppUser.HotBagUser", "HotBagUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotBag.Tanents.TanentConfiguration", b =>
                {
                    b.HasOne("HotBag.Tanents.Tenant", "Tanents")
                        .WithMany()
                        .HasForeignKey("TanentIdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
