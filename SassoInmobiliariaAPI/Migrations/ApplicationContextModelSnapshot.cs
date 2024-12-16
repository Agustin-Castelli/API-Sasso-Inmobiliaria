﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SassoInmobiliariaAPI.Data.Services;

#nullable disable

namespace SassoInmobiliariaAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SassoInmobiliariaAPI.Models.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SassoInmobiliariaAPI.Models.Entities.DevelopmentProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DevelopAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevelopDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevelopImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DevelopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DevelopmentProps");
                });

            modelBuilder.Entity("SassoInmobiliariaAPI.Models.Entities.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<int>("Baths")
                        .HasColumnType("int");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DevelopmentPropId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDistingued")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUpToCredit")
                        .HasColumnType("bit");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfOffer")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfProp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DevelopmentPropId");

                    b.ToTable("Propertys");
                });

            modelBuilder.Entity("SassoInmobiliariaAPI.Models.Entities.Property", b =>
                {
                    b.HasOne("SassoInmobiliariaAPI.Models.Entities.DevelopmentProp", null)
                        .WithMany("Properties")
                        .HasForeignKey("DevelopmentPropId");
                });

            modelBuilder.Entity("SassoInmobiliariaAPI.Models.Entities.DevelopmentProp", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
