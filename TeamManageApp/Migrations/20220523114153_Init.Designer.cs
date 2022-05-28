﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeamManageApp.Data;

#nullable disable

namespace TeamManageApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220523114153_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TeamManageApp.Models.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ListId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("TeamManageApp.Models.IssueList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MainIssueId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MainIssueId")
                        .IsUnique();

                    b.ToTable("IssueList");
                });

            modelBuilder.Entity("TeamManageApp.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CreaterId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EstimateFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EstimateTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Methodologies")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreaterId")
                        .IsUnique();

                    b.ToTable("Team");
                });

            modelBuilder.Entity("TeamManageApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TeamManageApp.Models.Issue", b =>
                {
                    b.HasOne("TeamManageApp.Models.IssueList", "LinkIssues")
                        .WithMany("Issues")
                        .HasForeignKey("ListId");

                    b.HasOne("TeamManageApp.Models.Team", "Team")
                        .WithMany("Issues")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamManageApp.Models.User", "User")
                        .WithMany("Issues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkIssues");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TeamManageApp.Models.IssueList", b =>
                {
                    b.HasOne("TeamManageApp.Models.Issue", "MainIssue")
                        .WithOne("IssueList")
                        .HasForeignKey("TeamManageApp.Models.IssueList", "MainIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainIssue");
                });

            modelBuilder.Entity("TeamManageApp.Models.Team", b =>
                {
                    b.HasOne("TeamManageApp.Models.User", "Creater")
                        .WithOne("CreatedTeam")
                        .HasForeignKey("TeamManageApp.Models.Team", "CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creater");
                });

            modelBuilder.Entity("TeamManageApp.Models.User", b =>
                {
                    b.HasOne("TeamManageApp.Models.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TeamManageApp.Models.Issue", b =>
                {
                    b.Navigation("IssueList");
                });

            modelBuilder.Entity("TeamManageApp.Models.IssueList", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("TeamManageApp.Models.Team", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("TeamManageApp.Models.User", b =>
                {
                    b.Navigation("CreatedTeam")
                        .IsRequired();

                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}
