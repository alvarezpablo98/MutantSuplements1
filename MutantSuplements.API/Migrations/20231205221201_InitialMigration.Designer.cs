﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MutantSuplements.API.DBContext;

#nullable disable

namespace MutantSuplements.API.Migrations
{
    [DbContext(typeof(MutantSuplementsContext))]
    [Migration("20231205221201_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("MutantSuplements.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "La mesa de madera.",
                            Name = "Mesa",
                            Price = 420.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "La silla de madera.",
                            Name = "Silla",
                            Price = 320.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "El sillon comodo y lujoso.",
                            Name = "Sillon",
                            Price = 520.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "El ropero mas grande.",
                            Name = "Ropero",
                            Price = 520.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "Mesita pequeña con 3 patas.",
                            Name = "Mesita pequeña",
                            Price = 520.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Description = "La cajonera con espacios divididos.",
                            Name = "Cajonera",
                            Price = 520.0
                        });
                });

            modelBuilder.Entity("MutantSuplements.API.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Muebles grandes de madera.",
                            Name = "Muebles de Madera"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Muebles medianos en oferta",
                            Name = "Muebles medianos"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Muebles pequeños para decoracion",
                            Name = "Muebles pequeños"
                        });
                });

            modelBuilder.Entity("MutantSuplements.API.Entities.Product", b =>
                {
                    b.HasOne("MutantSuplements.API.Entities.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}