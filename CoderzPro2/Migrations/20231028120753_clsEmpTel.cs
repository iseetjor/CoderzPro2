﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoderzPro2.Migrations
{
    /// <inheritdoc />
    public partial class clsEmpTel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Employees");
        }
    }
}
