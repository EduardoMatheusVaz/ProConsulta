using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documents = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Documents = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    Crm = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specialitys_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedulings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    ConsultationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ConsultationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedulings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedulings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedulings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00043fbd-e5e1-49eb-836-8375610584f1", null, "Medico", "MEDICO" },
                    { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", null, "Atendente", "ATENDENTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95433ac4-2fe9-468f-b80d-b05ec3724d1d", 0, "04038210-71cc-40b2-babc-32f2bd442630", "Attendant", "proconsulta@hotmail.com.br", true, false, null, "Pro Consulta", "PROCONSULTA@HOTMAIL.COM.BR", "PROCONSULTA@HOTMAIL.COM.BR", "AQAAAAIAAYagAAAAECeCs1qt1ojFISI22dkGTswtIZHfjMR+cNap8mXDw8cAxbNsias9qQfbQ4h7V5CdXg==", null, false, "e5227707-65e5-49bd-b45f-2c6b453d0386", false, "proconsulta@hotmail.com.br" });

            migrationBuilder.InsertData(
                table: "Specialitys",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Especialidade médica que trata doenças do coração e do sistema cardiovascular.", "Cardiologia" },
                    { 2, "Especialidade médica que trata doenças da pele, cabelo e unhas.", "Dermatologia" },
                    { 3, "Especialidade médica que trata doenças do sistema digestivo.", "Gastroenterologia" },
                    { 4, "Especialidade médica que trata doenças do sistema nervoso.", "Neurologia" },
                    { 5, "Especialidade médica que trata doenças e lesões do sistema musculoesquelético.", "Ortopedia" },
                    { 6, "Especialidade médica que trata de crianças e adolescentes.", "Pediatria" },
                    { 7, "Especialidade médica que trata de doenças mentais e distúrbios emocionais.", "Psiquiatria" },
                    { 8, "Especialidade médica que trata doenças nos olhos", "Oftalmologia" },
                    { 9, "Especialidade médica que trata do sistema reprodutor feminino.", "Ginecologia" },
                    { 10, "Especialidade médica que trata do câncer.", "Oncologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", "95433ac4-2fe9-468f-b80d-b05ec3724d1d" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Documents",
                table: "Doctors",
                column: "Documents",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialtyId",
                table: "Doctors",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Documents",
                table: "Patients",
                column: "Documents",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_DoctorId",
                table: "Schedulings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedulings_PatientId",
                table: "Schedulings",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedulings");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specialitys");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00043fbd-e5e1-49eb-836-8375610584f1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8305f33b-5412-47d0-b4ab-17cf6867f2e2", "95433ac4-2fe9-468f-b80d-b05ec3724d1d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8305f33b-5412-47d0-b4ab-17cf6867f2e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
