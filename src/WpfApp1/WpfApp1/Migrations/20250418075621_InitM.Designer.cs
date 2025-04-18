﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp1;

namespace WpfApp1.Migrations
{
    [DbContext(typeof(PizzaDbSharapovaContext))]
    [Migration("20250418075621_InitM")]
    partial class InitM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WpfApp1.Addre", b =>
                {
                    b.Property<int>("AddresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AddresID")
                        .UseIdentityColumn();

                    b.Property<string>("FlatNumber")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<string>("HomeNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength(true);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AddresId");

                    b.ToTable("Addres");
                });

            modelBuilder.Entity("WpfApp1.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientID");

                    b.Property<string>("ClientFname")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("ClientFName");

                    b.Property<string>("ClientLname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ClientLName");

                    b.Property<string>("ClientPatronumic")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WpfApp1.ClientAddre", b =>
                {
                    b.Property<int>("ClientAddresId")
                        .HasColumnType("int")
                        .HasColumnName("ClientAddresID");

                    b.Property<int>("AddresId")
                        .HasColumnType("int")
                        .HasColumnName("AddresID");

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientID");

                    b.HasKey("ClientAddresId");

                    b.HasIndex("AddresId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAddres");
                });

            modelBuilder.Entity("WpfApp1.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnName("IngredientID");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("WpfApp1.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaID");

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("WpfApp1.PizzaAssortiment", b =>
                {
                    b.Property<int>("PizzaAssortimentId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaAssortimentID");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaID");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaSizeID");

                    b.Property<double>("PizzaWeight")
                        .HasColumnType("float");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("PizzaAssortimentId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("PizzaAssortiment");
                });

            modelBuilder.Entity("WpfApp1.PizzaIngredient", b =>
                {
                    b.Property<int>("PizzaIngredientId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaIngredientID");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int")
                        .HasColumnName("IngredientID");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaID");

                    b.HasKey("PizzaIngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngredient");
                });

            modelBuilder.Entity("WpfApp1.PizzaOrder", b =>
                {
                    b.Property<int>("PizzaOrderId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaOrderID");

                    b.Property<int>("ClientAddresId")
                        .HasColumnType("int")
                        .HasColumnName("ClientAddresID");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("PizzaAssortimentId")
                        .HasColumnType("int")
                        .HasColumnName("PizzaAssortimentID");

                    b.Property<int>("PizzaCount")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("PizzaOrderId");

                    b.HasIndex("ClientAddresId");

                    b.HasIndex("PizzaAssortimentId");

                    b.ToTable("PizzaOrder");
                });

            modelBuilder.Entity("WpfApp1.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .HasColumnType("int")
                        .HasColumnName("SizeID");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SizeId");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("WpfApp1.ClientAddre", b =>
                {
                    b.HasOne("WpfApp1.Addre", "Addres")
                        .WithMany("ClientAddres")
                        .HasForeignKey("AddresId")
                        .HasConstraintName("FK_ClientAddres_Addres")
                        .IsRequired();

                    b.HasOne("WpfApp1.Client", "Client")
                        .WithMany("ClientAddres")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_ClientAddres_Client")
                        .IsRequired();

                    b.Navigation("Addres");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WpfApp1.PizzaAssortiment", b =>
                {
                    b.HasOne("WpfApp1.Pizza", "Pizza")
                        .WithMany("PizzaAssortiments")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_PizzaAssortiment_Pizza")
                        .IsRequired();

                    b.HasOne("WpfApp1.Size", "PizzaSize")
                        .WithMany("PizzaAssortiments")
                        .HasForeignKey("PizzaSizeId")
                        .HasConstraintName("FK_PizzaAssortiment_Size")
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("PizzaSize");
                });

            modelBuilder.Entity("WpfApp1.PizzaIngredient", b =>
                {
                    b.HasOne("WpfApp1.Ingredient", "Ingredient")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("IngredientId")
                        .HasConstraintName("FK_PizzaIngredient_Ingredient")
                        .IsRequired();

                    b.HasOne("WpfApp1.Pizza", "Pizza")
                        .WithMany("PizzaIngredients")
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("FK_PizzaIngredient_Pizza")
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("WpfApp1.PizzaOrder", b =>
                {
                    b.HasOne("WpfApp1.ClientAddre", "ClientAddres")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("ClientAddresId")
                        .HasConstraintName("FK_PizzaOrder_ClientAddres")
                        .IsRequired();

                    b.HasOne("WpfApp1.PizzaAssortiment", "PizzaAssortiment")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaAssortimentId")
                        .HasConstraintName("FK_PizzaOrder_PizzaAssortiment")
                        .IsRequired();

                    b.Navigation("ClientAddres");

                    b.Navigation("PizzaAssortiment");
                });

            modelBuilder.Entity("WpfApp1.Addre", b =>
                {
                    b.Navigation("ClientAddres");
                });

            modelBuilder.Entity("WpfApp1.Client", b =>
                {
                    b.Navigation("ClientAddres");
                });

            modelBuilder.Entity("WpfApp1.ClientAddre", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("WpfApp1.Ingredient", b =>
                {
                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("WpfApp1.Pizza", b =>
                {
                    b.Navigation("PizzaAssortiments");

                    b.Navigation("PizzaIngredients");
                });

            modelBuilder.Entity("WpfApp1.PizzaAssortiment", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("WpfApp1.Size", b =>
                {
                    b.Navigation("PizzaAssortiments");
                });
#pragma warning restore 612, 618
        }
    }
}
