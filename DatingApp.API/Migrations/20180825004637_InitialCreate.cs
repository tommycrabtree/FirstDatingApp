using Microsoft.EntityFrameworkCore.Migrations;


// 2:9

// _InitialCreate.cs is a partial class that inherits from the Migration class.
// The Up( ) contains all the code that EF needs to create my database, create
// my Tables, and change my database.  Inside the Up( ), CreateTable( ) creates
// my Table(s) and names it according to the name provided by DbSet.  It also
// creates the columns based on the Properties in my Value class, and by
// convention, automatically assigns the Id to be the Primary Key of the Table.
// The Primary Key can be assigned to another Property if necessary.  The
// Down( ) allows me to roll back a Migration that has already been applied to
// my database.

// Now I can create my database in the Command Prompt by using the Migration.
// To apply the Migration (and to also create the database if the database
// doesn’t yet exist), I type ‘dotnet ef database update’.  I now have a
// DatingApp.db in Solution Explorer.  I can examine the database clicking on
// ‘Open Database’ in DB Browser for Sqlite.  Selecting the ‘Browse Data’ tab
// lets me see the records in the database.  A quick way to add records is to
// click ‘New Record’.  The Id is automatically generated, and I can type the
// ‘Name’ in the Text Mode area.  Now I click the ‘Write Changes’ button, and
// my newly created values are in my SQL database.

namespace DatingApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
