﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VestibularApp.Infrastructure.Data;

namespace VestibularApp.Infrastructure.Migrations
{
    [DbContext(typeof(VestibularContext))]
    [Migration("20250405191847_CreateBD")]
    partial class CreateBD
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("VestibularApp.Domain.Entities.Candidato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VagasDisponiveis")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.Inscricao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroInscricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProcessoSeletivoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("CursoId");

                    b.HasIndex("ProcessoSeletivoId");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.ProcessoSeletivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcessosSeletivos");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.Inscricao", b =>
                {
                    b.HasOne("VestibularApp.Domain.Entities.Candidato", "Candidato")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VestibularApp.Domain.Entities.Curso", "Curso")
                        .WithMany("Inscricoes")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VestibularApp.Domain.Entities.ProcessoSeletivo", "ProcessoSeletivo")
                        .WithMany("Inscricoes")
                        .HasForeignKey("ProcessoSeletivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Curso");

                    b.Navigation("ProcessoSeletivo");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.Candidato", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.Curso", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("VestibularApp.Domain.Entities.ProcessoSeletivo", b =>
                {
                    b.Navigation("Inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
