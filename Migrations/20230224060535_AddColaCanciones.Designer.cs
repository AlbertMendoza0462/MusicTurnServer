﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicTurn.DAL;

#nullable disable

namespace MusicTurn.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230224060535_AddColaCanciones")]
    partial class AddColaCanciones
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MusicTurn.Models.Cancion", b =>
                {
                    b.Property<int>("CancionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CancionId");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("MusicTurn.Models.ColaCancion", b =>
                {
                    b.Property<int>("ColaCancionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CancionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaPeticion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Nombre")
                        .HasColumnType("INTEGER");

                    b.HasKey("ColaCancionId");

                    b.ToTable("ColaCanciones");
                });
#pragma warning restore 612, 618
        }
    }
}