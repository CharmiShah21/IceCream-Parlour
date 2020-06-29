﻿// <auto-generated />
using IceCreamParlour.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IceCreamParlour.Migrations
{
    [DbContext(typeof(ParlourContext))]
    partial class ParlourContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IceCreamParlour.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("IceCreamParlour.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("IceCreamParlour.Models.Distributor", b =>
                {
                    b.Property<int>("DistributorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistributorContactNo")
                        .HasColumnType("int");

                    b.Property<string>("DistributorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistributorId");

                    b.ToTable("Distributors");
                });

            modelBuilder.Entity("IceCreamParlour.Models.Flavour", b =>
                {
                    b.Property<int>("FlavourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlavourDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlavourName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlavourId");

                    b.ToTable("Flavours");
                });

            modelBuilder.Entity("IceCreamParlour.Models.IceCream", b =>
                {
                    b.Property<int>("IceCreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int");

                    b.Property<int>("FlavourId")
                        .HasColumnType("int");

                    b.Property<string>("IceCreamDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IceCreamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IceCreamPrice")
                        .HasColumnType("int");

                    b.HasKey("IceCreamId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DistributorId");

                    b.HasIndex("FlavourId");

                    b.ToTable("IceCreams");
                });

            modelBuilder.Entity("IceCreamParlour.Models.IceCream", b =>
                {
                    b.HasOne("IceCreamParlour.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamParlour.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamParlour.Models.Distributor", "Distributor")
                        .WithMany()
                        .HasForeignKey("DistributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IceCreamParlour.Models.Flavour", "Flavour")
                        .WithMany()
                        .HasForeignKey("FlavourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
