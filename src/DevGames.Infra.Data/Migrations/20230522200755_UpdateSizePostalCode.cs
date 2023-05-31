using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevGames.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSizePostalCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "Dv_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 22, 17, 7, 55, 70, DateTimeKind.Local).AddTicks(3059),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 8, 17, 0, 56, 395, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Dv_Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "Dv_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 8, 17, 0, 56, 395, DateTimeKind.Local).AddTicks(3528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 22, 17, 7, 55, 70, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Dv_Address",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
