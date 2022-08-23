﻿// <auto-generated />
using System;
using Bank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Data.Migrations
{
    [DbContext(typeof(BankDbContext))]
    [Migration("20220822125039_ino4")]
    partial class ino4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bank.Domain.Entity.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankAccountId"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("CutomerId")
                        .HasColumnType("int");

                    b.Property<int>("Deposite")
                        .HasColumnType("int");

                    b.Property<int>("TypeAccount")
                        .HasColumnType("int");

                    b.Property<int>("Withdraw")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.HasIndex("CutomerId");

                    b.ToTable("BankAccount", "Base");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte>("Age")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("BirthtDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", "Base");
                });

            modelBuilder.Entity("Bank.Domain.Entity.GeneralBank", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankId"), 1L, 1);

                    b.Property<int>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Branch")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("City")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("BankId");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("GeneralBank", "Base");
                });

            modelBuilder.Entity("Bank.Domain.Entity.BankAccount", b =>
                {
                    b.HasOne("Bank.Domain.Entity.Customer", "Customer")
                        .WithMany("BankAccounts")
                        .HasForeignKey("CutomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bank.Domain.Entity.GeneralBank", b =>
                {
                    b.HasOne("Bank.Domain.Entity.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bank.Domain.Entity.Customer", "Customer")
                        .WithMany("generalBanks")
                        .HasForeignKey("CustomerId");

                    b.Navigation("BankAccount");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bank.Domain.Entity.Customer", b =>
                {
                    b.Navigation("BankAccounts");

                    b.Navigation("generalBanks");
                });
#pragma warning restore 612, 618
        }
    }
}