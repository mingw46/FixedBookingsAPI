using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedBookings.Service.API.Migrations
{
    public partial class booking_table_isactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Bookings");
        }
    }
}
