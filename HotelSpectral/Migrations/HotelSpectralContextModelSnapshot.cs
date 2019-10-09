﻿// <auto-generated />
using System;
using HotelSpectral.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelSpectral.Migrations
{
    [DbContext(typeof(HotelSpectralContext))]
    partial class HotelSpectralContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("HotelSpectral.Data.Entities.AuditTrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<DateTime>("AuditDate");

                    b.Property<string>("DataChanged");

                    b.Property<string>("IPAddress");

                    b.Property<int>("RowAffected");

                    b.Property<string>("TableAffected");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("AuditTrails");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Guests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("GuestNo");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("NationalIDNo");

                    b.Property<int>("NationlID");

                    b.Property<int>("Religion");

                    b.Property<int>("Status");

                    b.Property<int>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CreatedBy");

                    b.Property<int>("GuestId");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int>("PaymentStatus");

                    b.Property<string>("ReceiptNo");

                    b.Property<int>("ReservationId");

                    b.Property<string>("TransactionNo");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Descrition");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Adult");

                    b.Property<bool>("Breakfast");

                    b.Property<DateTime>("CheckInDate");

                    b.Property<DateTime>("CheckoutDate");

                    b.Property<int>("Children");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("GuestId");

                    b.Property<int>("NoOfNights");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<int>("RoomId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("RoleName");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsLocked");

                    b.Property<int>("MaxPerson");

                    b.Property<string>("RoomNo");

                    b.Property<decimal>("RoomPrice");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("LastLoginDate");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.Property<string>("NationalIDNo");

                    b.Property<int>("NationlID");

                    b.Property<string>("Password");

                    b.Property<string>("PictureName");

                    b.Property<int>("Religion");

                    b.Property<string>("Salt");

                    b.Property<bool>("Status");

                    b.Property<int>("Title");

                    b.Property<int>("UserType");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelSpectral.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("RoleId");

                    b.Property<bool>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}