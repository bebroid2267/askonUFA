﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using askonUFA.Database;

#nullable disable

namespace askonUFA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240528144903_Asvsdvsfsd")]
    partial class Asvsdvsfsd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("askonUFA.Database.Attributes", b =>
                {
                    b.Property<int>("objectId")
                        .HasColumnType("int");

                    b.Property<int?>("ObjectsId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("objectId");

                    b.HasIndex("ObjectsId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("askonUFA.Database.Links", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("ParentId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("askonUFA.Database.Objects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Objects", (string)null);
                });

            modelBuilder.Entity("askonUFA.Database.Attributes", b =>
                {
                    b.HasOne("askonUFA.Database.Objects", null)
                        .WithMany("Attributess")
                        .HasForeignKey("ObjectsId");

                    b.HasOne("askonUFA.Database.Objects", "Object")
                        .WithMany()
                        .HasForeignKey("objectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Object");
                });

            modelBuilder.Entity("askonUFA.Database.Links", b =>
                {
                    b.HasOne("askonUFA.Database.Objects", "Child")
                        .WithMany("ParentLinks")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("askonUFA.Database.Objects", "Parent")
                        .WithMany("ChildLinks")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("askonUFA.Database.Objects", b =>
                {
                    b.Navigation("Attributess");

                    b.Navigation("ChildLinks");

                    b.Navigation("ParentLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
