﻿// <auto-generated />
using System;
using BankingSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220624215924_UpdateCreatedField2")]
    partial class UpdateCreatedField2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Datetime");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Number" }, "Unique_Account_Name")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_AccountType_Name")
                        .IsUnique();

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_Branch_Name")
                        .IsUnique();

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Code" }, "Unique_Currency_Code")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "Unique_Currency_Name")
                        .IsUnique();

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.CurrencyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Limit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int>("CurrencyTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccountTypeRule")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTransferTypeRule")
                        .HasColumnType("bit");

                    b.Property<int>("LocationTypeId")
                        .HasColumnType("int");

                    b.Property<double>("MaxAmounPeriodValue")
                        .HasColumnType("float");

                    b.Property<double>("MaxAmount")
                        .HasColumnType("float");

                    b.Property<int>("MaxAmountPeriodTypeId")
                        .HasColumnType("int");

                    b.Property<double>("MinAmount")
                        .HasColumnType("float");

                    b.Property<int?>("ObjectId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyTypeId");

                    b.HasIndex("LocationTypeId");

                    b.HasIndex("MaxAmountPeriodTypeId");

                    b.HasIndex("ObjectTypeId");

                    b.ToTable("Limit");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.LimitAccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int>("LimitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("LimitId");

                    b.ToTable("LimitAccountType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.LimitTransferType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LimitId")
                        .HasColumnType("int");

                    b.Property<int>("TransferTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LimitId");

                    b.HasIndex("TransferTypeId");

                    b.ToTable("LimitTransferType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.LocationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.ObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjectType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.PeriodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeriodType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("Datetime");

                    b.Property<int?>("DestinationAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationAccountId");

                    b.HasIndex("SourceAccountId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.TransferType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_TransferType_Name")
                        .IsUnique();

                    b.ToTable("TransferType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("Datetime");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Account", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Limit", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.CurrencyType", "CurrencyType")
                        .WithMany()
                        .HasForeignKey("CurrencyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.LocationType", "LocationType")
                        .WithMany()
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.PeriodType", "MaxAmountPeriodType")
                        .WithMany()
                        .HasForeignKey("MaxAmountPeriodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.ObjectType", "ObjectType")
                        .WithMany()
                        .HasForeignKey("ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrencyType");

                    b.Navigation("LocationType");

                    b.Navigation("MaxAmountPeriodType");

                    b.Navigation("ObjectType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.LimitAccountType", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.AccountType", "AccountType")
                        .WithMany("LimitAccountTypes")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.Limit", "Limit")
                        .WithMany("LimitAccountTypes")
                        .HasForeignKey("LimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Limit");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.LimitTransferType", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.Limit", "Limit")
                        .WithMany("LimitTransferTypes")
                        .HasForeignKey("LimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.TransferType", "TransferType")
                        .WithMany("LimitTransferTypes")
                        .HasForeignKey("TransferTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Limit");

                    b.Navigation("TransferType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Transaction", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.Account", "DestinationAccount")
                        .WithMany("DestinationTransactions")
                        .HasForeignKey("DestinationAccountId");

                    b.HasOne("BankingSystem.Domain.Models.DTO.Account", "SourceAccount")
                        .WithMany("SourceTransactions")
                        .HasForeignKey("SourceAccountId");

                    b.Navigation("DestinationAccount");

                    b.Navigation("SourceAccount");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.User", b =>
                {
                    b.HasOne("BankingSystem.Domain.Models.DTO.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Domain.Models.DTO.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Gender");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Account", b =>
                {
                    b.Navigation("DestinationTransactions");

                    b.Navigation("SourceTransactions");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.AccountType", b =>
                {
                    b.Navigation("LimitAccountTypes");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Branch", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.Limit", b =>
                {
                    b.Navigation("LimitAccountTypes");

                    b.Navigation("LimitTransferTypes");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.TransferType", b =>
                {
                    b.Navigation("LimitTransferTypes");
                });

            modelBuilder.Entity("BankingSystem.Domain.Models.DTO.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
