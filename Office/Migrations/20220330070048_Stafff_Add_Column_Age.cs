using Microsoft.EntityFrameworkCore.Migrations;

namespace Office.Migrations
{
    public partial class Stafff_Add_Column_Age : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Staffs");
        }
    }
}
