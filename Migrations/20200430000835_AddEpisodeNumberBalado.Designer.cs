﻿// <auto-generated />
using System;
using LagendaBackend.Data.Models;
using LagendaBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LagendaBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200430000835_AddEpisodeNumberBalado")]
    partial class AddEpisodeNumberBalado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LagendaBackend.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArticleCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateDatetime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("LagendaBackend.Models.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("LagendaBackend.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LagendaBackend.Models.Balado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppleLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("BaladoCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("GoogleLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SpotifyLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdateDatetime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BaladoCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Balados");
                });

            modelBuilder.Entity("LagendaBackend.Models.BaladoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("BaladoCategories");
                });

            modelBuilder.Entity("LagendaBackend.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alt")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Credits")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LagendaBackend.Models.ManyToMany.ArticleAuthor", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("LagendaBackend.Models.Article", b =>
                {
                    b.HasOne("LagendaBackend.Models.ArticleCategory", "ArticleCategory")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleCategoryId");

                    b.HasOne("LagendaBackend.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("LagendaBackend.Models.Author", b =>
                {
                    b.HasOne("LagendaBackend.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("LagendaBackend.Models.Balado", b =>
                {
                    b.HasOne("LagendaBackend.Models.BaladoCategory", "BaladoCategory")
                        .WithMany("Balados")
                        .HasForeignKey("BaladoCategoryId");

                    b.HasOne("LagendaBackend.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("LagendaBackend.Models.ManyToMany.ArticleAuthor", b =>
                {
                    b.HasOne("LagendaBackend.Models.Article", "Article")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LagendaBackend.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
