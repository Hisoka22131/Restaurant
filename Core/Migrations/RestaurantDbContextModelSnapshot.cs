﻿// <auto-generated />
using System;
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    partial class RestaurantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "FirstName", "LastName" }, "NonClusteredIndex-20230221-095034");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Core.Domain.DeliveryMan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryMan", (string)null);
                });

            modelBuilder.Entity("Core.Domain.DeliveryManVacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeliveryManId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOfVacation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfVacation")
                        .HasColumnType("datetime2");

                    b.Property<byte>("TypeVacation")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryManId");

                    b.ToTable("DeliveryManVacation");
                });

            modelBuilder.Entity("Core.Domain.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("TaggingDish")
                        .HasColumnType("tinyint");

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "NonClusteredIndex-20230221-095136");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Core.Domain.DishOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex(new[] { "DishId", "OrderId" }, "NonClusteredIndex-20230221-095146");

                    b.ToTable("DishesOrders");
                });

            modelBuilder.Entity("Core.Domain.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("District", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryManId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<byte>("Type")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DeliveryManId");

                    b.HasIndex(new[] { "Number" }, "NonClusteredIndex-20230221-095113");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Client", b =>
                {
                    b.HasOne("Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.DeliveryMan", b =>
                {
                    b.HasOne("Core.Domain.District", "District")
                        .WithMany("DeliveryMens")
                        .HasForeignKey("DistrictId")
                        .IsRequired()
                        .HasConstraintName("FK_DeliveryMan_District");

                    b.HasOne("Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.DeliveryManVacation", b =>
                {
                    b.HasOne("Core.Domain.DeliveryMan", "DeliveryMan")
                        .WithMany("DeliveryManVacations")
                        .HasForeignKey("DeliveryManId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DeliveryManVacation_DeliveryMan");

                    b.Navigation("DeliveryMan");
                });

            modelBuilder.Entity("Core.Domain.DishOrder", b =>
                {
                    b.HasOne("Core.Domain.Dish", "Dish")
                        .WithMany("DishesOrders")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DishesOrders_Dishes");

                    b.HasOne("Core.Domain.Order", "Order")
                        .WithMany("DishesOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DishesOrders_Order");

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.Domain.Order", b =>
                {
                    b.HasOne("Core.Domain.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_Client");

                    b.HasOne("Core.Domain.DeliveryMan", "DeliveryMan")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryManId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_DeliveryMan");

                    b.Navigation("Client");

                    b.Navigation("DeliveryMan");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Core.Domain.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Domain.DeliveryMan", b =>
                {
                    b.Navigation("DeliveryManVacations");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Domain.Dish", b =>
                {
                    b.Navigation("DishesOrders");
                });

            modelBuilder.Entity("Core.Domain.District", b =>
                {
                    b.Navigation("DeliveryMens");
                });

            modelBuilder.Entity("Core.Domain.Order", b =>
                {
                    b.Navigation("DishesOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
