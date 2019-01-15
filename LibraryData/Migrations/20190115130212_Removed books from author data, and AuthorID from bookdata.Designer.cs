﻿// <auto-generated />
using System;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryData.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190115130212_Removed books from author data, and AuthorID from bookdata")]
    partial class RemovedbooksfromauthordataandAuthorIDfrombookdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryData.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID");

                    b.Property<string>("Description");

                    b.Property<int>("ISBN");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryData.Models.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BooksID");

                    b.HasKey("ID");

                    b.HasIndex("BooksID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("LibraryData.Models.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID");

                    b.Property<DateTime>("Checkout");

                    b.Property<int>("MemberID");

                    b.Property<DateTime?>("Returned");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("MemberID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryData.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PersonNr");

                    b.HasKey("ID");

                    b.ToTable("Members");

                    b.HasData(
                        new { ID = 1, Name = "Leo", PersonNr = 1 }
                    );
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasOne("LibraryData.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.BookCopy", b =>
                {
                    b.HasOne("LibraryData.Models.Book", "Books")
                        .WithMany("BookCopies")
                        .HasForeignKey("BooksID");
                });

            modelBuilder.Entity("LibraryData.Models.Loan", b =>
                {
                    b.HasOne("LibraryData.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
