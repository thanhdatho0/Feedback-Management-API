using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ticket_ResponseTicketId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Ticket_TicketId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_CategoryItems_CategoryItemId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employees_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Students_StudentId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketUrgencies_TicketUrgencyId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Images_ResponseTicketId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ResponseTicketId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_TicketUrgencyId",
                table: "Tickets",
                newName: "IX_Tickets_TicketUrgencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_StudentId",
                table: "Tickets",
                newName: "IX_Tickets_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Tickets",
                newName: "IX_Tickets_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CategoryItemId",
                table: "Tickets",
                newName: "IX_Tickets_CategoryItemId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_CategoryItems_CategoryItemId",
                table: "Tickets",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Students_StudentId",
                table: "Tickets",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketUrgencies_TicketUrgencyId",
                table: "Tickets",
                column: "TicketUrgencyId",
                principalTable: "TicketUrgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Tickets_TicketId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CategoryItems_CategoryItemId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees_EmployeeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Students_StudentId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketUrgencies_TicketUrgencyId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TicketUrgencyId",
                table: "Ticket",
                newName: "IX_Ticket_TicketUrgencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_StudentId",
                table: "Ticket",
                newName: "IX_Ticket_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EmployeeId",
                table: "Ticket",
                newName: "IX_Ticket_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CategoryItemId",
                table: "Ticket",
                newName: "IX_Ticket_CategoryItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponseTicketId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Ticket",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ResponseTicketId",
                table: "Images",
                column: "ResponseTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ticket_ResponseTicketId",
                table: "Images",
                column: "ResponseTicketId",
                principalTable: "Ticket",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Ticket_TicketId",
                table: "Images",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_CategoryItems_CategoryItemId",
                table: "Ticket",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employees_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Students_StudentId",
                table: "Ticket",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketUrgencies_TicketUrgencyId",
                table: "Ticket",
                column: "TicketUrgencyId",
                principalTable: "TicketUrgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
