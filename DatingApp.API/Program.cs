using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// 1:2

// dotnet --version
// node --version
// npm --version
// dotnet ef -h

// VS Code Extensions: NuGet, C# for VS Code by OmniSharp, C# IDE Extensions for VS Code

// Postman is an API Development Environment that lets me query my API
// without writing client-side code.  It’s very useful for testing a Web API.

// I use a SQLite database for development.  DB Browser for SQLite lets me query
// the SQLite database during development.


// 2:3

// The Object Relational Mapper is Entity Framework Core 2.1.  The ORM allows the API
// to send queries to the database.

// The SPA, which in this case is an Angular application, gets the values via the API.
// I’m using the DotNetCLI to create the WebAPI.


// 2:4

// Use the DotNetCLI to create the WebAPI project
// dotnet -h displays all the options that I have in the CLI
// dotnet run runs the project
// dotnet new -h displays contextual help for the different types of projects I can build
// .. goes up a level in my directory.  cd selects a specific folder
// My .NET Core project is going to very specifically be for the WebAPI,
// which runs all of my server side code

// The Angular project is purely being used for the front end, client-side application
// dotnet new webapi -h displays the help options for a dotnet webapi
// (i.e. Azure and authentication)

// mkdir DatingApp creates a folder called DatingApp
// cd DatingApp switches to the DatingApp folder
// ls shows what’s in the current directory
// dotnet new webapi -o DatingApp.API -n DatingApp.API creates output and name of DatingApp.API
// code . opens VS Code in my current folder


// 2:5

// In Program.cs, if I right-click on CreateDefaultBuilder in the CreateWebHostBuilder( ),
// which is called by the Main( ), I can select ‘Go To Definition’ to see comprehensive
// notes and comments, including the fact that this method will use Kestrel as a Web Server
// and configure the Kestrel Web Server using the application’s configuration providers.
// I’m building a WebAPI, and I need a web server to host it.  The Kestrel Web Server will
// host my WebAPI.  Kestrel is a lightweight web server; it’s not as powerful as IIS or
// Apache, but it certainly allows me to start my .NET application, and I’ll be able to send
// HTTP Requests to this Server and get a response back from my application during development.
// Also in the Program.cs class, the CreateWebHostBuilder( ) uses a Startup class called
// Startup.cs, which contains the Startup methods for the application.


// 2:6

// I’m using “Attribute Routing” in this application.  The DotNetCLI gives me a
// Controllers folder called ‘Controllers’.  Inside the Controllers folder is a sample
// Controller called ‘ValuesController.cs’, which was also provided by the DotNetCLI.


// 2:19

// Use Source Control to check in all of my changes.

// I’m going to use Git as my Command Prompt-based Version Control system.  I can go to
// git-scm.com to download Git.  Once it’s downloaded, I can type ‘git’ in my Command
// Prompt to see a list of Help Options for things that I can do with Git.

// Back in VS Code, the stethoscope icon represents Version Control inside VS Code.
// When I used ‘ng new’ to create my Angular project, it also initialized a Git Repository
// for me.  However, for this course, I’m going to somewhat controversially have one Git
// Repository that will contain both of my projects (my SPA and my API).  I can get away
// with this because it’s just me; in the future, when I’m working with others, I’ll
// probably have a Git Repository for each project.

// To see proof of the Git Repository that the Angular CLI initialized for me, I can type
// ‘git status’ from the Command Prompt of my DatingApp-SPA.  The easiest way to delete
// this Git Repository is to delete the actual folder in in the DatingApp-SPA folder on
// my C: drive.  I’ll have to ‘Show Hidden Files’ on my PC to see the .git folder in my
// DatingApp-SPA folder.  I’ll delete the .git folder.

// The Angular CLI also gave me a .gitignore file in my Solution Explorer.  Changes to
// anything listed in .gitignore will not be tracked.  Because of its number of files,
// node_modules is already in .gitignore.  The idea of this system is that the versions
// of the packages that we’re using are recorded and contained in package.json.
// Therefore, I do save package.json into Version Control.  If I want to clone my
// Repository so I can use it on another computer, all I’ll need to do is ‘npm install’
// in order to have all the node_modules that are in my package.json.

// In the Command Prompt, inside context of the DatingApp folder, I’ll type ‘git init’
// to initialize an empty Git Repository at this level.  This will cause my VS Code’s
// stethoscope to update its number of changes because it will now include both the
// .NET Project (my API) and my SPA.  Since I don’t need to track all of these files,
// I’ll also add a .gitignore into my .NET Project by right-clicking on the root
// (DatingApp.API) and creating a new file called .gitignore.  Here are the files I
// don’t need to track in my API: ‘.vscode, bin, obj, and *.db.’, so I just type them
// into a list in this .gitignore file.

// Now the Source Control Stethoscope tab shows all the changes that will make up my
// initial “Commit”.  These are the files that I want to Commit into my Source Control.
// To do this, I type ‘Initial Commit’ in the Text Box near the top of the Source
// Control pane.  Then I click the + button because I need to “Stage” my changes first.
// Then I select the ‘Initial Commit’ Text Box and press CTRL + Enter to Commit all of
// these changes into my Git Repository, and all of these changes are saved locally.

// I’ll create an account on GitHub.  Then I’ll click the “New repository” button and
// name it ‘DatingApp’.  I can ignore the Description, keep it Public, and ignore the
// “Initialize this repository with a README”.  I click ‘Create repository’.

// Now I’ll see a list of commands that I can use.  I’ve already used some of them.
// I’ll copy the ‘git remote add origin’, which includes the https: address of my Git
// Repository.  Next, I go back to VS Code and paste this command into the Command
// Prompt from my DatingApp directory.  Now, if I click on the ellipsis of my Source
// Control Stethoscope, I can select ‘Push to…’.  Then, in the main Text Box at the
// top-center of VS Code, I’ll see ‘origin’ plus the address of my Git Repository.
// If I select this as the Remote Origin, it will go ahead and “Push” all of my changes
// up to GitHub.  Now, if I go back to GitHub (and refresh the page) I’ll see my project
// in GitHub.  I can dismiss the ‘vulnerability’ message by selecting ‘Risk is tolerable
// to this project’.


namespace DatingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
