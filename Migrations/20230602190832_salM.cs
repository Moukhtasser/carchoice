using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testPFA.Migrations
{
    public partial class salM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loueurs",
                columns: table => new
                {
                    IdLoueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loueurs", x => x.IdLoueur);
                });

            migrationBuilder.CreateTable(
                name: "ModelesDeVoiture",
                columns: table => new
                {
                    IdModele = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelesDeVoiture", x => x.IdModele);
                });

            migrationBuilder.CreateTable(
                name: "Saisons",
                columns: table => new
                {
                    IdSaison = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saisons", x => x.IdSaison);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoueurIdLoueur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_Loueurs_LoueurIdLoueur",
                        column: x => x.LoueurIdLoueur,
                        principalTable: "Loueurs",
                        principalColumn: "IdLoueur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false),
                    VoitureIdModele = table.Column<int>(type: "int", nullable: false),
                    IdSaison = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ModelesDeVoiture_VoitureIdModele",
                        column: x => x.VoitureIdModele,
                        principalTable: "ModelesDeVoiture",
                        principalColumn: "IdModele",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Saisons_IdSaison",
                        column: x => x.IdSaison,
                        principalTable: "Saisons",
                        principalColumn: "IdSaison",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    IdExtra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomExtra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    ReservationIdReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.IdExtra);
                    table.ForeignKey(
                        name: "FK_Extras_Reservations_ReservationIdReservation",
                        column: x => x.ReservationIdReservation,
                        principalTable: "Reservations",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LoueurIdLoueur",
                table: "Clients",
                column: "LoueurIdLoueur");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_ReservationIdReservation",
                table: "Extras",
                column: "ReservationIdReservation");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientIdClient",
                table: "Reservations",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IdSaison",
                table: "Reservations",
                column: "IdSaison");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VoitureIdModele",
                table: "Reservations",
                column: "VoitureIdModele");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ModelesDeVoiture");

            migrationBuilder.DropTable(
                name: "Saisons");

            migrationBuilder.DropTable(
                name: "Loueurs");
        }
    }
}
