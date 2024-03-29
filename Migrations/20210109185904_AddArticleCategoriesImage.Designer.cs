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
    [Migration("20210109185904_AddArticleCategoriesImage")]
    partial class AddArticleCategoriesImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LagendaBackend.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArticleCategoryId");

                    b.Property<string>("Content");

                    b.Property<string>("Desc");

                    b.Property<int?>("ImageId");

                    b.Property<DateTime>("PostDatetime");

                    b.Property<string>("Title");

                    b.Property<bool>("Unlisted");

                    b.Property<DateTime>("UpdateDatetime");

                    b.HasKey("Id");

                    b.HasIndex("ArticleCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("LagendaBackend.Models.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ImageId");

                    b.Property<string>("Name");

                    b.Property<int?>("Order");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("LagendaBackend.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Collaborator");

                    b.Property<string>("Desc");

                    b.Property<string>("FirstName");

                    b.Property<int?>("ImageId");

                    b.Property<string>("LastName");

                    b.Property<int?>("Order");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LagendaBackend.Models.Balado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppleLink");

                    b.Property<int?>("BaladoCategoryId");

                    b.Property<string>("Desc");

                    b.Property<int>("EpisodeNumber");

                    b.Property<string>("GoogleLink");

                    b.Property<int?>("ImageId");

                    b.Property<DateTime>("PostDatetime");

                    b.Property<string>("SpotifyLink");

                    b.Property<string>("Title");

                    b.Property<bool>("Unlisted");

                    b.Property<DateTime>("UpdateDatetime");

                    b.HasKey("Id");

                    b.HasIndex("BaladoCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Balados");
                });

            modelBuilder.Entity("LagendaBackend.Models.BaladoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("Order");

                    b.HasKey("Id");

                    b.ToTable("BaladoCategories");
                });

            modelBuilder.Entity("LagendaBackend.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alt");

                    b.Property<string>("Credits");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("LagendaBackend.Models.ManyToMany.ArticleAuthor", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("AuthorId");

                    b.HasKey("ArticleId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("LagendaBackend.Models.SocialLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Link");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("SocialLinks");
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

            modelBuilder.Entity("LagendaBackend.Models.ArticleCategory", b =>
                {
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
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LagendaBackend.Models.Author", "Author")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LagendaBackend.Models.SocialLink", b =>
                {
                    b.HasOne("LagendaBackend.Models.Author", "Author")
                        .WithMany("SocialLinks")
                        .HasForeignKey("AuthorId");
                });
#pragma warning restore 612, 618
        }
    }
}
