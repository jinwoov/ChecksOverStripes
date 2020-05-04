﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20200504072140_seededmoredata")]
    partial class seededmoredata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.CartItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventoryID")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("UserID");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            InventoryID = 3,
                            Qty = 2,
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            InventoryID = 2,
                            Qty = 5,
                            UserID = 2
                        });
                });

            modelBuilder.Entity("API.Models.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Inventory");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Brand = 0,
                            Description = "Why so expensive? Who knows..",
                            Name = "Shawn Weatherspoon",
                            Size = 11
                        },
                        new
                        {
                            ID = 2,
                            Brand = 1,
                            Description = "My name is Jordan and deez my numbah 1 shoe",
                            Name = "Jordan 1",
                            Size = 12
                        },
                        new
                        {
                            ID = 3,
                            Brand = 1,
                            Description = "Deez shoe is mah numbah 2, and I ain't no foo",
                            Name = "Jordan 2",
                            Size = 10
                        });
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "areyes986@gmail.com"
                        },
                        new
                        {
                            ID = 2,
                            Email = "jinwoov@gmail.com"
                        });
                });

            modelBuilder.Entity("API.Models.CartItems", b =>
                {
                    b.HasOne("API.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
