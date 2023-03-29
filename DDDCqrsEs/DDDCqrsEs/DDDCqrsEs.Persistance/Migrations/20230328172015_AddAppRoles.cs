using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;
using System.Reflection;

#nullable disable

namespace DDDCqrsEs.Persistance.Migrations
{
    public partial class AddAppRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string resourceName = typeof(AddAppRoles).Namespace + ".20230328172015_AddAppRoles.sql";

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
