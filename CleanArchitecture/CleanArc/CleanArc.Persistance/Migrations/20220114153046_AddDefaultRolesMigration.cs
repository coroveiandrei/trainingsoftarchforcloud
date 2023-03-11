using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CleanArc.Persistance.Migrations
{
    public partial class AddDefaultRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string resourceName = typeof(AddDefaultRolesMigration).Namespace + ".20220114153046_AddDefaultRolesMigration.sql";

            string sqlText;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                sqlText = reader.ReadToEnd();
                migrationBuilder.Sql(sqlText);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
