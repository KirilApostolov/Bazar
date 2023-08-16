using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Data.Migrations
{
    public partial class SetTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                comment: "Ad CreatedOn",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Ad ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                comment: "Ad ImageUrl",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Ad CreatedOn");
        }
    }
}
