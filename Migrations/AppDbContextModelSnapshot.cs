﻿// <auto-generated />
using System;
using LagendaBackend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LagendaBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("LagendaBackend.Data.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArticleAuthorCategoryId")
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

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDatetime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleAuthorCategoryId");

                    b.HasIndex("ArticleCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleAuthorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ArticleCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ExternalLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("ArticleAuthorCategories");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ExternalLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPartner")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Collaborator")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Partner")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Balado", b =>
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

                    b.Property<string>("SimpleCastId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SoundcloudLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SpotifyLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdateDatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("YoutubeLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BaladoCategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Balados");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BaladoPartnerId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("BaladoPartnerId");

                    b.HasIndex("ImageId");

                    b.ToTable("BaladoCategories");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoPartner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Unlisted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("BaladoPartners");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Image", b =>
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

            modelBuilder.Entity("LagendaBackend.Data.Models.ManyToMany.ArticleAuthor", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ArticleAuthors");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FamilyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GoogleId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.SocialLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("SocialLinks");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Article", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.ArticleAuthorCategory", "ArticleAuthorCategory")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleAuthorCategoryId");

                    b.HasOne("LagendaBackend.Data.Models.ArticleCategory", "ArticleCategory")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleCategoryId");

                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("ArticleAuthorCategory");

                    b.Navigation("ArticleCategory");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleAuthorCategory", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.ArticleCategory", "ArticleCategory")
                        .WithMany("ArticleAuthorCategories")
                        .HasForeignKey("ArticleCategoryId");

                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("ArticleCategory");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleCategory", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Author", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Balado", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.BaladoCategory", "BaladoCategory")
                        .WithMany("Balados")
                        .HasForeignKey("BaladoCategoryId");

                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("BaladoCategory");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoCategory", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.BaladoPartner", "BaladoPartner")
                        .WithMany("BaladoCategories")
                        .HasForeignKey("BaladoPartnerId");

                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("BaladoPartner");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoPartner", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ManyToMany.ArticleAuthor", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.Article", "Article")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LagendaBackend.Data.Models.Author", "Author")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.SocialLink", b =>
                {
                    b.HasOne("LagendaBackend.Data.Models.Author", null)
                        .WithMany("SocialLinks")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Article", b =>
                {
                    b.Navigation("ArticleAuthors");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleAuthorCategory", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.ArticleCategory", b =>
                {
                    b.Navigation("ArticleAuthorCategories");

                    b.Navigation("Articles");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.Author", b =>
                {
                    b.Navigation("ArticleAuthors");

                    b.Navigation("SocialLinks");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoCategory", b =>
                {
                    b.Navigation("Balados");
                });

            modelBuilder.Entity("LagendaBackend.Data.Models.BaladoPartner", b =>
                {
                    b.Navigation("BaladoCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
