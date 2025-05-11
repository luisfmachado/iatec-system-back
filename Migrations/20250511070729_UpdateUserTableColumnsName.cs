using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iatec_system_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Email");
        }
    }
}
