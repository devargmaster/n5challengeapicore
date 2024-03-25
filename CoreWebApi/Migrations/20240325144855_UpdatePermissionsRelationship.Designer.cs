﻿// <auto-generated />
using System;
using CoreWebApi.ApiData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240325144855_UpdatePermissionsRelationship")]
    partial class UpdatePermissionsRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreWebApi.Models.Entities.Permissions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApellidoEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPermiso")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TipoPermisoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TipoPermisoId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CoreWebApi.Models.Entities.PermissionsType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionsTypes");
                });

            modelBuilder.Entity("CoreWebApi.Models.Entities.Permissions", b =>
                {
                    b.HasOne("CoreWebApi.Models.Entities.PermissionsType", "PermissionsType")
                        .WithMany()
                        .HasForeignKey("TipoPermisoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionsType");
                });
#pragma warning restore 612, 618
        }
    }
}
