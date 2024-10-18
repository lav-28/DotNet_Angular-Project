using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateTraineeEnrollmentApi.Migrations
{
    public partial class InitalCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DegreeDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    StreamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreamName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StreamDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DegreeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Streams__07C87A9261B6B4F7", x => x.StreamId);
                    table.ForeignKey(
                        name: "FK__Streams__DegreeI__3D5E1FD2",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId");
                });

            migrationBuilder.CreateTable(
                name: "GraduateTrainees",
                columns: table => new
                {
                    GraduateTraineeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeId = table.Column<int>(type: "int", nullable: true),
                    StreamId = table.Column<int>(type: "int", nullable: true),
                    TraineeName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    TraineeEmail = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    UniversityName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    IsLastSemesterPending = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    DateOfApplication = table.Column<DateTime>(type: "date", nullable: false),
                    Image = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    AI = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Phyton = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    BusinessAnalysis = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MachineLearning = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Practical = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Percentages = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    IsAdmisisonConfirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Graduate__D5A8F04CC1671608", x => x.GraduateTraineeId);
                    table.ForeignKey(
                        name: "FK__GraduateT__Degre__3B75D760",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId");
                    table.ForeignKey(
                        name: "FK__GraduateT__Strea__3C69FB99",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "StreamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GraduateTrainees_DegreeId",
                table: "GraduateTrainees",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduateTrainees_StreamId",
                table: "GraduateTrainees",
                column: "StreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_DegreeId",
                table: "Streams",
                column: "DegreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraduateTrainees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Degree");
        }
    }
}
