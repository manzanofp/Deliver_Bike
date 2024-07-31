using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deliver.Bike.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_Available_Column_In_Motorcycle_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "MotorCycles",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "MotorCycles");
        }
    }
}
