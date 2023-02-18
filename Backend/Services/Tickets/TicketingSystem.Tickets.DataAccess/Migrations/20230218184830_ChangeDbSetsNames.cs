using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Tickets.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbSetsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities");

            migrationBuilder.RenameTable(
                name: "Priorities",
                newName: "TicketPriorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketPriorities",
                table: "TicketPriorities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "TicketPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketPriorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketPriorities",
                table: "TicketPriorities");

            migrationBuilder.RenameTable(
                name: "TicketPriorities",
                newName: "Priorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
