using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AddTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Trees_TreeId",
                table: "Nodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes");

            migrationBuilder.RenameTable(
                name: "Nodes",
                newName: "Node");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_TreeId",
                table: "Node",
                newName: "IX_Node_TreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Nodes_ParentId",
                table: "Node",
                newName: "IX_Node_ParentId");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Trees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Node",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Node",
                table: "Node",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Node_ParentId",
                table: "Node",
                column: "ParentId",
                principalTable: "Node",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Node_Trees_TreeId",
                table: "Node",
                column: "TreeId",
                principalTable: "Trees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Node_Node_ParentId",
                table: "Node");

            migrationBuilder.DropForeignKey(
                name: "FK_Node_Trees_TreeId",
                table: "Node");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Node",
                table: "Node");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Trees");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Node");

            migrationBuilder.RenameTable(
                name: "Node",
                newName: "Nodes");

            migrationBuilder.RenameIndex(
                name: "IX_Node_TreeId",
                table: "Nodes",
                newName: "IX_Nodes_TreeId");

            migrationBuilder.RenameIndex(
                name: "IX_Node_ParentId",
                table: "Nodes",
                newName: "IX_Nodes_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nodes",
                table: "Nodes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentId",
                table: "Nodes",
                column: "ParentId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Trees_TreeId",
                table: "Nodes",
                column: "TreeId",
                principalTable: "Trees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
