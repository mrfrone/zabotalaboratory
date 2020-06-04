﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using zabotalaboratory.Analyses.Database.Context;

namespace zabotalaboratory.Analyses.Database.Migrations
{
    [DbContext(typeof(AnalysesContext))]
    partial class AnalysesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("zabota_analyses")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.AnalysesResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LaboratoryAnalysesTestsId")
                        .HasColumnType("integer");

                    b.Property<string>("Result")
                        .HasColumnType("text");

                    b.Property<int?>("TalonsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryAnalysesTestsId");

                    b.HasIndex("TalonsId");

                    b.ToTable("AnalysesResult");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.AnalysesTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number1C")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AnalysesTypes");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.Clinics", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalyses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<string>("PatronymicName")
                        .IsRequired()
                        .HasColumnType("character varying(32)")
                        .HasMaxLength(32);

                    b.Property<DateTimeOffset>("PickUpDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("LaboratoryAnalyses");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalysesTests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnalysesTypesId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number1C")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnalysesTypesId");

                    b.ToTable("LaboratoryAnalysesTests");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.Talons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnalysesTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("LaboratoryAnalysesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnalysesTypeId");

                    b.HasIndex("LaboratoryAnalysesId");

                    b.ToTable("Talons");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.AnalysesResult", b =>
                {
                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalysesTests", "LaboratoryAnalysesTests")
                        .WithMany()
                        .HasForeignKey("LaboratoryAnalysesTestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.Talons", null)
                        .WithMany("AnalysesResult")
                        .HasForeignKey("TalonsId");
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalyses", b =>
                {
                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.Clinics", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalysesTests", b =>
                {
                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.AnalysesTypes", null)
                        .WithMany("LaboratoryAnalysesTests")
                        .HasForeignKey("AnalysesTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("zabotalaboratory.Analyses.Database.Entities.Talons", b =>
                {
                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.AnalysesTypes", "AnalysesType")
                        .WithMany()
                        .HasForeignKey("AnalysesTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("zabotalaboratory.Analyses.Database.Entities.LaboratoryAnalyses", null)
                        .WithMany("Talons")
                        .HasForeignKey("LaboratoryAnalysesId");
                });
#pragma warning restore 612, 618
        }
    }
}
