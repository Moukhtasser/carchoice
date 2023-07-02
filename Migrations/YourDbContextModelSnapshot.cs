﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testPFA.Data;

#nullable disable

namespace testPFA.Migrations
{
    [DbContext(typeof(YourDbContext))]
    partial class YourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("testPFA.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoueurIdLoueur")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.HasIndex("LoueurIdLoueur");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("testPFA.Models.Extra", b =>
                {
                    b.Property<int>("IdExtra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExtra"), 1L, 1);

                    b.Property<string>("NomExtra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<int>("ReservationIdReservation")
                        .HasColumnType("int");

                    b.HasKey("IdExtra");

                    b.HasIndex("ReservationIdReservation");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("testPFA.Models.Loueur", b =>
                {
                    b.Property<int>("IdLoueur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoueur"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLoueur");

                    b.ToTable("Loueurs");
                });

            modelBuilder.Entity("testPFA.Models.ModeleDeVoiture", b =>
                {
                    b.Property<int>("IdModele")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModele"), 1L, 1);

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdModele");

                    b.ToTable("ModelesDeVoiture");
                });

            modelBuilder.Entity("testPFA.Models.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"), 1L, 1);

                    b.Property<int>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdSaison")
                        .HasColumnType("int");

                    b.Property<int>("VoitureIdModele")
                        .HasColumnType("int");

                    b.HasKey("IdReservation");

                    b.HasIndex("ClientIdClient");

                    b.HasIndex("IdSaison");

                    b.HasIndex("VoitureIdModele");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("testPFA.Models.Saison", b =>
                {
                    b.Property<int>("IdSaison")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSaison"), 1L, 1);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSaison");

                    b.ToTable("Saisons");
                });

            modelBuilder.Entity("testPFA.Models.Client", b =>
                {
                    b.HasOne("testPFA.Models.Loueur", "Loueur")
                        .WithMany("Clients")
                        .HasForeignKey("LoueurIdLoueur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loueur");
                });

            modelBuilder.Entity("testPFA.Models.Extra", b =>
                {
                    b.HasOne("testPFA.Models.Reservation", "Reservation")
                        .WithMany("Extras")
                        .HasForeignKey("ReservationIdReservation")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("testPFA.Models.Reservation", b =>
                {
                    b.HasOne("testPFA.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientIdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testPFA.Models.Saison", "Saison")
                        .WithMany("Reservations")
                        .HasForeignKey("IdSaison")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("testPFA.Models.ModeleDeVoiture", "Voiture")
                        .WithMany()
                        .HasForeignKey("VoitureIdModele")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Saison");

                    b.Navigation("Voiture");
                });

            modelBuilder.Entity("testPFA.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("testPFA.Models.Loueur", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("testPFA.Models.Reservation", b =>
                {
                    b.Navigation("Extras");
                });

            modelBuilder.Entity("testPFA.Models.Saison", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
