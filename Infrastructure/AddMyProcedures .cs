using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore.Migrations;  
using Microsoft.EntityFrameworkCore.Metadata;  


namespace Infrastructure
{
    public partial class AddMyProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Stored Procedure
            migrationBuilder.Sql(@"
            CREATE PROCEDURE sp_GetProducts
            AS
            BEGIN
                SELECT * FROM Products;
            END
        ");

            // Vista
            migrationBuilder.Sql(@"
            CREATE VIEW View_Products AS
            SELECT ProductId, Name, Price, Stock
            FROM Products
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS View_Products;");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_GetProducts;");
        }
    }

}
