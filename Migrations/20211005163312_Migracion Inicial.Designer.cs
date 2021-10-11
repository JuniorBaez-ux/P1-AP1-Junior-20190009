﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P1_AP1_Junior_20190009.DAL;

namespace P1_AP1_Junior_20190009.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211005163312_Migracion Inicial")]
    partial class MigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("P1_AP1_Junior_20190009.Entidades.Aportes", b =>
                {
                    b.Property<int>("AporteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<string>("Persona")
                        .HasColumnType("TEXT");

                    b.HasKey("AporteID");

                    b.ToTable("Aportes");
                });
#pragma warning restore 612, 618
        }
    }
}
