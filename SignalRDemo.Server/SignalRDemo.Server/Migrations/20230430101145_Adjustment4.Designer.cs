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
    [Migration("20230430101145_Adjustment4")]
    partial class Adjustment4
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
                            Id = "8249e1f0-d959-476b-a96e-eaee38b99a34",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "f315c57b-fa3a-4f28-8943-4021d2e21e27",
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
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff",
                            RoleId = "8249e1f0-d959-476b-a96e-eaee38b99a34"
                        },
                        new
                        {
                            UserId = "d638e60a-ba31-44aa-af2e-624df1bde177",
                            RoleId = "f315c57b-fa3a-4f28-8943-4021d2e21e27"
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
                        .ValueGeneratedOnAdd()
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

                    b.Property<DateTime?>("LastUpdatedDate")
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
                            Id = "4410772f-43c1-44f4-8350-8ecbac745431",
                            CreationDate = new DateTime(2023, 4, 27, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7263),
                            DeclarantId = "ffc652f7-a045-4cba-bfba-ed8497859fff",
                            Description = "Test GB declaration 1",
                            JurisdictionCode = "GB",
                            NetMass = 80m
                        },
                        new
                        {
                            Id = "50fadeab-5470-4bcb-ba81-4f57286bb91d",
                            CreationDate = new DateTime(2023, 4, 28, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7292),
                            DeclarantId = "ffc652f7-a045-4cba-bfba-ed8497859fff",
                            Description = "Test BE declaration 1",
                            JurisdictionCode = "BE",
                            NetMass = 60m
                        },
                        new
                        {
                            Id = "abb0585e-8145-46f6-bb29-29b1a8675a08",
                            CreationDate = new DateTime(2023, 4, 29, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7296),
                            DeclarantId = "ffc652f7-a045-4cba-bfba-ed8497859fff",
                            Description = "Test DE declaration 1",
                            JurisdictionCode = "DE",
                            NetMass = 50m
                        },
                        new
                        {
                            Id = "238c424c-09b6-4fe5-9157-7d9d9b8605f0",
                            CreationDate = new DateTime(2023, 4, 28, 22, 11, 45, 481, DateTimeKind.Utc).AddTicks(7317),
                            DeclarantId = "d638e60a-ba31-44aa-af2e-624df1bde177",
                            Description = "Test GB declaration 2",
                            JurisdictionCode = "GB",
                            NetMass = 90m
                        },
                        new
                        {
                            Id = "954cce4e-378d-4b72-a3e0-d4232888e1d6",
                            CreationDate = new DateTime(2023, 4, 29, 22, 11, 45, 481, DateTimeKind.Utc).AddTicks(7321),
                            DeclarantId = "d638e60a-ba31-44aa-af2e-624df1bde177",
                            Description = "Test BE declaration 2",
                            JurisdictionCode = "BE",
                            NetMass = 70m
                        },
                        new
                        {
                            Id = "bebed2e2-78c7-43f0-b786-0d98f273b2bf",
                            CreationDate = new DateTime(2023, 4, 30, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7326),
                            DeclarantId = "d638e60a-ba31-44aa-af2e-624df1bde177",
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
                            Id = "ffc652f7-a045-4cba-bfba-ed8497859fff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fb5edfbd-35ad-4484-8713-0799d2fdb638",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMtKWV1N6fm40Db6Urk2MyyfcSSiPJ7OP3E+VDoylgBwB0Rlhx7uDhzUkriGu9Bb9w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "54c59156-d073-4314-b9f3-abf4ce7f737d",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "d638e60a-ba31-44aa-af2e-624df1bde177",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ff83248c-a6f4-4934-8237-a99817397ff0",
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPAoujfzckCbrth2kVHhf76M94WGa6YETTqEBD/XkIf7RLzZ21BgTRMXpbFcLNoZWQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "43846f31-4ab6-459e-a0f5-c989d1c87498",
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
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "IE",
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "NL",
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "PL",
                            UserId = "ffc652f7-a045-4cba-bfba-ed8497859fff"
                        },
                        new
                        {
                            JurisdictionCode = "GB",
                            UserId = "d638e60a-ba31-44aa-af2e-624df1bde177"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "d638e60a-ba31-44aa-af2e-624df1bde177"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "d638e60a-ba31-44aa-af2e-624df1bde177"
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