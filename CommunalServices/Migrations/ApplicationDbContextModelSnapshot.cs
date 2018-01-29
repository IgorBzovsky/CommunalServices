﻿// <auto-generated />
using CommunalServices.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CommunalServices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunalServices.Core.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.MeasureUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MeasureUnit");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.ProvidedUtility", b =>
                {
                    b.Property<int>("ProviderId");

                    b.Property<int>("UtilityId");

                    b.HasKey("ProviderId", "UtilityId");

                    b.HasIndex("UtilityId");

                    b.ToTable("ProvidedUtility");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.Utility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeasureUnitId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MeasureUnitId");

                    b.ToTable("Utilities");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.Location", b =>
                {
                    b.HasOne("CommunalServices.Core.Models.Location", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CommunalServices.Core.Models.ProvidedUtility", b =>
                {
                    b.HasOne("CommunalServices.Core.Models.Provider", "Provider")
                        .WithMany("ProvidedUtilities")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CommunalServices.Core.Models.Utility", "Utility")
                        .WithMany()
                        .HasForeignKey("UtilityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CommunalServices.Core.Models.Provider", b =>
                {
                    b.HasOne("CommunalServices.Core.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CommunalServices.Core.Models.Utility", b =>
                {
                    b.HasOne("CommunalServices.Core.Models.MeasureUnit", "MeasureUnit")
                        .WithMany()
                        .HasForeignKey("MeasureUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
