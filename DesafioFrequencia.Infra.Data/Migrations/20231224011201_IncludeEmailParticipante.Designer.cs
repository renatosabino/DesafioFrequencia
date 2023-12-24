﻿// <auto-generated />
using System;
using DesafioFrequencia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioFrequencia.Infra.Data.Migrations
{
    [DbContext(typeof(DesafioFrequenciaContext))]
    [Migration("20231224011201_IncludeEmailParticipante")]
    partial class IncludeEmailParticipante
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("DesafioFrequencia.Infra.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

                    b.OwnsOne("DesafioFrequencia.Domain.Models.Participantes.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("ParticipanteId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Email");

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

                    b.Navigation("Email")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DesafioFrequencia.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DesafioFrequencia.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioFrequencia.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DesafioFrequencia.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
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
