﻿// <auto-generated />
using System;
using DesafioFrequencia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioFrequencia.Infra.Data.Migrations
{
    [DbContext(typeof(DesafioFrequenciaContext))]
    partial class DesafioFrequenciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Desafios.Desafio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Desafios");
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Participantes.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.RegistroFrequencias.RegistroFrequencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DesafioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipanteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DesafioId");

                    b.HasIndex("ParticipanteId");

                    b.ToTable("RegistroFrequencias");
                });

            modelBuilder.Entity("DesafioParticipante", b =>
                {
                    b.Property<int>("DesafiosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DesafiosId", "ParticipantesId");

                    b.HasIndex("ParticipantesId");

                    b.ToTable("DesafioParticipantes", (string)null);
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Desafios.Desafio", b =>
                {
                    b.OwnsOne("DesafioFrequencia.Domain.Models.Desafios.ValueObjects.Periodo", "Periodo", b1 =>
                        {
                            b1.Property<int>("DesafioId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Fim")
                                .HasColumnType("TEXT")
                                .HasColumnName("Fim");

                            b1.Property<DateTime>("Inicio")
                                .HasColumnType("TEXT")
                                .HasColumnName("Inicio");

                            b1.HasKey("DesafioId");

                            b1.ToTable("Desafios");

                            b1.WithOwner()
                                .HasForeignKey("DesafioId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.Desafios.ValueObjects.Regra", "Regra", b1 =>
                        {
                            b1.Property<int>("DesafioId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("InicioDaSemana")
                                .HasColumnType("INTEGER")
                                .HasColumnName("InicioDaSemana");

                            b1.Property<int>("QuantidadeDiasObrigatorio")
                                .HasColumnType("INTEGER")
                                .HasColumnName("QuantidadeDiasObrigatorio");

                            b1.HasKey("DesafioId");

                            b1.ToTable("Desafios");

                            b1.WithOwner()
                                .HasForeignKey("DesafioId");
                        });

                    b.Navigation("Periodo")
                        .IsRequired();

                    b.Navigation("Regra")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Participantes.Participante", b =>
                {
                    b.OwnsOne("DesafioFrequencia.Domain.Models.Participantes.ValueObjects.DataDeNascimento", "DataDeNascimento", b1 =>
                        {
                            b1.Property<int>("ParticipanteId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Valor")
                                .HasColumnType("TEXT")
                                .HasColumnName("DataDeNascimento");

                            b1.HasKey("ParticipanteId");

                            b1.ToTable("Participantes");

                            b1.WithOwner()
                                .HasForeignKey("ParticipanteId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.Participantes.ValueObjects.Imagem", "Imagem", b1 =>
                        {
                            b1.Property<int>("ParticipanteId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Imagem");

                            b1.HasKey("ParticipanteId");

                            b1.ToTable("Participantes");

                            b1.WithOwner()
                                .HasForeignKey("ParticipanteId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.Participantes.ValueObjects.NomeCompleto", "NomeCompleto", b1 =>
                        {
                            b1.Property<int>("ParticipanteId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("TEXT")
                                .HasColumnName("Nome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("TEXT")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("ParticipanteId");

                            b1.ToTable("Participantes");

                            b1.WithOwner()
                                .HasForeignKey("ParticipanteId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.Participantes.ValueObjects.Sexo", "Sexo", b1 =>
                        {
                            b1.Property<int>("ParticipanteId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("TEXT")
                                .HasColumnName("Sexo");

                            b1.HasKey("ParticipanteId");

                            b1.ToTable("Participantes");

                            b1.WithOwner()
                                .HasForeignKey("ParticipanteId");
                        });

                    b.Navigation("DataDeNascimento")
                        .IsRequired();

                    b.Navigation("Imagem");

                    b.Navigation("NomeCompleto")
                        .IsRequired();

                    b.Navigation("Sexo")
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.RegistroFrequencias.RegistroFrequencia", b =>
                {
                    b.HasOne("DesafioFrequencia.Domain.Models.Desafios.Desafio", "Desafio")
                        .WithMany("RegistroFrequencias")
                        .HasForeignKey("DesafioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioFrequencia.Domain.Models.Participantes.Participante", "Participante")
                        .WithMany("RegistroFrequencias")
                        .HasForeignKey("ParticipanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects.DataFrequencia", "DataFrequencia", b1 =>
                        {
                            b1.Property<int>("RegistroFrequenciaId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Data")
                                .HasColumnType("TEXT")
                                .HasColumnName("Data");

                            b1.HasKey("RegistroFrequenciaId");

                            b1.ToTable("RegistroFrequencias");

                            b1.WithOwner()
                                .HasForeignKey("RegistroFrequenciaId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects.EstadoFrequencia", "EstadoFrequencia", b1 =>
                        {
                            b1.Property<int>("RegistroFrequenciaId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Tipo")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("TEXT")
                                .HasColumnName("Estado");

                            b1.HasKey("RegistroFrequenciaId");

                            b1.ToTable("RegistroFrequencias");

                            b1.WithOwner()
                                .HasForeignKey("RegistroFrequenciaId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects.Imagem", "Imagem", b1 =>
                        {
                            b1.Property<int>("RegistroFrequenciaId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Endereco")
                                .HasMaxLength(100)
                                .HasColumnType("TEXT")
                                .HasColumnName("Imagem");

                            b1.HasKey("RegistroFrequenciaId");

                            b1.ToTable("RegistroFrequencias");

                            b1.WithOwner()
                                .HasForeignKey("RegistroFrequenciaId");
                        });

                    b.OwnsOne("DesafioFrequencia.Domain.Models.RegistroFrequencias.ValueObjects.Modalidade", "Modalidade", b1 =>
                        {
                            b1.Property<int>("RegistroFrequenciaId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Tipo")
                                .HasMaxLength(20)
                                .HasColumnType("TEXT")
                                .HasColumnName("Modalidade");

                            b1.HasKey("RegistroFrequenciaId");

                            b1.ToTable("RegistroFrequencias");

                            b1.WithOwner()
                                .HasForeignKey("RegistroFrequenciaId");
                        });

                    b.Navigation("DataFrequencia")
                        .IsRequired();

                    b.Navigation("Desafio");

                    b.Navigation("EstadoFrequencia")
                        .IsRequired();

                    b.Navigation("Imagem")
                        .IsRequired();

                    b.Navigation("Modalidade")
                        .IsRequired();

                    b.Navigation("Participante");
                });

            modelBuilder.Entity("DesafioParticipante", b =>
                {
                    b.HasOne("DesafioFrequencia.Domain.Models.Desafios.Desafio", null)
                        .WithMany()
                        .HasForeignKey("DesafiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioFrequencia.Domain.Models.Participantes.Participante", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Desafios.Desafio", b =>
                {
                    b.Navigation("RegistroFrequencias");
                });

            modelBuilder.Entity("DesafioFrequencia.Domain.Models.Participantes.Participante", b =>
                {
                    b.Navigation("RegistroFrequencias");
                });
#pragma warning restore 612, 618
        }
    }
}
