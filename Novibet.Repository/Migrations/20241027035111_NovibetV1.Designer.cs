﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Novibet.Repository.Context;

#nullable disable

namespace Novibet.Repository.Migrations
{
    [DbContext(typeof(NovibetDbContext))]
    [Migration("20241027035111_NovibetV1")]
    partial class NovibetV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Novibet.Application.Countries.CommandSide.Aggregates.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ThreeLetterCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("char(3)");

                    b.Property<string>("TwoLetterCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("char(2)");

                    b.HasKey("Id")
                        .HasName("PK_Countries");

                    b.ToTable("Countries", (string)null);
                });

            modelBuilder.Entity("Novibet.Application.IPAdresses.CommandSide.Aggregates.IPAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("char(15)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id")
                        .HasName("PK_IPAddresses");

                    b.HasIndex("CountryId");

                    b.HasIndex("IP")
                        .IsUnique()
                        .HasDatabaseName("IX_IPAddresses");

                    b.ToTable("IPAddresses", (string)null);
                });

            modelBuilder.Entity("Novibet.Application.IPAdresses.CommandSide.Aggregates.IPAddress", b =>
                {
                    b.HasOne("Novibet.Application.Countries.CommandSide.Aggregates.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_IPAddresses_Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
