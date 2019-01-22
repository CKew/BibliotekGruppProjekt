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
    [Migration("20190122185058_fixed whitespaces and renamed namespaces etc")]
    partial class fixedwhitespacesandrenamednamespacesetc
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

                    b.Property<string>("Name");

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

                    b.Property<string>("ISBN");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryData.Models.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID");

                    b.Property<bool>("Status");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("LibraryData.Models.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookCopyID");

                    b.Property<DateTime>("Checkout");

                    b.Property<bool>("Delayed");

                    b.Property<int?>("Fees");

                    b.Property<int>("MemberID");

                    b.Property<DateTime?>("Returned");

                    b.HasKey("ID");

                    b.HasIndex("BookCopyID");

                    b.HasIndex("MemberID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("LibraryData.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Fees");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PersonNr");

                    b.HasKey("ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasOne("LibraryData.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.BookCopy", b =>
                {
                    b.HasOne("LibraryData.Models.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Loan", b =>
                {
                    b.HasOne("LibraryData.Models.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyID")
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
