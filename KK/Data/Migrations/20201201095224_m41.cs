using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KK.Data.Migrations
{
    public partial class m41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzavas",
                columns: table => new
                {
                    DrzavaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzavas", x => x.DrzavaId);
                });

            migrationBuilder.CreateTable(
                name: "Obavijests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Radnik_Kvalifikacijas",
                columns: table => new
                {
                    RadnikKvalifikacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    CV = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik_Kvalifikacijas", x => x.RadnikKvalifikacijaId);
                });

            migrationBuilder.CreateTable(
                name: "Tip_Linijes",
                columns: table => new
                {
                    LinijaTipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip_Linijes", x => x.LinijaTipId);
                });

            migrationBuilder.CreateTable(
                name: "Tip_Vozilas",
                columns: table => new
                {
                    VoziloTipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    BrojSjedista = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip_Vozilas", x => x.VoziloTipId);
                });

            migrationBuilder.CreateTable(
                name: "Grads",
                columns: table => new
                {
                    GradId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    DrzavaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grads", x => x.GradId);
                    table.ForeignKey(
                        name: "FK_Grads_Drzavas_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzavas",
                        principalColumn: "DrzavaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozilos",
                columns: table => new
                {
                    VoziloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistracijskeOznake = table.Column<string>(nullable: true),
                    Tip_VozilaId = table.Column<int>(nullable: true),
                    GodisteVozila = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilos", x => x.VoziloId);
                    table.ForeignKey(
                        name: "FK_Vozilos_Tip_Vozilas_Tip_VozilaId",
                        column: x => x.Tip_VozilaId,
                        principalTable: "Tip_Vozilas",
                        principalColumn: "VoziloTipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Linijas",
                columns: table => new
                {
                    LinijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolazisteID = table.Column<int>(nullable: true),
                    OdredisteID = table.Column<int>(nullable: true),
                    TimePolaska = table.Column<string>(nullable: true),
                    TimeDolazak = table.Column<string>(nullable: true),
                    DuzinaPutovanja = table.Column<string>(nullable: true),
                    Tip_LinijeID = table.Column<int>(nullable: true),
                    Cijena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linijas", x => x.LinijaId);
                    table.ForeignKey(
                        name: "FK_Linijas_Grads_OdredisteID",
                        column: x => x.OdredisteID,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Linijas_Grads_PolazisteID",
                        column: x => x.PolazisteID,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Linijas_Tip_Linijes_Tip_LinijeID",
                        column: x => x.Tip_LinijeID,
                        principalTable: "Tip_Linijes",
                        principalColumn: "LinijaTipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Radniks",
                columns: table => new
                {
                    RadnikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Radnik_KvalifikacijaId = table.Column<int>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    GradId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radniks", x => x.RadnikId);
                    table.ForeignKey(
                        name: "FK_Radniks_Grads_GradId",
                        column: x => x.GradId,
                        principalTable: "Grads",
                        principalColumn: "GradId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radniks_Radnik_Kvalifikacijas_Radnik_KvalifikacijaId",
                        column: x => x.Radnik_KvalifikacijaId,
                        principalTable: "Radnik_Kvalifikacijas",
                        principalColumn: "RadnikKvalifikacijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voznjas",
                columns: table => new
                {
                    VoznjaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnikId = table.Column<int>(nullable: true),
                    LinijaId = table.Column<int>(nullable: true),
                    VoziloId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voznjas", x => x.VoznjaId);
                    table.ForeignKey(
                        name: "FK_Voznjas_Linijas_LinijaId",
                        column: x => x.LinijaId,
                        principalTable: "Linijas",
                        principalColumn: "LinijaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voznjas_Radniks_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radniks",
                        principalColumn: "RadnikId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voznjas_Vozilos_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilos",
                        principalColumn: "VoziloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kartas",
                columns: table => new
                {
                    KartaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cijena = table.Column<float>(nullable: false),
                    VoznjaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartas", x => x.KartaId);
                    table.ForeignKey(
                        name: "FK_Kartas_Voznjas_VoznjaId",
                        column: x => x.VoznjaId,
                        principalTable: "Voznjas",
                        principalColumn: "VoznjaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prodaje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    KartaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodaje", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodaje_Kartas_KartaID",
                        column: x => x.KartaID,
                        principalTable: "Kartas",
                        principalColumn: "KartaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grads_DrzavaId",
                table: "Grads",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kartas_VoznjaId",
                table: "Kartas",
                column: "VoznjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Linijas_OdredisteID",
                table: "Linijas",
                column: "OdredisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Linijas_PolazisteID",
                table: "Linijas",
                column: "PolazisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Linijas_Tip_LinijeID",
                table: "Linijas",
                column: "Tip_LinijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodaje_KartaID",
                table: "Prodaje",
                column: "KartaID");

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_GradId",
                table: "Radniks",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Radniks_Radnik_KvalifikacijaId",
                table: "Radniks",
                column: "Radnik_KvalifikacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilos_Tip_VozilaId",
                table: "Vozilos",
                column: "Tip_VozilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznjas_LinijaId",
                table: "Voznjas",
                column: "LinijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznjas_RadnikId",
                table: "Voznjas",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Voznjas_VoziloId",
                table: "Voznjas",
                column: "VoziloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obavijests");

            migrationBuilder.DropTable(
                name: "Prodaje");

            migrationBuilder.DropTable(
                name: "Kartas");

            migrationBuilder.DropTable(
                name: "Voznjas");

            migrationBuilder.DropTable(
                name: "Linijas");

            migrationBuilder.DropTable(
                name: "Radniks");

            migrationBuilder.DropTable(
                name: "Vozilos");

            migrationBuilder.DropTable(
                name: "Tip_Linijes");

            migrationBuilder.DropTable(
                name: "Grads");

            migrationBuilder.DropTable(
                name: "Radnik_Kvalifikacijas");

            migrationBuilder.DropTable(
                name: "Tip_Vozilas");

            migrationBuilder.DropTable(
                name: "Drzavas");
        }
    }
}
