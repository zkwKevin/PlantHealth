﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Models;

namespace TodoApi.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20190424075809_version2")]
    partial class version2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TodoApi.Models.DayLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("TodoLogId");

                    b.Property<bool>("isComplete");

                    b.HasKey("Id");

                    b.HasIndex("TodoLogId");

                    b.ToTable("DayLogs");
                });

            modelBuilder.Entity("TodoApi.Models.TargetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HealthState");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TargetItems");
                });

            modelBuilder.Entity("TodoApi.Models.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsBuildIn");

                    b.Property<int?>("Mode");

                    b.Property<string>("ModeValue");

                    b.Property<string>("Name");

                    b.Property<int>("Time");

                    b.Property<int>("TimesForMode");

                    b.Property<int?>("Type");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TodoApi.Models.TodoLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TargetItemId");

                    b.Property<int>("TodoItemId");

                    b.HasKey("Id");

                    b.HasIndex("TargetItemId");

                    b.HasIndex("TodoItemId");

                    b.ToTable("TodoLogs");
                });

            modelBuilder.Entity("TodoApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birth");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TodoApi.Models.DayLog", b =>
                {
                    b.HasOne("TodoApi.Models.TodoLog", "TodoLog")
                        .WithMany("DayLogs")
                        .HasForeignKey("TodoLogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TodoApi.Models.TargetItem", b =>
                {
                    b.HasOne("TodoApi.Models.User", "User")
                        .WithMany("TargetItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TodoApi.Models.TodoLog", b =>
                {
                    b.HasOne("TodoApi.Models.TargetItem", "TargetItem")
                        .WithMany("Logs")
                        .HasForeignKey("TargetItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TodoApi.Models.TodoItem", "TodoItem")
                        .WithMany("Logs")
                        .HasForeignKey("TodoItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
