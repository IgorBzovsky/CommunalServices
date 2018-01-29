using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CommunalServices.Migrations
{
    public partial class RenametableProvidertoProviders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidedUtility_Provider_ProviderId",
                table: "ProvidedUtility");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Locations_LocationId",
                table: "Provider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provider",
                table: "Provider");

            migrationBuilder.RenameTable(
                name: "Provider",
                newName: "Providers");

            migrationBuilder.RenameIndex(
                name: "IX_Provider_LocationId",
                table: "Providers",
                newName: "IX_Providers_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidedUtility_Providers_ProviderId",
                table: "ProvidedUtility",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvidedUtility_Providers_ProviderId",
                table: "ProvidedUtility");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "Provider");

            migrationBuilder.RenameIndex(
                name: "IX_Providers_LocationId",
                table: "Provider",
                newName: "IX_Provider_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provider",
                table: "Provider",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvidedUtility_Provider_ProviderId",
                table: "ProvidedUtility",
                column: "ProviderId",
                principalTable: "Provider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Locations_LocationId",
                table: "Provider",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
