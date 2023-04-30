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
    [Migration("20230430104417_Adjustment5")]
    partial class Adjustment5
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
                            Id = "be26ff94-ef6d-42b1-a9b2-f58dcc908539",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "45632f48-dc44-40af-a494-e6f4c2de1b8e",
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
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9",
                            RoleId = "be26ff94-ef6d-42b1-a9b2-f58dcc908539"
                        },
                        new
                        {
                            UserId = "1b221912-04fd-4901-8644-c8ead49dadbd",
                            RoleId = "45632f48-dc44-40af-a494-e6f4c2de1b8e"
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
                            Id = "f3cac9eb-c72f-4ef9-be46-a59dca7214ba",
                            CreationDate = new DateTime(2023, 4, 27, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3281),
                            DeclarantId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9",
                            Description = "Test GB declaration 1",
                            JurisdictionCode = "GB",
                            NetMass = 80m
                        },
                        new
                        {
                            Id = "ab4a794e-0de8-468a-b2e5-8fcf66f34f10",
                            CreationDate = new DateTime(2023, 4, 28, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3292),
                            DeclarantId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9",
                            Description = "Test BE declaration 1",
                            JurisdictionCode = "BE",
                            NetMass = 60m
                        },
                        new
                        {
                            Id = "5cd64d9c-ad80-4e8a-8efc-79377aeaf573",
                            CreationDate = new DateTime(2023, 4, 29, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3297),
                            DeclarantId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9",
                            Description = "Test DE declaration 1",
                            JurisdictionCode = "DE",
                            NetMass = 50m
                        },
                        new
                        {
                            Id = "d4b59a78-dd38-4dfb-ae4c-b3d43a77dfde",
                            CreationDate = new DateTime(2023, 4, 28, 22, 44, 17, 436, DateTimeKind.Utc).AddTicks(3301),
                            DeclarantId = "1b221912-04fd-4901-8644-c8ead49dadbd",
                            Description = "Test GB declaration 2",
                            JurisdictionCode = "GB",
                            NetMass = 90m
                        },
                        new
                        {
                            Id = "1fa27d33-7489-44b5-9e14-74533c903fb8",
                            CreationDate = new DateTime(2023, 4, 29, 22, 44, 17, 436, DateTimeKind.Utc).AddTicks(3305),
                            DeclarantId = "1b221912-04fd-4901-8644-c8ead49dadbd",
                            Description = "Test BE declaration 2",
                            JurisdictionCode = "BE",
                            NetMass = 70m
                        },
                        new
                        {
                            Id = "0cd4a98e-f18b-45a1-ba1c-fa59b45292e6",
                            CreationDate = new DateTime(2023, 4, 30, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3432),
                            DeclarantId = "1b221912-04fd-4901-8644-c8ead49dadbd",
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
                            Id = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "30f920fd-a263-4dad-9a0e-d83333d50afb",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPCeXJRBiwxhGaTwVkZ382CBgi7LnyE6o1XwXJDoqabSqvZVtuznsa5i54mCvuF09g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2b4c8fbb-0bdc-460b-a5b4-2ddebe24e79e",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "1b221912-04fd-4901-8644-c8ead49dadbd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "34d58936-2b3b-4f0b-a5bc-a4ff238f98da",
                            Email = "user@localhost.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@LOCALHOST.COM",
                            NormalizedUserName = "USER@LOCALHOST.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEButEkR/s5qZK34Qaw/ZAIXvIbCmtlYV3HAy95wJQeKb0zcQzTtDroT6dXGemTl6RQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6f475b03-b110-404d-af0e-b5d1c5830cc5",
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
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "IE",
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "NL",
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "PL",
                            UserId = "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9"
                        },
                        new
                        {
                            JurisdictionCode = "GB",
                            UserId = "1b221912-04fd-4901-8644-c8ead49dadbd"
                        },
                        new
                        {
                            JurisdictionCode = "BE",
                            UserId = "1b221912-04fd-4901-8644-c8ead49dadbd"
                        },
                        new
                        {
                            JurisdictionCode = "DE",
                            UserId = "1b221912-04fd-4901-8644-c8ead49dadbd"
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