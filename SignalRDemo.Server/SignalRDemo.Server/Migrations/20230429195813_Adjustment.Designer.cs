﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SignalRDemo.Server.Infrastructure.Data;

#nullable disable

namespace SignalRDemo.Server.Migrations
{
    [DbContext(typeof(DeclarationsDbContext))]
    [Migration("20230429195813_Adjustment")]
    partial class Adjustment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "50999c17-15c6-49a3-a8e7-72931ec8d839",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d",
                            RoleId = "50999c17-15c6-49a3-a8e7-72931ec8d839"
                        },
                        new
                        {
                            UserId = "07636587-5345-4130-9ec3-74c458d784ce",
                            RoleId = "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SignalRDemo.Server.Application.Models.Declaration", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeclarantId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("JurisdictionCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("NetMass")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeclarantId");

                    b.HasIndex("JurisdictionCode");

                    b.ToTable("Declarations");

                    b.HasData(
                        new
                        {
                            Id = "b9f69a98-c2dc-4dcd-b74f-60f9b9fa1a93",
                            CreationDate = new DateTime(2023, 4, 26, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3648),
                            DeclarantId = "76f2774d-98c5-4e8e-aee6-66194c03c16d",
                            Description = "Test GB declaration 1",
                            JurisdictionCode = "GB",
                            NetMass = 80m
                        },
                        new
                        {
                            Id = "877e122b-fba2-4870-bcc0-54a2cff9f750",
                            CreationDate = new DateTime(2023, 4, 27, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3661),
                            DeclarantId = "76f2774d-98c5-4e8e-aee6-66194c03c16d",
                            Description = "Test BE declaration 1",
                            JurisdictionCode = "BE",
                            NetMass = 60m
                        },
                        new
                        {
                            Id = "6162a110-3105-4b43-854e-95eee46c0a83",
                            CreationDate = new DateTime(2023, 4, 28, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3665),
                            DeclarantId = "76f2774d-98c5-4e8e-aee6-66194c03c16d",
                            Description = "Test DE declaration 1",
                            JurisdictionCode = "DE",
                            NetMass = 50m
                        },
                        new
                        {
                            Id = "8bea2dc7-3b0a-4e7e-a427-f53954f632dc",
                            CreationDate = new DateTime(2023, 4, 28, 7, 58, 13, 481, DateTimeKind.Utc).AddTicks(3829),
                            DeclarantId = "07636587-5345-4130-9ec3-74c458d784ce",
                            Description = "Test GB declaration 2",
                            JurisdictionCode = "GB",
                            NetMass = 90m
                        },
                        new
                        {
                            Id = "7a9250a6-4537-4487-b174-ff8a3f76a6cc",
                            CreationDate = new DateTime(2023, 4, 29, 7, 58, 13, 481, DateTimeKind.Utc).AddTicks(3844),
                            DeclarantId = "07636587-5345-4130-9ec3-74c458d784ce",
                            Description = "Test BE declaration 2",
                            JurisdictionCode = "BE",
                            NetMass = 70m
                        },
                        new
                        {
                            Id = "167f57b9-ca9f-4a03-9639-67b1582ba449",
                            CreationDate = new DateTime(2023, 4, 29, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3850),
                            DeclarantId = "07636587-5345-4130-9ec3-74c458d784ce",
                            Description = "Test DE declaration 2",
                            JurisdictionCode = "DE",
                            NetMass = 40m
                        });
                });

            modelBuilder.Entity("SignalRDemo.Server.Application.Models.Jurisdiction", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Jurisdictions");

                    b.HasData(
                        new
                        {
                            Code = "GB",
                            DisplayColor = "blue"
                        },
                        new
                        {
                            Code = "BE",
                            DisplayColor = "orange"
                        },
                        new
                        {
                            Code = "DE",
                            DisplayColor = "olive"
                        },
                        new
                        {
                            Code = "IE",
                            DisplayColor = "green"
                        },
                        new
                        {
                            Code = "NL",
                            DisplayColor = "aqua"
                        },
                        new
                        {
                            Code = "PL",
                            DisplayColor = "red"
                        });
                });

            modelBuilder.Entity("SignalRDemo.Server.Application.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "76f2774d-98c5-4e8e-aee6-66194c03c16d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8717b0bc-8392-48fe-b1bd-462b91106527",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEL/z0xcQmmTq78jUt3zf1pFdKvJEyRQS55vqusaf55p72c5id0zJbwL+wtqtpNMzOQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fe0b4715-463a-4929-8fa2-33e90aa07405",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "07636587-5345-4130-9ec3-74c458d784ce",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "084972a8-1f90-4f74-8ccf-5bd98f19253c",
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEB1BziAuWqUGsWvLJSp+pF16+93fjnljp1sVDNsRMwfS84USrqNg9TdqAxOceWFyCA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e63ba252-8355-42e4-b27d-80cc778d88d0",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("UserJurisdiction", b =>
                {
                    b.Property<string>("JurisdictionCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("JurisdictionCode", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserJurisdiction");

                    b.HasData(
                        new
                        {
                            JurisdictionCode = "GB",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "IE",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "NL",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "PL",
                            UserId = "76f2774d-98c5-4e8e-aee6-66194c03c16d"
                        },
                        new
                        {
                            JurisdictionCode = "GB",
                            UserId = "07636587-5345-4130-9ec3-74c458d784ce"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "07636587-5345-4130-9ec3-74c458d784ce"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "07636587-5345-4130-9ec3-74c458d784ce"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SignalRDemo.Server.Application.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SignalRDemo.Server.Application.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalRDemo.Server.Application.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SignalRDemo.Server.Application.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalRDemo.Server.Application.Models.Declaration", b =>
                {
                    b.HasOne("SignalRDemo.Server.Application.Models.User", "Declarant")
                        .WithMany("Declarations")
                        .HasForeignKey("DeclarantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalRDemo.Server.Application.Models.Jurisdiction", "Jurisdiction")
                        .WithMany()
                        .HasForeignKey("JurisdictionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Declarant");

                    b.Navigation("Jurisdiction");
                });

            modelBuilder.Entity("UserJurisdiction", b =>
                {
                    b.HasOne("SignalRDemo.Server.Application.Models.Jurisdiction", null)
                        .WithMany()
                        .HasForeignKey("JurisdictionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SignalRDemo.Server.Application.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SignalRDemo.Server.Application.Models.User", b =>
                {
                    b.Navigation("Declarations");
                });
#pragma warning restore 612, 618
        }
    }
}
