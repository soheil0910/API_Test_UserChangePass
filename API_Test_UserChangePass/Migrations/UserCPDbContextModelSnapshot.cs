﻿// <auto-generated />
using System;
using API_Test_UserChangePass.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Test_UserChangePass.Migrations
{
    [DbContext(typeof(UserCPDbContext))]
    partial class UserCPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_Test_UserChangePass.Models.Userx", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password_Test")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Userx");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "soheil0910line@gmail.com",
                            IsAdmin = true,
                            PasswordHash = "$2a$11$SWZC84MZkrjYI61VtgC8o..zdszlCLc2Y3ZhDR1laLe7/byx/8cvu",
                            Password_Test = "1234",
                            RegisterDate = new DateTime(2024, 12, 5, 20, 25, 8, 724, DateTimeKind.Utc).AddTicks(2606),
                            UserName = "user1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "soheil0910line@gmail.com",
                            IsAdmin = false,
                            PasswordHash = "$2a$11$dWABLpG6p/EdRb1m4Rt//u9rphFpYZjScCpVu/0vg5Ipu9aSU6by6",
                            Password_Test = "1234",
                            RegisterDate = new DateTime(2024, 12, 5, 20, 25, 8, 956, DateTimeKind.Utc).AddTicks(953),
                            UserName = "user2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
