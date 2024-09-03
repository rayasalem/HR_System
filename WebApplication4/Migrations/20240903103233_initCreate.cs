using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EmpDet");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    DepartmentHead = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Budget = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionTitle = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    PositionDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTitle = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "EmpDet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepRef = table.Column<int>(type: "int", nullable: false),
                    DepsID = table.Column<int>(type: "int", nullable: true),
                    PosRef = table.Column<int>(type: "int", nullable: false),
                    posID = table.Column<int>(type: "int", nullable: true),
                    ProRef = table.Column<int>(type: "int", nullable: false),
                    projsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepsID",
                        column: x => x.DepsID,
                        principalSchema: "EmpDet",
                        principalTable: "Department",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employee_Position_posID",
                        column: x => x.posID,
                        principalSchema: "EmpDet",
                        principalTable: "Position",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employee_Project_projsID",
                        column: x => x.projsID,
                        principalSchema: "EmpDet",
                        principalTable: "Project",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractType = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EmpRef = table.Column<int>(type: "int", nullable: false),
                    empsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contract_Employee_empsId",
                        column: x => x.empsId,
                        principalSchema: "EmpDet",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceName = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    InvoiceDate = table.Column<DateOnly>(type: "date", nullable: true),
                    InvoiceDue = table.Column<DateOnly>(type: "date", nullable: true),
                    InvoiceDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    EmpRef = table.Column<int>(type: "int", nullable: false),
                    empsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Employee_empsId",
                        column: x => x.empsId,
                        principalSchema: "EmpDet",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                schema: "EmpDet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoRequest = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    EmpRef = table.Column<int>(type: "int", nullable: false),
                    empsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_empsId",
                        column: x => x.empsId,
                        principalSchema: "EmpDet",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_empsId",
                schema: "EmpDet",
                table: "Contract",
                column: "empsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepsID",
                schema: "EmpDet",
                table: "Employee",
                column: "DepsID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_posID",
                schema: "EmpDet",
                table: "Employee",
                column: "posID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_projsID",
                schema: "EmpDet",
                table: "Employee",
                column: "projsID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_empsId",
                schema: "EmpDet",
                table: "Invoice",
                column: "empsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_empsId",
                schema: "EmpDet",
                table: "LeaveRequest",
                column: "empsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "LeaveRequest",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "EmpDet");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "EmpDet");
        }
    }
}
