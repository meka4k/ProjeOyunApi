using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjeOyun.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_nonavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Campaigns_CampaignId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Games_GameId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CampaignId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_GameId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_PlayerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CampaignId",
                table: "Sales",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_GameId",
                table: "Sales",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PlayerId",
                table: "Sales",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Campaigns_CampaignId",
                table: "Sales",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Games_GameId",
                table: "Sales",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Players_PlayerId",
                table: "Sales",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
