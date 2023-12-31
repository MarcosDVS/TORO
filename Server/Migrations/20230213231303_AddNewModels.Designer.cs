﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TORO.Server.Context;

#nullable disable

namespace TORO.Server.Migrations
{
    [DbContext(typeof(TORODbContext))]
    [Migration("20230213231303_AddNewModels")]
    partial class AddNewModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TORO.Server.Models.Bovino", b =>
                {
                    b.Property<int>("IdBovino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBovino"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Costo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdMadre")
                        .HasColumnType("int");

                    b.Property<int?>("IdPadre")
                        .HasColumnType("int");

                    b.Property<int>("MadresID")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PadresID")
                        .HasColumnType("int");

                    b.Property<int?>("PesoNacer")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBovino");

                    b.HasIndex("MadresID");

                    b.HasIndex("PadresID");

                    b.ToTable("Bovinos");
                });

            modelBuilder.Entity("TORO.Server.Models.Madre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ColorHijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHijo")
                        .HasColumnType("int");

                    b.Property<int>("IdMadre")
                        .HasColumnType("int");

                    b.Property<string>("SexoHijo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Madres");
                });

            modelBuilder.Entity("TORO.Server.Models.Padre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ColorHijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHijo")
                        .HasColumnType("int");

                    b.Property<int>("IdPadre")
                        .HasColumnType("int");

                    b.Property<string>("SexoHijo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Padres");
                });

            modelBuilder.Entity("TORO.Server.Models.Preñes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("FechaPre")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdToro")
                        .HasColumnType("int");

                    b.Property<int>("IdVaca")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPreñes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PFP")
                        .HasColumnType("datetime2");

                    b.Property<string>("RazaToro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaVaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Preñeses");
                });

            modelBuilder.Entity("TORO.Server.Models.Produccion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("FechaProd")
                        .HasColumnType("datetime2");

                    b.Property<int>("LitrosLeche")
                        .HasColumnType("int");

                    b.Property<int>("VacasProd")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Producciones");
                });

            modelBuilder.Entity("TORO.Server.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioRolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioRolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TORO.Server.Models.UsuarioRol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PermisoCrar")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoEditar")
                        .HasColumnType("bit");

                    b.Property<bool>("PermisoEliminar")
                        .HasColumnType("bit");

                    b.Property<int?>("UsuarioRolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioRolId");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("TORO.Server.Models.Bovino", b =>
                {
                    b.HasOne("TORO.Server.Models.Madre", "Madres")
                        .WithMany()
                        .HasForeignKey("MadresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TORO.Server.Models.Padre", "Padres")
                        .WithMany()
                        .HasForeignKey("PadresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Madres");

                    b.Navigation("Padres");
                });

            modelBuilder.Entity("TORO.Server.Models.Usuario", b =>
                {
                    b.HasOne("TORO.Server.Models.UsuarioRol", "UsuarioRol")
                        .WithMany()
                        .HasForeignKey("UsuarioRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioRol");
                });

            modelBuilder.Entity("TORO.Server.Models.UsuarioRol", b =>
                {
                    b.HasOne("TORO.Server.Models.UsuarioRol", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioRolId");
                });

            modelBuilder.Entity("TORO.Server.Models.UsuarioRol", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
