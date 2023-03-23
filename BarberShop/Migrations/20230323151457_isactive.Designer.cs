﻿// <auto-generated />
using System;
using BarberShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarberShop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230323151457_isactive")]
    partial class isactive
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarberShop.Models.BarberEmployee", b =>
                {
                    b.Property<int>("BarberEmpolyeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarberEmpolyeeId"));

                    b.Property<int>("BarberUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("BarberEmpolyeeId");

                    b.HasIndex("BarberUserId");

                    b.ToTable("BarberEmployees");
                });

            modelBuilder.Entity("BarberShop.Models.BarberService", b =>
                {
                    b.Property<int>("BarberServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BarberServiceId"));

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("BarberServiceId");

                    b.HasIndex("BarberId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BarberServices");
                });

            modelBuilder.Entity("BarberShop.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<bool>("BarberApprove")
                        .HasColumnType("bit");

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CustomerApprove")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("BarberId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BarberShop.Models.ReservationService", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("ReservationId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ReservationService");
                });

            modelBuilder.Entity("BarberShop.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BarberShop.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BarberShop.Models.Barber", b =>
                {
                    b.HasBaseType("BarberShop.Models.User");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionPeriod")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Barber");
                });

            modelBuilder.Entity("BarberShop.Models.Customer", b =>
                {
                    b.HasBaseType("BarberShop.Models.User");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("BarberShop.Models.BarberEmployee", b =>
                {
                    b.HasOne("BarberShop.Models.Barber", "Barber")
                        .WithMany("BarberEmployees")
                        .HasForeignKey("BarberUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("BarberShop.Models.BarberService", b =>
                {
                    b.HasOne("BarberShop.Models.Service", "Service")
                        .WithMany("BarberServices")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Barber", "Barber")
                        .WithMany("BarberServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BarberShop.Models.Reservation", b =>
                {
                    b.HasOne("BarberShop.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Barber", "Barber")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Barber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BarberShop.Models.ReservationService", b =>
                {
                    b.HasOne("BarberShop.Models.BarberService", "BarberService")
                        .WithMany("ReservationServices")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Reservation", "Reservation")
                        .WithMany("ReservationServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("BarberService");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("BarberShop.Models.BarberService", b =>
                {
                    b.Navigation("ReservationServices");
                });

            modelBuilder.Entity("BarberShop.Models.Reservation", b =>
                {
                    b.Navigation("ReservationServices");
                });

            modelBuilder.Entity("BarberShop.Models.Service", b =>
                {
                    b.Navigation("BarberServices");
                });

            modelBuilder.Entity("BarberShop.Models.Barber", b =>
                {
                    b.Navigation("BarberEmployees");

                    b.Navigation("BarberServices");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("BarberShop.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
