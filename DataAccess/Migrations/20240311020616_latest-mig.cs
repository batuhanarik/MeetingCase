using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class latestmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "OperationClaims",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1,"superadmin" },
                { 2,"admin" },
                { 3,"product_manager" },
                { 4,"developer" },
                { 5,"intern" },
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
