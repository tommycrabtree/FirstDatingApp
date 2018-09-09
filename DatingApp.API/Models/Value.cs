// 2:8

// As part of my Walking Skeleton, where part of the goal is to always do the
// simplest thing possible, I need to create a database, and I need to write
// methods that will retrieve data from the database.  Models are the classes
// that represent the objects which can directly relate to Tables in the database.
// First, I create a new Folder in the root of my project called ‘Models’.
// Then I can right-click on the folder to create a new Class, which I’ll name
// ‘Values’.  Next, I create two Properties (int Id and string Name); one for
// each of the two values that will be in the Table.  ‘get’ means I’ll be able
// to get the Id (or the Name) from other Classes in my application.  ‘set’
// means I’ll be able to set the Id (or the Name) from other Classes in my
// application.

// Now I need to tell Entity Framework, the Object Relational Mapper that I’m using
// for this application, about this Model because Entity Framework is going to be
// responsible for scaffolding and creating my database.  I’ll also be using Entity
// Framework to query my database.  By the way, Models are also known as Entities.
// I’ll create another folder, also in the root of my project, called ‘Data’.
// Inside ‘Data’ (by right-clicking), I create a new Class called DataContext.

namespace DatingApp.API.Models
{
    public class Value
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}