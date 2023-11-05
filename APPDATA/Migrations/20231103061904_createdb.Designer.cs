﻿// <auto-generated />
using System;
using APPDATA.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APPDATA.Migrations
{
    [DbContext(typeof(ShoppingDB))]
    [Migration("20231103061904_createdb")]
    partial class createdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APPDATA.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("APPDATA.Models.Address", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DefaultAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("APPDATA.Models.Bill", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("MoneyReduce")
                        .HasColumnType("real");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("ShipFee")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("TotalMoney")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateBy")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Voucherid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Voucherid");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("APPDATA.Models.BillDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("BIllId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid?>("ProductDetailID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BIllId");

                    b.HasIndex("ProductDetailID");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("APPDATA.Models.BillHistory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BIllId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("BIllId");

                    b.ToTable("BillHistories");
                });

            modelBuilder.Entity("APPDATA.Models.Cart", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("APPDATA.Models.CartDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("ProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CartId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("APPDATA.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Colorcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("APPDATA.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdProductdetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdProductdetail");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("APPDATA.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("APPDATA.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("APPDATA.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("APPDATA.Models.PaymentMethodDetail", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaymentMethodID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TotalMoney")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("BillId");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("PaymentMethodDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("APPDATA.Models.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("Id_Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_Color")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_Material")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_Product")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_Size")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_supplier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_by")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id_Product");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("APPDATA.Models.Role", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("APPDATA.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("APPDATA.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suppliercode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("APPDATA.Models.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Create_date")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReduceForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("APPDATA.Models.Account", b =>
                {
                    b.HasOne("APPDATA.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("IdRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("APPDATA.Models.Address", b =>
                {
                    b.HasOne("APPDATA.Models.Account", "Account")
                        .WithMany("Address")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("APPDATA.Models.Bill", b =>
                {
                    b.HasOne("APPDATA.Models.Account", "Account")
                        .WithMany("Bill")
                        .HasForeignKey("AccountId");

                    b.HasOne("APPDATA.Models.Voucher", "Voucher")
                        .WithMany("Bill")
                        .HasForeignKey("Voucherid");

                    b.Navigation("Account");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("APPDATA.Models.BillDetail", b =>
                {
                    b.HasOne("APPDATA.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BIllId");

                    b.HasOne("APPDATA.Models.ProductDetail", "ProductDetails")
                        .WithMany("BillDetails")
                        .HasForeignKey("ProductDetailID");

                    b.Navigation("Bill");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.BillHistory", b =>
                {
                    b.HasOne("APPDATA.Models.Bill", "Bill")
                        .WithMany("BillHistory")
                        .HasForeignKey("BIllId");

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("APPDATA.Models.Cart", b =>
                {
                    b.HasOne("APPDATA.Models.Account", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("APPDATA.Models.CartDetail", b =>
                {
                    b.HasOne("APPDATA.Models.ProductDetail", "ProductDetails")
                        .WithMany("Carts")
                        .HasForeignKey("CartId");

                    b.HasOne("APPDATA.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId");

                    b.Navigation("Cart");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Image", b =>
                {
                    b.HasOne("APPDATA.Models.ProductDetail", "ProductDetails")
                        .WithMany("images")
                        .HasForeignKey("IdProductdetail");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Notification", b =>
                {
                    b.HasOne("APPDATA.Models.Account", "Account")
                        .WithMany("Notification")
                        .HasForeignKey("AccountID");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("APPDATA.Models.PaymentMethodDetail", b =>
                {
                    b.HasOne("APPDATA.Models.Bill", "Bill")
                        .WithMany("PaymentMethodDetails")
                        .HasForeignKey("BillId");

                    b.HasOne("APPDATA.Models.PaymentMethod", "PaymentMethods")
                        .WithMany("PaymentMethodDetails")
                        .HasForeignKey("PaymentMethodID");

                    b.Navigation("Bill");

                    b.Navigation("PaymentMethods");
                });

            modelBuilder.Entity("APPDATA.Models.ProductDetail", b =>
                {
                    b.HasOne("APPDATA.Models.Category", "Category")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.HasOne("APPDATA.Models.Color", "Color")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.HasOne("APPDATA.Models.Material", "Material")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.HasOne("APPDATA.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.HasOne("APPDATA.Models.Size", "Size")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.HasOne("APPDATA.Models.Supplier", "Supplier")
                        .WithMany("ProductDetails")
                        .HasForeignKey("Id_Product");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Material");

                    b.Navigation("Product");

                    b.Navigation("Size");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("APPDATA.Models.RefreshToken", b =>
                {
                    b.HasOne("APPDATA.Models.Account", "Account")
                        .WithMany("refreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("APPDATA.Models.Account", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Bill");

                    b.Navigation("Carts");

                    b.Navigation("Notification");

                    b.Navigation("refreshTokens");
                });

            modelBuilder.Entity("APPDATA.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("BillHistory");

                    b.Navigation("PaymentMethodDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Category", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Color", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Material", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.PaymentMethod", b =>
                {
                    b.Navigation("PaymentMethodDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("Carts");

                    b.Navigation("images");
                });

            modelBuilder.Entity("APPDATA.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("APPDATA.Models.Size", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Supplier", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("APPDATA.Models.Voucher", b =>
                {
                    b.Navigation("Bill");
                });
#pragma warning restore 612, 618
        }
    }
}
