using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Bike.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_isActive_Column_In_Rent_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rents",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rents");
        }
    }
}
