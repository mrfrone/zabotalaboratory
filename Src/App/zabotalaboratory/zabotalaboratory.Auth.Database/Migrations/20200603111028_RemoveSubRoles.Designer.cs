﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using zabotalaboratory.Auth.Database.Context;

namespace zabotalaboratory.Auth.Database.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20200603111028_RemoveSubRoles")]
    partial class RemoveSubRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("zabota_auth")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.Identities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("Deleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("integer");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Identities");
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.Jwts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTimeOffset?>("Deleted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedById")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdentityId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("Issued")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeletedById");

                    b.HasIndex("IdentityId");

                    b.ToTable("Jwts");
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Лаборант"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Поликлиника"
                        });
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.UsersProfiles", b =>
                {
                    b.Property<int>("IdentityId")
                        .HasColumnType("integer");

                    b.Property<string>("AbbreviatedNameOfCompany")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Address")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("FullNameOfCompany")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.HasKey("IdentityId");

                    b.ToTable("UsersProfiles");
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.Identities", b =>
                {
                    b.HasOne("zabotalaboratory.Auth.Database.Entities.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.Jwts", b =>
                {
                    b.HasOne("zabotalaboratory.Auth.Database.Entities.Identities", "DeletedBy")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("zabotalaboratory.Auth.Database.Entities.Identities", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("zabotalaboratory.Auth.Database.Entities.UsersProfiles", b =>
                {
                    b.HasOne("zabotalaboratory.Auth.Database.Entities.Identities", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
