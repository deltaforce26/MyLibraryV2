﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibraryV2.Data;

#nullable disable

namespace MyLibraryV2.Migrations
{
    [DbContext(typeof(MyLibraryV2Context))]
    [Migration("20240802150633_initial6")]
    partial class initial6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyLibraryV2.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookSetId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hight")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfNumber")
                        .HasColumnType("int");

                    b.Property<int?>("VolumeNum")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookSetId");

                    b.HasIndex("ShelfId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("MyLibraryV2.Models.BookSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hight")
                        .HasColumnType("int");

                    b.Property<string>("SetTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookSet");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LibraryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Library");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hight")
                        .HasColumnType("int");

                    b.Property<int>("LeftSpace")
                        .HasColumnType("int");

                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Shelf");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Book", b =>
                {
                    b.HasOne("MyLibraryV2.Models.BookSet", "BookSet")
                        .WithMany("Books")
                        .HasForeignKey("BookSetId");

                    b.HasOne("MyLibraryV2.Models.Shelf", "Shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfId");

                    b.Navigation("BookSet");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Shelf", b =>
                {
                    b.HasOne("MyLibraryV2.Models.Library", "Library")
                        .WithMany("Shelves")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");
                });

            modelBuilder.Entity("MyLibraryV2.Models.BookSet", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Library", b =>
                {
                    b.Navigation("Shelves");
                });

            modelBuilder.Entity("MyLibraryV2.Models.Shelf", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}