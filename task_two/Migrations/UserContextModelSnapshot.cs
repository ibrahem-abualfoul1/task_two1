﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task_two.Data;

namespace task_two.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("task_two.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int")
                        .HasColumnName("IdRole");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("countriesenum")
                        .HasColumnType("int");

                    b.Property<int>("genderenum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("task_two.Models.Bill", b =>
                {
                    b.Property<int>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateBill")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discounte")
                        .HasColumnType("int");

                    b.Property<string>("NameBill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numberitems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IdBill");

                    b.ToTable("bills");
                });

            modelBuilder.Entity("task_two.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Describtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategory");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("task_two.Models.MangePage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AboutUs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactUs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pharmacylocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialMedia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pharmacyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mangePages");
                });

            modelBuilder.Entity("task_two.Models.Messege", b =>
                {
                    b.Property<int>("IdMessege")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContactMessege")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMessege")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResivedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMessege");

                    b.ToTable("messeges");
                });

            modelBuilder.Entity("task_two.Models.Prodact", b =>
                {
                    b.Property<int>("IdProdact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CatigoryIdCategory")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateProdact")
                        .HasColumnType("datetime2");

                    b.Property<string>("Describtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("NameProdact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("IdProdact");

                    b.HasIndex("CatigoryIdCategory");

                    b.ToTable("prodacts");
                });

            modelBuilder.Entity("task_two.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRole");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("task_two.Models.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ContactText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reviwe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("testimonials");
                });

            modelBuilder.Entity("task_two.Models.Transaction", b =>
                {
                    b.Property<int>("IdTransaction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("IdTransaction");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("task_two.Models.Prodact", b =>
                {
                    b.HasOne("task_two.Models.Category", "Catigory")
                        .WithMany("Productes")
                        .HasForeignKey("CatigoryIdCategory");

                    b.Navigation("Catigory");
                });

            modelBuilder.Entity("task_two.Models.Category", b =>
                {
                    b.Navigation("Productes");
                });
#pragma warning restore 612, 618
        }
    }
}
