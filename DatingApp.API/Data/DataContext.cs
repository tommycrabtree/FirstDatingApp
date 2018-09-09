using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;


// 2:8

// The first thing I do is allow DataContext to inherit from a higher level class
// called DbContext, which might require a ‘using’ statement to access the DbContext
// namespace.  Inheritance allows me to reuse any methods inside the Parent Class,
// or extend it, or modify the Parent Class’s behavior.  DbContext represents a
// session with the database, and can be used to query and save instances of my
// Entities.  For example, if I have a Table called ‘Values’ in my database, I can
// use DbContext to send a query via Entity Framework to the database.  EF will
// then return the results of my query back to the calling method, which may be
// a Controller.  Since DataContext is now a Derived Class from DbContext, it must
// have an instance of DbContextOptions of in order to work.  I pass the options up
// into the Base Constructor of the DbContext by creating a ctor inside the
// DataContext Class, passing in DbContextOptions of type ‘DataContext’ and naming
// it ‘options’.  Then I chain this to the DbContext Base Constructor by passing
// in the keyword ‘base’ and sending up ‘options’.  I don’t need to put anything
// inside this Constructor, so the curly braces are empty.

// In order to tell EF about my Entities, I then, in my DataContext class, I create
// some ‘DbSet’ Properties of type <Value>, which represents my Entity.  I also
// need to add a ‘using’ statement for the Models namespace since it contains my
// Value class.  It’s good practice to pluralize the name of the entity when naming
// this Property, so I’ll call it ‘Values’ because this will eventually be the name
// of the Table in SQL once I create the database.


// 2:9

// In order to use the .NET EF tools from the Command Prompt, the application can’t
// be running.  dotnet ef -h shows me the available commands for .NET EF.  The
// commands to manage Migrations, which provide a way to incrementally apply changes
// to the database to keep it in sync with my EF Core Model while preserving the
// data in the database.  When I add a Migration, EF will look at my DataContext
// class.  EF will then create Table(s) in my database based on my DbSet code in
// DataContext.cs.  To add a Migration, I type this code: dotnet ef migrations add
// InitialCreate.  InitialCreate is simply the name I’ve given this Migration.
// Now EF will go ahead and create some Classes to scaffold my database.  This
// creates a Migrations folder in the Solution Explorer.  In the Migrations folder,
// the DataContextModelSnapshot.cs file is EF’s way of keeping track of which
// Migrations have been applied so that it doesn’t have to query the database to
// see the status of Migrations. The numbers in front of _InitialCreate.cs and
// _InitialCreate.Designer.cs are a timestamp.  _InitialCreate.Designer.cs is
// purely used to decide what to remove from the DataContextModelSnapshot.cs file.

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Value> Values { get; set; }
    }
}